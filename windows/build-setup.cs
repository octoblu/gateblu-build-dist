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
		   
		   Directory.CreateDirectory(tmpPath);
		   /*

		   #http://dl.node-webkit.org/v0.10.5/node-webkit-v0.10.5-win-ia32.zip
       #https://codeload.github.com/octoblu/gateblu-ui/zip/master
       #http://nodejs.org/dist/v0.10.32/x64/node.exe
       #http://nodejs.org/dist/npm/npm-1.4.12.zip
       #$gatebluZipFileName
       */

	     DownloadAndDecompressFile("https://github.com/octoblu/gateblu-ui/archive/master.zip", tmpPath +"\\gateblu-ui.zip", tmpPath);

	     Directory.Move(tmpPath + "\\gateblu-ui-master", path + "\\gateblu-ui");
	     var directoryInfo = Directory.CreateDirectory(nodePath);

       DownloadAndDecompressFile("http://dl.node-webkit.org/v0.10.5/node-webkit-v0.10.5-win-ia32.zip", tmpPath + "\\node-webkit-v0.10.5-win-ia32.zip", path)
       DownloadAndDecompressFile("http://nodejs.org/dist/npm/npm-1.4.12.zip", tmpPath + "\\npm-1.4.12.zip",  nodePath);
       DownloadFile("http://nodejs.org/dist/v0.10.32/x64/node.exe", nodePath );

	      http = HttpWebRequest.Create(uri.AbsoluteUri);
	      stream = response.GetResponseStream();
        fileStream = new FileStream(zipFilePath, FileMode.Create);
        stream.CopyTo(fileStream);
        response.Close();
        fileStream.Close();










		}
		
		static void DecompressFile(string filename, string targetDirectory ){
	        using (ZipFile zipFile = ZipFile.Read(filename))
	        {
				    zipFile.ExtractAll(targetDirectory);
			    }
	  }

	  static void DownloadAndDecompressFile(string remoteDownloadLink, string zipFilePath,  string targetDirectory){
	  		   Uri uri = new Uri(remoteDownloadLink);
    		   WebRequest http = HttpWebRequest.Create(uri.AbsoluteUri);
    		   HttpWebResponse response = (HttpWebResponse)http.GetResponse();
    		   Stream stream = response.GetResponseStream();
    		   FileStream fileStream = new FileStream(zipFilePath, FileMode.Create);
    		   stream.CopyTo(fileStream);
    		   response.Close();
    		   fileStream.Close();
    		   Console.WriteLine("Downloading Gateblu-UI ....");
    	     DecompressFile(zipFilePath, targetDirectory);
	  }

	  static void DownloadFile(string remoteDownloadLink, string targetDirectory){


	  }
  }
  
}