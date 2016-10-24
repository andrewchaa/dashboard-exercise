using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Api.DataStore.Controllers;
using Dashboard.Api.DataStore.Domain.Contracts;
using Machine.Specifications;
using Moq;

namespace Dashboard.Tests.ApiTests
{
    public class CapitalsControllerTests
    {
        [Subject(typeof(CapitalsController))]
        public class When_get_request_is_made
        {
            Establish context = () =>
            {
                var capitalRepository = new Mock<ICapitalRepository>();
                var dataCruncher = new Mock<ICrunchData>();
//                _controller = new CapitalsController(capitalRepository.Object, dataCruncher.Object);
            };

            Because of = async () => await _controller.Get();


            private static CapitalsController _controller;
        }
    }
}
