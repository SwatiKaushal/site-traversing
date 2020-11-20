# site-traversing

Requirement

Do a console program in C# that can recursively traverse and download www.tretton37.com and save it to disk while keeping the online file structure by utilizing 
maximum asynchronicity and parallelism as much as possible while showing progress in console. There is no focus on html link extraction, keep that part 
simple (regex or similar), focus is on asynchronicity , parallelism and threading .

Solution

I have created a solution which is traversing recursively and downloading www.tretton37.com website folders in the respective
order and save it to my disk. The solution has used asynchronous way to avoid freezing the UI and thus focussing on
asynchronicity and parallelism.

In this case i have used the WebClient.DownloadFileAsync method.
As the method is asynchronous, we need to instance the callbacks properly in the downloadFile method.

To test the snippet, i have added a progress bar to form and execute the downloadFile method.

As a plus, i am showing the total of pending bytes from the filesize (in bytes) of the file in the DownloadProgressChanged 
event. 

Attribute [STAThread](while entering into program) is making sure that the threading model for the application is 
a single-threaded apartment.


Steps to run the application :
   1.  git clone https://github.com/SwatiKaushal/site-traversing.git
   2.  cd site-traversing
   3.  Open the solution in Visual Studio 
   4.  Build and Run the solution and see the progress on console

 
