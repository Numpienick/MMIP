using MudBlazor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Client.Controllers
{
    public class RequestController
    {
        [Inject]
        public static HttpClient Client { get; set; }

        public static async Task<string> Post(string uri, object model)
        {
            var response = await Client.PostAsJsonAsync(uri, model);
            try
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return "Er is iets fout gegaan aan onze kant, probeer het later nog een keer";
            }
            catch (HttpRequestException ex)
                when (ex.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                return "De server is onbereikbaar";
            }
            catch (HttpRequestException ex)
                when (ex.StatusCode
                        is HttpStatusCode.NotAcceptable
                            or HttpStatusCode.RequestEntityTooLarge
                )
            {
                return "De opgegeven data is te groot.";
            }
        }
    }
}
