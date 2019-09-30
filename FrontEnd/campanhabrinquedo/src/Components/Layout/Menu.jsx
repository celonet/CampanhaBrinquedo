import React from 'react';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import DashboardIcon from '@material-ui/icons/Dashboard';
import PeopleIcon from '@material-ui/icons/People';
import { Link } from "react-router-dom";

const mainListItems = (
    <div>
        <ListItem button>
            <ListItemIcon>
                <Link to="/">
                    <DashboardIcon />
                </Link>
            </ListItemIcon>
            <ListItemText primary="Dashboard" />
        </ListItem>
        <ListItem button>
            <ListItemIcon>
                <Link to="/child">
                    <PeopleIcon />
                </Link>
            </ListItemIcon>
            <ListItemText primary="Child" />
        </ListItem>
    </div>
);

export default mainListItems;