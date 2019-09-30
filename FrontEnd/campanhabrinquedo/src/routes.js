import React from 'react';
import Layout from './Components/Layout/Layout';

const Dashboard = React.lazy(() => import('./Pages/Dashboard/Dashboard'));
const SignIn = React.lazy(() => import('./Pages/SignIn/SignIn'));
const Child = React.lazy(() => import('./Pages/Child/Child'));

const routes = [
    { path: '/', exact: true, name: 'Home', component: Layout },
    { path: '/dashboard', name: 'Dashboard', component: Dashboard },
    { path: '/signin', name: 'SignIn', component: SignIn },
    { path: '/child', name: 'Child', component: Child }
];

export default routes;