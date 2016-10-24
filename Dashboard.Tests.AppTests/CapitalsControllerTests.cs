using Dashboard.App.Board.Controllers;
using Dashboard.App.Board.Domain.Contracts;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dashboard.Tests.AppTests
{
    public class CapitalsControllerTests
    {
        [Subject(typeof(CapitalsController))]
        public class When_get_request_is_made
        {
            private static Mock<IDataApi> _dataApi;
            private static CapitalsController _controller;

            Establish context = () =>
            {
                _dataApi = new Mock<IDataApi>();
                _controller = new CapitalsController(_dataApi.Object);
            };

            Because of = async () => await _controller.Get();

            It should_list_monthly_capitals = () => _dataApi.Verify(d => d.ListCapitals());
        }
    }
}
