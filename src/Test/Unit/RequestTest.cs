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
        private readonly RequestController _requestController;

        public RequestTest()
        {
            var snackbar = Mock.Of<ISnackbar>();
            var httpClient = Mock.Of<HttpClient>();
            _requestController = new RequestController(snackbar, httpClient);
        }

        [Fact]
        public void ServiceNotFound_ReturnsCorrectString()
        {
            Assert.Equal(
                ApplicationResource.Request_NotFound,
                _requestController.GetStringStatusCode(HttpStatusCode.NotFound)
            );
        }

        [Fact]
        public void ServiceUnavailable_ReturnsCorrectString()
        {
            Assert.Equal(
                ApplicationResource.Request_ServiceUnavailable,
                _requestController.GetStringStatusCode(HttpStatusCode.ServiceUnavailable)
            );
        }

        [Fact]
        public void RequestTooLarge_ReturnsCorrectString()
        {
            Assert.Equal(
                ApplicationResource.Request_TooLarge,
                _requestController.GetStringStatusCode(HttpStatusCode.RequestEntityTooLarge)
            );
        }

        [Fact]
        public void NotAcceptable_ReturnsCorrectString()
        {
            Assert.Equal(
                ApplicationResource.Request_ServiceUnavailable,
                _requestController.GetStringStatusCode(HttpStatusCode.ServiceUnavailable)
            );
        }
    }
}
