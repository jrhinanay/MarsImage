using MarsImage.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MarsImage.Helpers
{
    public class RestClientHelper
    {

       /* public string GetAPIImagesDetails(string baseUrl, string param)
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(param).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            return result;
        }*/
        public async Task<string> GetAPIImagesDetails(string baseUrl, string param)
        {
            dynamic result = null;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);

            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
          
            HttpResponseMessage response = httpClient.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine(" {0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            //httpClient.Dispose();

            return result;
        }

    }
}
