﻿import React from 'react';
import { connect } from 'react-redux';
import { Route, Redirect } from 'react-router-dom';

export const PrivateRouter = ({ isAuthenticated, component: Component, ...rest }) => (
    <Route {...rest} component={(props) => (
        isAuthenticated ? (
            <div>
                <Component {...props} />
            </div>
        ) : (
                <Redirect to="/" />
            )
    )} />
);

const mapStateToProps = (state) => ({
    isAuthenticated: !!state.auth.id
});

export default connect(mapStateToProps, undefined)(PrivateRouter);