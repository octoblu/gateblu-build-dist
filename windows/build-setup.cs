using System; 
using System.IO;
using System.Net; 
using Ionic.Zip;

namespace Octoblu.Gateblu{

      public class Build {
	  
	    public static void Main(string[] args){
		   
		   string path = Directory.GetCurrentDirectory();
		   string tmpPath = path + "\\tmp";
		   string distPath = path + "\\gateblu-ui\\dist";
		   string nodePath = distPath + "\\node-v0.10.32-win-x86";

       Console.WriteLine("Creating Temp Directory..");
		   Directory.CreateDirectory(tmpPath);
		   /*

		   #http://dl.node-webkit.org/v0.10.5/node-webkit-v0.10.5-win-ia32.zip
       #https://codeload.github.com/octoblu/gateblu-ui/zip/master
       #http://nodejs.org/dist/v0.10.32/x64/node.exe
       #http://nodejs.org/dist/npm/npm-1.4.12.zip
       #$gatebluZipFileName
       */
       Console.WriteLine("Downloading gateblu source and decompressing ..");
	     Build.DownloadAndDecompressFile("https://github.com/octoblu/gateblu-ui/archive/master.zip", tmpPath + "\\gateblu-ui.zip", path);
	     Console.WriteLine("Moving gateblu-ui-master to gateblu-ui.");

       Directory.Move(path + "\\gateblu-ui-master", path + "\\gateblu-ui");

	     if(!Directory.Exists(nodePath)){
	       Console.WriteLine("Moving gateblu-ui-master to gateblu-ui.");
	       Directory.CreateDirectory(nodePath);
	     }
       Console.WriteLine("Downloading NPM...");
       Build.DownloadAndDecompressFile("http://nodejs.org/dist/npm/npm-1.4.12.zip", tmpPath + "\\npm-1.4.12.zip",  path);
       Console.WriteLine("Downloading NPM...");
       Build.DownloadFile("http://nodejs.org/dist/v0.10.32/x64/node.exe", nodePath );

       //Run

		}
		
		public static void DecompressFile(string filename, string targetDirectory ){
	        using (ZipFile zipFile = ZipFile.Read(filename))
	        {
	          try {
	            zipFile.ExtractAll(targetDirectory, ExtractExistingFileAction.OverwriteSilently);
	          } catch(ZipException zx){
	            Console.WriteLine("Could Not OverWrite File");
	          }

			    }
	  }

	  public static void DownloadAndDecompressFile(string remoteDownloadLink, string filePath,  string targetDirectory){
    		   Build.DownloadFile(remoteDownloadLink, filePath);
    	     Build.DecompressFile(filePath, targetDirectory);
	  }

	  public static void DownloadFile(string remoteDownloadLink, string filePath){
       Uri uri = new Uri(remoteDownloadLink);
       WebRequest http = HttpWebRequest.Create(uri.AbsoluteUri);
       HttpWebResponse response = (HttpWebResponse)http.GetResponse();
       Stream stream = response.GetResponseStream();
       FileStream fileStream = new FileStream(filePath, FileMode.Create);
       stream.CopyTo(fileStream);
       response.Close();
       fileStream.Close();
	  }
  }
  
}