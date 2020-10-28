using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MarsImage.Helpers;
using MarsImage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarsImage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        private static readonly string[] RequiredDates = {
            "02/27/17",
            "June 2, 2018",
            "Jul-13-2016",
            "April 31, 2018"
        };

        private const string NasaMarsAPI = "https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos";
        private const string APIKey = "3hNwHJPe4ekPpV84wRW5CmHkkAQCxAMcADY9Dexu";

        private const int ImageDownloadPerThread = 2;


        public void OnGet()
        {
            var nasaAPI = new NasaAPI();
            nasaAPI.baseUrl = NasaMarsAPI;
            nasaAPI.api_key = APIKey;
            IList<Photo> photoCollection =  GetImageDetails(nasaAPI, new RestClientHelper()).Result;

            DownloadFiles(nasaAPI, new FileHelper(), photoCollection);
            
        }

        private async Task<IList<Photo>> GetImageDetails(NasaAPI nasaAPI, RestClientHelper apiHelper) {

            var taskGetPhotoDetails = new List<Task<string>>();

            foreach (string reqDate in RequiredDates)
            {
                nasaAPI.earth_date = DateHelper.FormatDate(reqDate, "yyyy-MM-dd");
                if (!string.IsNullOrEmpty(nasaAPI.earth_date)) {
                    taskGetPhotoDetails.Add(apiHelper.GetAPIImagesDetails(nasaAPI.baseUrl, nasaAPI.GetApiParam()));
                }
            }

            await Task.WhenAll(taskGetPhotoDetails);
            var photoCollection = new List<Photo>();
            foreach (var task in taskGetPhotoDetails) {
                var rawData = task.Result;
                photoCollection.AddRange(JObject.Parse(rawData)["photos"].ToObject<Photo[]>());
            }

            return photoCollection; 
        }

        private async Task DownloadFiles(NasaAPI nasaAPI, FileHelper fileHelper, IList<Photo> photoCollection) {

            var taskDownloadPhoto = new List<List<Task<bool>>>();

            int limitCounter = 0;
            var photoDLLimit = new List<Task<bool>>();
            foreach (var photo in photoCollection) {
                
                photoDLLimit.Add(fileHelper.DownloadFile(photo.img_src));

                limitCounter++;
                if (limitCounter == ImageDownloadPerThread) {
                    taskDownloadPhoto.Add(photoDLLimit);
                    limitCounter = 0;
                    photoDLLimit.Clear();
                }
            }
            foreach (var taskList in taskDownloadPhoto) {
                Task.WhenAll(taskList);
            }

        }


        private string GetMarsImage() {

            return "";
        }

        //private void DownloadImage() { 

        //}

        private bool SaveImageFile()
        {

            return true;
        }
    }
}
