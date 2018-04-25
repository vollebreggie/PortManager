using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Services
{
    public class DynamicRESTService
    {
        private HttpClient client;
        private string webServiceEndpoint = "";//TODO::

        public DynamicRESTService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<dynamic> Get(string queryString, Type type)
        {

            var responseText = await client.GetStringAsync(CreateUri(queryString));
            dynamic data = JsonConvert.DeserializeObject(responseText, type);
            return data;
        }

        public async Task<List<dynamic>> GetAll(string queryString, Type type)
        {

            var responseText = await client.GetStringAsync(CreateUri(queryString));
            dynamic data = JsonConvert.DeserializeObject<List<dynamic>>(responseText);
            return data;
        }

        public async Task<dynamic> Post(dynamic data, string queryString)
        {
            var response = await client.PostAsync(CreateUri(queryString), ConvertDataToRequesty(data));
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        public async Task<dynamic> Put(dynamic data, string queryString)
        {
            var response = await client.PutAsync(CreateUri(queryString), ConvertDataToRequesty(data));
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        public async Task<dynamic> Delete(string queryString)
        {
            var response = await client.DeleteAsync(CreateUri(queryString));
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<dynamic>(responseContent);
        }

        private Uri CreateUri(string queryString)
        {
            return new Uri(string.Format(webServiceEndpoint + queryString));
        }

        private dynamic ConvertDataToRequesty(dynamic data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");

        }
    }
}
