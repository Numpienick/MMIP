using MMIP.Client.Resources;
using MMIP.Shared.Entities;
using MudBlazor;
using System;
using System.Net;
using System.Net.Http.Json;

namespace MMIP.Client.Controllers
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

        public async Task Post(string uri, object model)
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
