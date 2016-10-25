import React, { Component } from 'react';
import { Link } from 'react-router'
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <h1>Dashboard</h1>
        <div className="row">
            <div className="col-md-4">
                <h3>Cumulative P&L</h3>
                <p><Link to="/pnls" className="btn btn-default">P &amp; L &raquo;</Link></p>
            </div>
            <div className="col-md-4">
                <h3>Monthly Capital Values</h3>
                <p><Link to="/capitals" className="btn btn-default">Capitals &raquo;</Link></p>
            </div>
            <div className="col-md-4">
                <h3>Daily Returns</h3>
                <p><Link to="/returns" className="btn btn-default">Daily Returns &raquo;</Link></p>
            </div>
        </div>
      </div>
    );
  }
}

export default App;
