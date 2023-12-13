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

        public async Task<List<TEntity>> Get<TEntity>(string uri)
            where TEntity : BaseEntity
        {
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadFromJsonAsync<List<TEntity>>().Result
                        ?? new List<TEntity>();
                }
            }
            catch (HttpRequestException ex)
            {
                _snackbar.Add(GetStringStatusCode(ex.StatusCode), Severity.Error);
            }
            return new List<TEntity>();
        }

        public async Task Post<T>(string uri, T model)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, model);
            try
            {
                response.EnsureSuccessStatusCode();
                _snackbar.Add(await response.Content.ReadAsStringAsync(), Severity.Success);
            }
            catch (HttpRequestException ex)
            {
                _snackbar.Add(GetStringStatusCode(ex.StatusCode), Severity.Error);
            }
        }

        public string GetStringStatusCode(HttpStatusCode? statusCode)
        {
            return statusCode switch
            {
                HttpStatusCode.BadRequest => ApplicationResource.Request_BadRequest,
                HttpStatusCode.NotFound => ApplicationResource.Request_NotFound,
                HttpStatusCode.ServiceUnavailable => ApplicationResource.Request_ServiceUnavailable,
                HttpStatusCode.NotAcceptable => ApplicationResource.Request_TooLarge,
                HttpStatusCode.RequestEntityTooLarge => ApplicationResource.Request_TooLarge,
                null => ApplicationResource.Request_ServiceUnavailable,
                _ => ApplicationResource.Request_Unknown
            };
        }
    }
}
