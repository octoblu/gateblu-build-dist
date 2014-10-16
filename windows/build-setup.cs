using System; 
using System.IO;
using System.Net; 
using Ionic.Zip;

namespace Octoblu.Gateblu{

      public class Build {
	  
	    public static void Main(string[] args){
		   
		   string path = Directory.GetCurrentDirectory();
		   string tmpPath = path + "\\tmp";
		   string zipFilePath = tmpPath + "\\gateblu-ui.zip"; 
		   
		   Directory.CreateDirectory(tmpPath); 
		   Uri uri = new Uri("https://github.com/octoblu/gateblu-ui/archive/master.zip");
		   
		   WebRequest http = HttpWebRequest.Create(uri.AbsoluteUri);
		   HttpWebResponse response = (HttpWebResponse)http.GetResponse();
		   Stream stream = response.GetResponseStream();
		   FileStream fileStream = new FileStream(zipFilePath, FileMode.Create);
		   stream.CopyTo(fileStream); 
		   response.Close(); 
		   fileStream.Close(); 
		   Console.WriteLine("Downloading Gateblu-UI ....");
		   Console.WriteLine("Download Complete ....");
		   Console.WriteLine("Extracting Gateblu-UI source ....");
	   
	       DecompressFile(zipFilePath, tmpPath);

		}
		
		static void DecompressFile(string filename, string targetDirectory ){
	        using (ZipFile zipFile = ZipFile.Read(filename))
	        {
				 zipFile.ExtractAll(targetDirectory);
			}
	  }
  }
  
}