import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import CampanhaApi from './Api/CampanhaApi';
import Table from './Components/Table/Table.jsx';

class App extends Component {
  constructor() {
    super();
    this.state = {
      childs: []
    }
    this.campanhaApi = new CampanhaApi();
  }

  componentDidMount() {
    this.getChild();
  }

  getChild() {
    this.setState({ childs: this.campanhaApi.list() });
    // .then(data => this.setState({
    //   childs: data
    // }))
    // .catch(console.error);
  }

  render() {
    return (
      <div>
        <nav className="light-blue lighten-1">
          <div class="nav-wrapper">
            <a href="#!" class="brand-logo"><i class="material-icons">cloud</i>Logo</a>
            <ul id="nav-mobile" class="right hide-on-med-and-down">
              <li><a href="sass.html">Sass</a></li>
              <li><a href="badges.html">Components</a></li>
              <li><a href="collapsible.html">JavaScript</a></li>
            </ul>
          </div>
        </nav>
        <div className="container">
          <h2 class="header">Campanha 2018</h2>
          <div class="card">
            <div class="card-content">
              <Table childs={this.state.childs}></Table>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default App;
