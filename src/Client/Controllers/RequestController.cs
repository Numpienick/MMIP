using System.Net;
using System.Net.Http.Json;
using Shared.Entities;
using Environment;
using Client.Resources;

namespace Client.Controllers
{
    internal class RequestController
    {
        private HttpClient _httpClient;

        internal RequestController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(EnvironmentConstants.ApiUrl);
        }

        public async Task<string> Post<TEntity>(string uri, TEntity model)
            where TEntity : BaseEntity
        {
            var response = await _httpClient.PostAsJsonAsync(uri, model);
            try
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return ApplicationResource.Request_NotFound;
            }
            catch (HttpRequestException ex)
                when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                return ApplicationResource.Request_ServiceUnavailable;
            }
            catch (HttpRequestException ex)
                when (ex.StatusCode
                        is HttpStatusCode.NotAcceptable
                            or HttpStatusCode.RequestEntityTooLarge
                )
            {
                return ApplicationResource.Request_TooLarge;
            }
        }
    }
}
