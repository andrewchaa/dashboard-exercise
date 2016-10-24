using System;
using Dashboard.App.Board.Controllers;
using Dashboard.App.Board.Domain.Contracts;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dashboard.Tests.AppTests
{
    public class PnLsControllerTests
    {
        [Subject(typeof(PnLsController))]
        public class When_get_request_is_made
        {
            private static Mock<IDataApi> _dataApi;
            private static PnLsController _controller;
            private static readonly DateTime ConvertedDate = new DateTime(2011, 5, 30);
            private const string Date = "2011-05-30";
            private const string Region = "AP";

            Establish context = () =>
            {
                _dataApi = new Mock<IDataApi>();
                _controller = new PnLsController(_dataApi.Object);
            };

            Because of = async () => await _controller.Get(Date);

            It should_list_cumulative_pnls = () => _dataApi.Verify(d => d.ListCumulativePnLs(ConvertedDate));
        }
    }
}
