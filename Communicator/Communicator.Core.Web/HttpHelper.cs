using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Communicator.Core.Web
{
    public interface IHttpHelperForJson
    {
        Task<T> GetAsync<T>(string urlApi, NameValueCollection qsParameters = null, AuthenticationHeaderValue authenticationHeaderValue = null, TimeSpan? timeout = null);
        Task PostAsync<T>(string urlApi, T inputModel, AuthenticationHeaderValue authenticationHeaderValue = null, TimeSpan? timeout = null);
    }

    public class HttpHelperForJson : IHttpHelperForJson
    {
        private HttpClient _client;

        public HttpHelperForJson()
        {
            _client = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
        }
        public async Task<T> GetAsync<T>(string urlApi, NameValueCollection qsParameters = null, AuthenticationHeaderValue authenticationHeaderValue = null, TimeSpan? timeout = null)
        {
            Task<T> model = null;

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (authenticationHeaderValue != null)
                _client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;

            if (qsParameters == null)
                qsParameters = new NameValueCollection();


            if (qsParameters.HasKeys())
            {
                var qsParams = string.Join("&", qsParameters.AllKeys.Select(key => $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(qsParameters[key])}"));
                urlApi = $"{urlApi}?{qsParams}";
            }

            using (var response = await _client.GetAsync(urlApi).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    model = Task.Run(() => JsonConvert.DeserializeObject<T>(responseData));
                }
            }

            if (model == null)
                return default;

            return await model;
        }

        public Task PostAsync<T>(string urlApi, T inputModel, AuthenticationHeaderValue authenticationHeaderValue = null, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }
    }
}
