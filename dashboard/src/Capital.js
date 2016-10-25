import React, { Component } from 'react';
import ChartistGraph from 'react-chartist';
import checkStatus from './checkStatus';

class Capital extends Component {
  constructor(props) {
    super(props);
    this.state = {
      chartData : { labels: [], series: [] }
    };
  }

  refresh = () => {
    fetch('http://localhost:2774/api/capitals', {
      accept: 'application/json',
    }).then(checkStatus)
      .then((response) => response.json())
      .then((data) => this.setState({
        chartData: data
      }))
  }

  componentDidMount() {
    this.refresh(this.state.selectedDate);
  }

  render() {
    return (
      <div>
        <h2>Monthly Capitals</h2>
        <ChartistGraph className={'ct-octave'} data={this.state.chartData} type={'Line'} />
      </div>
    );
  }
}

export default Capital;
