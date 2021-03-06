import React, { Component } from 'react';
import ChartistGraph from 'react-chartist';
import checkStatus from './checkStatus';

class DailyReturn extends Component {
  constructor(props) {
    super(props);
    this.state = {
      chartData : { labels: [], series: [] },
      selectedDate : '2010-03-31',
      selectedRegion: 'US'
    };
  }

  refresh = (region, date) => {
    console.log(region);
    console.log(date);
    fetch('http://localhost:2774/api/dailyreturns/' + region + '/' + date, {
      accept: 'application/json',
    }).then(checkStatus)
      .then((response) => response.json())
      .then((data) => this.setState({
        chartData: data,
        selectedDate: date
      }))
  }

  componentDidMount() {
    this.refresh(this.state.selectedRegion, this.state.selectedDate);
  }

  render() {
    return (
      <div>
        <h2>Cumulative P&amp;L By Region</h2>

        <div>
            <select value={this.state.selectedRegion}
             onChange={(e) => this.refresh(e.target.value, this.state.selectedDate)
            }>
                <option value="AP">AP</option>
                <option value="EU">EU</option>
                <option value="US">US</option>
            </select>
        </div>
        <div>
            <select value={this.state.selectedDate}
             onChange={(e) => this.refresh(this.state.selectedRegion, e.target.value)}>
                <option value="2010-03-31">2010 1st Quarter</option>
                <option value="2010-06-30">2010 2nd Quarter</option>
                <option value="2010-09-30">2010 3rd Quarter</option>
                <option value="2010-12-31">2010 4th Quarter</option>
                <option value="2011-03-31">2011 1st Quarter</option>
                <option value="2011-06-30">2011 2nd Quarter</option>
                <option value="2011-09-30">2011 3rd Quarter</option>
                <option value="2011-12-31">2011 4th Quarter</option>
                <option value="2012-03-31">2012 1st Quarter</option>
                <option value="2012-05-30">2012 2nd Quarter</option>
            </select>
        </div>
        <ChartistGraph className={'ct-octave'} data={this.state.chartData} type={'Line'} />
      </div>
    );
  }
}

export default DailyReturn;
