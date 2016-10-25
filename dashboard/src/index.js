import React from 'react';
import ReactDOM from 'react-dom';
import { Router, Route, IndexRoute, browserHistory } from 'react-router'
import App from './App';
import Pnl from './Pnl';
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
  <Router history={browserHistory}>
    <Route path="/" component={AppContainer}>
      <IndexRoute component={App} />
      <Route path="/pnls" component={Pnl}/>
    </Route>
  </Router>,
  document.getElementById('root')
);
