﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace Site_Traversing
{
   public class Program
    {
       [STAThread]       // understand meaning 
        static void Main(string[] args)
        {
           // entry point
            Console.WriteLine("site travesing started:");
            traverse();
            Console.ReadLine();
        }

        private static void traverse()
        {
            string indexUrl = "https://tretton37.com/";

            WebBrowser browser = new WebBrowser();
            browser.Navigate(indexUrl);

            do
            {
                Application.DoEvents();
            } while (browser.ReadyState != WebBrowserReadyState.Complete);

            foreach (HtmlElement linkElement in browser.Document.GetElementsByTagName("a"))
            {
                string pageUrl = linkElement.GetAttribute("href");  
                downloadFileAsync(pageUrl);   
            }
        }

        /// Download a file asynchronously in the desktop path, show the download progress and save it with the original filename.
        private static void downloadFileAsync(string pageUrl)
        {
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Uri uri = new Uri(pageUrl);
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadFileAsync(uri, localPath + "/" + uri.Segments.Last());
            }
        }
 
        ///  Show the progress of the download in a progressbar
        private static void  wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage + "% | " + e.BytesReceived + " bytes out of " + e.TotalBytesToReceive + " bytes retrieven.");
        }

        private static void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {     
            if (e.Cancelled)
            {
                Console.WriteLine("The download has been cancelled");
                return;
            }
            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                Console.WriteLine("An error ocurred while trying to download file");
                return;
            }
            Console.WriteLine("File succesfully downloaded");
        }
    }
}
