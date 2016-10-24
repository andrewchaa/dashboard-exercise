using System;
using Dashboard.Api.DataStore.Controllers;
using Dashboard.Api.DataStore.Domain.Contracts;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dashboard.Tests.ApiTests
{
    public class PnLsControllerTests
    {
        [Subject(typeof(PnLsController))]
        public class When_get_request_is_made
        {
            private static PnLsController _controller;
            private static Mock<ICrunchData> _dataCruncher;
            private static string _date;
            private static string _convertedRegion;
            private static DateTime _convertedDate;

            Establish context = () =>
            {
                _date = "2012-01-01";
                _convertedDate = new DateTime(2012, 1, 1);
                _dataCruncher = new Mock<ICrunchData>();
                _controller = new PnLsController(_dataCruncher.Object);
            };

            Because of = async () => await _controller.Get(_date);

            It should_list_accumulative_returns = () => 
                _dataCruncher.Verify(d => d.ListPnLs(_convertedDate));
        }
    }
}
