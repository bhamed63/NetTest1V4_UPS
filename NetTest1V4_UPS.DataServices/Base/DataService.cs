using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetTest1V4_UPS.DataServices.Base
{
    public abstract class DataService<T> : IDataService<T>
    {
        #region private members

        ServiceAdapter _serviceAdapter;

        #endregion private members

        #region private methods

        private static JsonSerializerSettings createJsonSerializerSettings()
        {
            DefaultContractResolver contractResolver = createDefaultContractResolver();
            return createJsonSerializerSettings(contractResolver);
        }

        private static JsonSerializerSettings createJsonSerializerSettings(DefaultContractResolver contractResolver)
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };
        }

        private static DefaultContractResolver createDefaultContractResolver()
        {
            return new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
        }

        private string createSearchUrl(int page, Dictionary<string, object> filterValues)
        {
            string filterUrl = "?page=" + page;
            string url = this.getResourceName();

            foreach (var item in filterValues)
            {
                filterUrl = String.Format("{0}&{1}={2}", filterUrl, item.Key, item.Value);
            }

            return url + filterUrl;
        }

        private string createPostURL()
        {
            return this.getResourceName();
        }

        private string createDeleteURL(int id)
        {
            return this.getResourceName() + "/" + id;
        }

        private StringContent createModelContent(T model, JsonSerializerSettings settings)
        {
            var payload = JsonConvert.SerializeObject(model, settings);
            return new StringContent(payload, Encoding.UTF8, "application/json");
        }

        #endregion private methods

        #region constructors

        public DataService(ServiceAdapter serviceAdapter)
        {
            this._serviceAdapter = serviceAdapter;
        }

        #endregion

        #region public methods

        public virtual async Task<GetDataListResult<T>> GetDataListAsync(int page, Dictionary<String, Object> filterValues)
        {
            string url = this.createSearchUrl(page, filterValues);
            return await _serviceAdapter.GetDataListAsync<T>(url);
        }

        public virtual async Task<CreateResult> Create(T model)
        {
            JsonSerializerSettings settings = createJsonSerializerSettings();

            StringContent content = createModelContent(model, settings);

            string url = this.createPostURL();

            return await _serviceAdapter.Create(url, content);
        }

        public virtual async void Edit(T model)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<RemoveResult> Remove(int id)
        {
            string url = this.createDeleteURL(id);

            return await _serviceAdapter.Remove(url);
        }

        protected abstract string getResourceName();

        #endregion
    }
}

