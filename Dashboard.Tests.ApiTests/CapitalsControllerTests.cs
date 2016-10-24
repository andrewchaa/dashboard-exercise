using Dashboard.Api.DataStore.Controllers;
using Dashboard.Api.DataStore.Domain.Contracts;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dashboard.Tests.ApiTests
{
    public class CapitalsControllerTests
    {
        [Subject(typeof(CapitalsController))]
        public class When_get_request_is_made
        {
            private static CapitalsController _controller;
            private static Mock<ICrunchData> _dataCruncher;

            Establish context = () =>
            {
                _dataCruncher = new Mock<ICrunchData>();
                _controller = new CapitalsController(_dataCruncher.Object);
            };

            Because of = async () => await _controller.Get();

            It should_list_monthly_capitals = () => _dataCruncher.Verify(d => d.ListMonthlyCapitals());
        }
    }
}
