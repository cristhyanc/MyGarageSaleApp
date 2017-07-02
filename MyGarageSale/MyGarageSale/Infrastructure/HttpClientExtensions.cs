using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace MyGarageSale.Infrastructure
{
    public static class HttpClientExtensions
    {


        public static async Task<IList<T>> GetListAsync<T>(this HttpClient client, string baseUrl, string module, params Object[] parameters)
        {
            try
            {
                //if (InstanceLocator.IsOnline)
                //{
                    string jsonString = "";
                    var url = BuildUrl(baseUrl, module, parameters);
                    var httpRequest = new HttpRequestMessage(new HttpMethod("GET"), url);

                    client.Timeout = TimeSpan.FromSeconds(50);

                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        jsonString = await response.Content.ReadAsStringAsync();

                    }
                    var result = JsonConvert.DeserializeObject<IList<T>>(jsonString);
                    return result;
                //}
                //else
                //{
                //    // InstanceLocator.CheckConnection(true);
                //    return null;
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string BuildUrl(string baseUrl, string module, params Object[] parameters)
        {
            string result = "";
            String[] tempPara;
            result = baseUrl + "/" + module;
            if (parameters != null)
            {
                if (parameters.Length == 1)
                {
                    if (parameters[0].GetType() == typeof(String[]))
                    {
                        tempPara = (String[])parameters[0];
                        if (tempPara != null && tempPara.Length == 1)
                        {
                            result += "/" + parameters[0].ToString();
                        }
                        else
                        {
                            if (tempPara.Length > 1)
                            {
                                result += "?" + tempPara[0].ToString() + "=" + tempPara[1].ToString();
                            }

                        }
                    }
                    else
                    {
                        result += "/" + parameters[0].ToString();
                    }

                }
                else
                {

                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (parameters[i].GetType() == typeof(String[]))
                        {
                            tempPara = (String[])parameters[i];
                            if (tempPara.Length > 1)
                            {
                                if (i == 0)
                                {
                                    result += "?";
                                }
                                else
                                {
                                    result += "&";
                                }
                                result += tempPara[0].ToString() + "=" + tempPara[1].ToString();
                            }


                        }
                    }
                }
            }
            return result;
        }

        public static async Task<string> GetStringAsync(this HttpClient client, string url)
        {
            var httpRequest = new HttpRequestMessage(new HttpMethod("GET"), url);

            var response = client.SendAsync(httpRequest).Result;

            var jsonString = await response.Content.ReadAsStringAsync();

            return jsonString;
        }
    }
}
