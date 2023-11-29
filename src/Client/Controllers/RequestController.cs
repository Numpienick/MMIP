using System.Net;
using System.Net.Http.Json;
using Shared.Entities;
using Environment;
using Client.Resources;
using MudBlazor;

namespace Client.Controllers
{
    internal class RequestController
    {
        private readonly HttpClient _httpClient;

        private readonly ISnackbar _snackbar;

        public RequestController(ISnackbar snackbar, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _snackbar = snackbar;
        }

        public async Task Post<TEntity>(string uri, TEntity model)
            where TEntity : BaseEntity
        {
            var response = await _httpClient.PostAsJsonAsync(uri, model);
            try
            {
                response.EnsureSuccessStatusCode();
                _snackbar.Add(await response.Content.ReadAsStringAsync(), Severity.Success);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                _snackbar.Add(ApplicationResource.Request_NotFound, Severity.Error);
            }
            catch (HttpRequestException ex)
                when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                _snackbar.Add(ApplicationResource.Request_ServiceUnavailable, Severity.Error);
            }
            catch (HttpRequestException ex)
                when (ex.StatusCode
                        is HttpStatusCode.NotAcceptable
                            or HttpStatusCode.RequestEntityTooLarge
                )
            {
                _snackbar.Add(ApplicationResource.Request_TooLarge, Severity.Error);
            }
        }
    }
}
