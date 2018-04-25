using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PortManager.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Services
{
    public class RESTService<T> : IRESTService<T> where T : class, new()
    {

        private HttpClient client;
        private string webServiceEndpoint = "";//TODO::

        public RESTService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }


        public async Task<T> Get(string queryString)
        {
           
            var format = "yyyy-MM-dd HH:mm"; // your datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var responseText = await client.GetStringAsync(CreateUri(queryString));
            return JsonConvert.DeserializeObject<T>(responseText, dateTimeConverter);


        }

        public async Task<T> Get(string queryString, int id)
        {
           
            var format = "yyyy-MM-dd HH:mm"; // your datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var responseText = await client.GetStringAsync(CreateUri(queryString, id));
            return JsonConvert.DeserializeObject<T>(responseText, dateTimeConverter);


        }

        public async Task<T> Get(string queryString, int firstId, int secondId)
        {
            
            var format = "yyyy-MM-dd HH:mm"; // your datetime format
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var responseText = await client.GetStringAsync(CreateUri(queryString, firstId, secondId));
            return JsonConvert.DeserializeObject<T>(responseText, dateTimeConverter);

        }

        public async Task<List<T>> GetAll(string queryString)
        {
            
            var format = "yyyy-MM-dd HH:mm";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var responseText = await client.GetStringAsync(CreateUri(queryString));
            return JsonConvert.DeserializeObject<List<T>>(responseText, dateTimeConverter);

        }

        public async Task<List<T>> GetAll(string queryString, int id)
        {
           
            var format = "yyyy-MM-dd HH:mm";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var responseText = await client.GetStringAsync(CreateUri(queryString, id));
            return JsonConvert.DeserializeObject<List<T>>(responseText, dateTimeConverter);

        }

        public async Task<T> Post(string queryString, T data)
        {
            
            var response = await client.PostAsync(CreateUri(queryString), ConvertDataToRequesty(data));
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);

        }

        public async Task<T> Put(string queryString, T data)
        {
            var response = await client.PostAsync(CreateUri(queryString), ConvertDataToRequesty(data));
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);


        }

        public async Task<T> Delete(string queryString, int id)
        {
           
            var response = await client.DeleteAsync(CreateUri(queryString, id));
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);

        }

        private Uri CreateUri(string queryString)
        {
            return new Uri(string.Format(webServiceEndpoint + queryString));
        }

        private Uri CreateUri(string queryString, int id)
        {
            return new Uri(string.Format(webServiceEndpoint + queryString + id));
        }

        private Uri CreateUri(string queryString, int firstId, int secondId)
        {
            return new Uri(string.Format(webServiceEndpoint + queryString + firstId + "/" + secondId));
        }

        private dynamic ConvertDataToRequesty(T data)
        {
            var format = "yyyy-MM-dd HH:mm";
            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = format };
            var json = JsonConvert.SerializeObject(data, dateTimeConverter);
            return new StringContent(json, Encoding.UTF8, "application/json");

        }
    }
}
