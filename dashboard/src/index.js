import React from 'react';
import ReactDOM from 'react-dom';
import { Router, Route, IndexRoute, hashHistory } from 'react-router'
import App from './App';
import Pnl from './Pnl';
import Capital from './Capital';
import DailyReturn from './DailyReturn';
import './index.css';

const AppContainer = React.createClass({
  render() {
    return (
      <div>
        {this.props.children}
      </div>
    )
  }
})

ReactDOM.render(
  <Router history={hashHistory}>
    <Route path="/" component={AppContainer}>
      <IndexRoute component={App} />
      <Route path="/pnls" component={Pnl}/>
      <Route path="/capitals" component={Capital}/>
      <Route path="/dailyreturns" component={DailyReturn}/>
    </Route>
  </Router>,
  document.getElementById('root')
);
