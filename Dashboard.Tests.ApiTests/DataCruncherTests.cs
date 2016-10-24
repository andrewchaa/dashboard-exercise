using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Api.DataStore.Domain.Contracts;
using Dashboard.Api.DataStore.Domain.Models;
using Dashboard.Api.DataStore.Domain.Services;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dashboard.Tests.ApiTests
{
    public class DataCruncherTests
    {
        public class BaseContext
        {
            protected static DataCruncher _cruncher;
            protected static Mock<IStrategyRepository> _strategyRepository;
            protected static Mock<IPnLRepository> _pnlRepository;
            protected static Mock<ICapitalRepository> _capitalRepository;
            protected static DateTime _byDate;
            protected const string UsRegion = "US";
            protected static IEnumerable<IEnumerable<PnLDailyReturn>> _dailyReturnsList;
            protected static IEnumerable<Strategy> _usStrategies;
            protected static Strategy _usStrategy1;

            Establish context = () =>
            {
                _byDate = new DateTime(2011, 5, 30);
                _usStrategy1 = new Strategy { Region = UsRegion, StrategyId = 1 };
                _usStrategies = new List<Strategy> { _usStrategy1 };

                _strategyRepository = new Mock<IStrategyRepository>();

                _pnlRepository = new Mock<IPnLRepository>();
                _capitalRepository = new Mock<ICapitalRepository>();

                _cruncher = new DataCruncher(_strategyRepository.Object,
                    _pnlRepository.Object, _capitalRepository.Object);
            };
        }

        [Subject(typeof(DataCruncher))]
        public class When_list_daily_returns : BaseContext
        {
            private static Strategy _usStrategy2;

            Establish context = () =>
            {
                _usStrategy2 = new Strategy { Region = UsRegion, StrategyId = 2 };
                _usStrategies = new List<Strategy> { _usStrategy1, _usStrategy2};
                _strategyRepository.Setup(s => s.ListBy(UsRegion)).ReturnsAsync(_usStrategies);

            };

            Because of = async () => _dailyReturnsList = 
                await _cruncher.ListDailyReturns(UsRegion, _byDate);

            It should_retrieve_strategies_for_the_region = () => _strategyRepository.Verify(s => s.ListBy(UsRegion));
            It should_retrieve_data_for_us_strategy1 = () => _pnlRepository.Verify(p => p.ListBy(_usStrategy1.StrategyId, _byDate));
            It should_retrieve_data_for_us_strategy2 = () => _pnlRepository.Verify(p => p.ListBy(_usStrategy2.StrategyId, _byDate));
        }

        [Subject(typeof(DataCruncher))]
        public class When_process_daily_returns : BaseContext
        {
            private static IEnumerable<PnLCapital> _pnlCapitals;

            Establish context = () =>
            {
                _pnlCapitals = new List<PnLCapital>
                {
                    new PnLCapital
                    {
                        Capital = 1000m,
                        Date = _byDate,
                        PnL = 10m,
                        Region = UsRegion,
                        Strategy = _usStrategy1.StrategyId
                    }
                };

                _strategyRepository.Setup(s => s.ListBy(UsRegion)).ReturnsAsync(_usStrategies);
                _pnlRepository.Setup(p => p.ListBy(_usStrategy1.StrategyId, _byDate))
                    .ReturnsAsync(_pnlCapitals);
            };

            Because of = async () => _dailyReturnsList = 
                await _cruncher.ListDailyReturns(UsRegion, _byDate);

            It should_calculate_the_returns = () =>
            {
                var daily = _dailyReturnsList.First().First();
                daily.DailyReturn.ShouldEqual(daily.PnL/daily.Capital*100);
            };
        }


    }
}
