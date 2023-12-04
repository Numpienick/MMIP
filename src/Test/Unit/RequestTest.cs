using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Client.Controllers;
using Client.Resources;
using Moq;
using MudBlazor;

namespace Test.Unit
{
    public class RequestTest
    {
        [Fact]
        public void ServiceNotFoundReturnsCorrectString()
        {
            var snackbar = Mock.Of<ISnackbar>();
            var httpClient = Mock.Of<HttpClient>();
            RequestController requestController = new RequestController(snackbar, httpClient);

            Assert.Equal(
                ApplicationResource.Request_NotFound,
                requestController.GetStringStatusCode(HttpStatusCode.NotFound)
            );
        }

        [Fact]
        public void ServiceUnavailableReturnsCorrectString()
        {
            var snackbar = Mock.Of<ISnackbar>();
            var httpClient = Mock.Of<HttpClient>();
            RequestController requestController = new RequestController(snackbar, httpClient);

            Assert.Equal(
                ApplicationResource.Request_ServiceUnavailable,
                requestController.GetStringStatusCode(HttpStatusCode.ServiceUnavailable)
            );
        }

        [Fact]
        public void RequestTooLargeReturnsCorrectString()
        {
            var snackbar = Mock.Of<ISnackbar>();
            var httpClient = Mock.Of<HttpClient>();
            RequestController requestController = new RequestController(snackbar, httpClient);

            Assert.Equal(
                ApplicationResource.Request_TooLarge,
                requestController.GetStringStatusCode(HttpStatusCode.RequestEntityTooLarge)
            );
        }

        [Fact]
        public void NotAcceptableReturnsCorrectString()
        {
            var snackbar = Mock.Of<ISnackbar>();
            var httpClient = Mock.Of<HttpClient>();
            RequestController requestController = new RequestController(snackbar, httpClient);

            Assert.Equal(
                ApplicationResource.Request_ServiceUnavailable,
                requestController.GetStringStatusCode(HttpStatusCode.ServiceUnavailable)
            );
        }
    }
}
