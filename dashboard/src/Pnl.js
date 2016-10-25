import React, { Component } from 'react';
import ChartistGraph from 'react-chartist';

function checkStatus(response) {
  if (response.status >= 200 && response.status < 300) {
    return response;
  } else {
    const error = new Error(`HTTP Error ${response.statusText}`);
    error.status = response.statusText;
    error.response = response;
    console.log(error); // eslint-disable-line no-console
    throw error;
  }
}

function parseJSON(response) {
  return response.json();
}

class Pnl extends Component {
  constructor(props) {
    super(props);
    this.state = {
      chartData : { labels: [], series: [] }
    };
  }

  changeContent = (data) => {
    console.log(data);
    this.setState({chartData: data})
  }

  refresh(cb) {
    fetch('http://localhost:2774/api/pnls/2010-05-30', {
      accept: 'application/json',
    }).then(checkStatus)
      .then(parseJSON)
      .then(function (data){
        cb(data);
    })
  }

  componentDidMount() {
    this.refresh(this.changeContent);
    // this.setState({chartData : {
    //   labels: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'],
    //   series: [
    //     [12, 9, 7, 8, 5],
    //     [2, 1, 3.5, 7, 3],
    //     [1, 3, 4, 5, 6]
    //   ]}
    // });
  }

  render() {
    return (
      <div>
        <h2>Cumulative P&amp;L By Region</h2>

        <div>
            <select id="selDate">
                <option selected="selected" value="2010-03-31">2010 1st Quarter</option>
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
        <ChartistGraph data={this.state.chartData} type={'Line'} />

      </div>
    );
  }
}

export default Pnl;
