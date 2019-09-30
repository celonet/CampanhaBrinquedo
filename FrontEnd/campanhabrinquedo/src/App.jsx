import React, { Component } from 'react';
import { Route, Switch, BrowserRouter } from 'react-router-dom';
import Loadable from 'react-loadable';
import './App.css';
import Layout from './Components/Layout/Layout';

const loading = () => <div className="animated fadeIn pt-3 text-center">Loading...</div>;

// Containers
const Dashboard = Loadable({
  loader: () => import('./Pages/Dashboard/Dashboard'),
  loading
});

// Pages
const Login = Loadable({
  loader: () => import('./Pages/SignIn/SignIn'),
  loading
});

const Register = Loadable({
  loader: () => import('./Pages/Register/Register'),
  loading
});

const Page404 = Loadable({
  loader: () => import('./Pages/Page404/Page404'),
  loading
});

const Page500 = Loadable({
  loader: () => import('./Pages/Page500/Page500'),
  loading
});

const Child = Loadable({
  loader: () => import('./Pages/Child/Child'),
  loading
})

class App extends Component {

  render() {
    return (
      <BrowserRouter>
        <Layout>
          <Switch>
            <Route path="/" exact={true} name="Home" component={Dashboard} />
            <Route path="/login" name="Login Page" component={Login} />
            <Route path="/register" name="Register Page" component={Register} />
            <Route path="/404" name="Page 404" component={Page404} />
            <Route path="/500" name="Page 500" component={Page500} />
            <Route path="/child" name="Child" component={Child} />
          </Switch>
        </Layout>
      </BrowserRouter>
    );
  }
}

export default App;
