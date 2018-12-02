import React, { Component } from 'react';
import logo from './../../logo.svg';

export default class Header extends Component {
    render() {
        return (
            <nav className="white black-text">
                <logo></logo>
            </nav>
        );
    }
}