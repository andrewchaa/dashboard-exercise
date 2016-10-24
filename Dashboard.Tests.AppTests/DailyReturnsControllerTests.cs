using System;
using Dashboard.App.Board.Controllers;
using Dashboard.App.Board.Domain.Contracts;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dashboard.Tests.AppTests
{
    public class DailyReturnsControllerTests
    {
        [Subject(typeof(DailyReturnsController))]
        public class When_get_request_is_made
        {
            private static Mock<IDataApi> _dataApi;
            private static DailyReturnsController _controller;
            private static readonly DateTime ConvertedDate = new DateTime(2011, 5, 30);
            private const string Date = "2011-05-30";
            private const string Region = "AP";

            Establish context = () =>
            {
                _dataApi = new Mock<IDataApi>();
                _controller = new DailyReturnsController(_dataApi.Object);
            };

            Because of = async () => await _controller.Get(Region.ToLower(), Date);

            It should_list_cumulative_returns = () => _dataApi.Verify(d => d.ListCumulativeReturns(Region, ConvertedDate));
        }
    }
}
