using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MarsImage.Helpers
{
    public class FileHelper
    {
        public async Task<bool> DownloadFile(string url) {

            string fileName = GetFileNameFromUrl(url);
            bool isSuccess = false;
            WebClient myWebClient = new WebClient();

            try
            {
                myWebClient.DownloadFile(url, @"wwwroot\downloadedImages\"+fileName);
                isSuccess = true;
            }
            catch(Exception ex) { 
            
            }

            return isSuccess;
        }

        public static string GetFileNameFromUrl(string url) {
            Uri uri = new Uri(url);
            return System.IO.Path.GetFileName(uri.AbsolutePath);
        }
    }
}
