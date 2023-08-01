using NetTest1V4_UPS.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetTest1V4_UPS.DataServices.Base
{
    public class ServiceAdapter
    {

        #region private members

        static string baseUrl = "https://gorest.co.in/public-api/";
        static string apiToken = "0bf7fb56e6a27cbcadc402fc2fce8e3aa9ac2b40d4190698eb4e8df9284e2023";

        static HttpClient client = createClient();

        #endregion private members

        #region private methods

        private static HttpClient createClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            return client;
        }

        #endregion private methods

        #region public methods

        public virtual async Task<GetDataListResult<T>> GetDataListAsync<T>(String url)
        {
            GetDataListResult<T> data = null;
            HttpResponseMessage response = await client.GetAsync(baseUrl + url);
            if (response.IsSuccessStatusCode)
            {
                var getDataAsJson = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<GetDataListResult<T>>(getDataAsJson);
            }
            return data;
        }

        public virtual async Task<CreateResult> Create(String postURL, StringContent content)
        {
            CreateResult data = null;

            HttpResponseMessage response = await client.PostAsync(baseUrl + postURL, content);
            if (response.IsSuccessStatusCode)
            {
                var createDataAsJson = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<CreateResult>(createDataAsJson);
            }
            return data;
        }

        public virtual async void Edit(String putURL, StringContent content)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<RemoveResult> Remove(String deleteUrl)
        {
            RemoveResult data = null;
            HttpResponseMessage response = await client.DeleteAsync(baseUrl + deleteUrl);
            if (response.IsSuccessStatusCode)
            {
                var removeDataAsJson = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<RemoveResult>(removeDataAsJson);
            }
            return data;
        }

        #endregion

    }
}
