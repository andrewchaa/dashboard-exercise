import React, { Component } from 'react';
import ChartistGraph from 'react-chartist';
import checkStatus from './checkStatus';

class Pnl extends Component {
  constructor(props) {
    super(props);
    this.state = {
      chartData : { labels: [], series: [] },
      selectedDate : '2010-03-31'
    };
  }

  refresh = (date) => {
    console.log(date);
    fetch('http://localhost:2774/api/pnls/' + date, {
      accept: 'application/json',
    }).then(checkStatus)
      .then((response) => response.json())
      .then((data) => this.setState({
        chartData: data,
        selectedDate: date
      }))
  }

  componentDidMount() {
    this.refresh(this.state.selectedDate);
  }

  render() {
    return (
      <div>
        <h2>Cumulative P&amp;L By Region</h2>

        <div>
            <select id="selDate" value={this.state.value} onChange={(event) => this.refresh(event.target.value)}>
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

export default Pnl;
