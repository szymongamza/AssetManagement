using System.Diagnostics;
using System.Text;
using System.Text.Json;
using AssetManagement.Application.Resources.Asset;
using AssetManagement.Application.Resources;
using System.Web;
using AssetManagement.Application.Resources.Stocktaking;
using AssetManagement.Domain.Common.Query;

namespace AssetManagement.Scanner.Services
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly IHttpsClientHandlerService _httpsClientHandlerService;

        public RestService(IHttpsClientHandlerService service)
        {
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _client = new HttpClient(handler);
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<QueryResultResource<StocktakingResource>> GetStocktakings(StocktakingQueryResource query)
        {
            var queryResult = new QueryResultResource<StocktakingResource>();

            var builder = new UriBuilder($"{Constants.AssetsUrl}");
            builder.Port = -1;
            var q = HttpUtility.ParseQueryString(builder.Query);
            q["IsClosed"] = $"{query.IsClosed}";
            q["Page"] = $"{query.Page}";
            q["ItemsPerPage"] = $"{query.ItemsPerPage}";
            builder.Query = q.ToString();
            string url = builder.ToString();

            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    queryResult = JsonSerializer.Deserialize<QueryResultResource<StocktakingResource>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return queryResult;
        }
    }
}
