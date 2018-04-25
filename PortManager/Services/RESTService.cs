using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PortManager.Services
{
    public class RESTService
    {
        public RESTService()
        {

        }

        public WebResponse SendRequest(string url, Object thingy, string token, string method)
        {
            string ret = string.Empty;

            StreamWriter requestWriter;

            var webRequest = WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                if(!token.Equals(""))
                webRequest.Headers.Add("Authorization", "Bearer " + token);
                webRequest.Method = method;
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.Timeout = 20000;

                webRequest.ContentType = "application/json";
                webRequest.Accept = "application/json";

                //POST the data.
                using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(JsonConvert.SerializeObject(thingy));
                }
            }

            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            Stream resStream = resp.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            ret = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<WebResponse>(ret);
        }
    }
}
