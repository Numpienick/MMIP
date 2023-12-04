using System.Net;
using System.Net.Http.Json;
using Shared.Entities;
using Environment;
using Client.Resources;
using MudBlazor;
using System.Runtime.CompilerServices;

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
            catch (HttpRequestException ex)
            {
                _snackbar.Add(GetStringStatusCode((HttpStatusCode)ex.StatusCode), Severity.Error);
            }
        }

        public string GetStringStatusCode(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    return ApplicationResource.Request_NotFound;
                case HttpStatusCode.ServiceUnavailable:
                    return ApplicationResource.Request_ServiceUnavailable;
                case HttpStatusCode.NotAcceptable:
                case HttpStatusCode.RequestEntityTooLarge:
                    return ApplicationResource.Request_TooLarge;
            }
            return "OK";
        }
    }
}
