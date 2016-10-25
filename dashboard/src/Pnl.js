import React, { Component } from 'react';
import ChartistGraph from 'react-chartist';

const simpleLineChartData = {
  labels: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday'],
  series: [
    [12, 9, 7, 8, 5],
    [2, 1, 3.5, 7, 3],
    [1, 3, 4, 5, 6]
  ]
}

class Pnl extends Component {
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
        <ChartistGraph data={simpleLineChartData} type={'Line'} />
      </div>
    );
  }
}

export default Pnl;
