using System;
using Dashboard.Api.DataStore.Controllers;
using Dashboard.Api.DataStore.Domain.Contracts;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dashboard.Tests.ApiTests
{
    public class DailyReturnsControllerTests
    {
        [Subject(typeof(DailyReturnsController))]
        public class When_get_request_is_made
        {
            private static DailyReturnsController _controller;
            private static Mock<ICrunchData> _dataCruncher;
            private static string _date;
            private static string _region;
            private static string _convertedRegion;
            private static DateTime _convertedDate;

            Establish context = () =>
            {
                _date = "2012-01-01";
                _region = "us";
                _convertedRegion = "US";
                _convertedDate = new DateTime(2012, 1, 1);
                _dataCruncher = new Mock<ICrunchData>();
                _controller = new DailyReturnsController(_dataCruncher.Object);
            };

            Because of = async () => await _controller.Get(_region, _date);

            It should_list_accumulative_returns = () => 
                _dataCruncher.Verify(d => d.ListAccumulativeReturn(_convertedRegion, _convertedDate));
        }
    }
}
