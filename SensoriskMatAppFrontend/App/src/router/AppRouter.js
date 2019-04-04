
import React from 'react';
import { Route, Router, Switch } from 'react-router-dom';
import createHistory from 'history/createBrowserHistory';
import CreateSurvey from '../components/CreateSurvey';
import ViewSurvey from '../components/ViewSurvey';
import ViewAnswers from '../components/ViewAnswers';
import Home from '../components/Home';
import Header from '../components/Header';
import ConfirmedSubmitted from '../components/ConfirmedSubmitted';
import ProfilePage from '../components/ProfilePage';
import PrivateRouter from './PrivateRouter';
import PublicRouter from './PublicRouter';

export const history = createHistory();

const AppRouter = () => (
    <Router history={history}>
        <div>
            <Header />
            <Switch>
                <PublicRouter exact path="/" component={Home} />
                <PrivateRouter path="/createsurvey" component={CreateSurvey} />
                <Route path="/view/:id" component={ViewSurvey} />
                <PrivateRouter path="/viewanswers/:id" component={ViewAnswers} />
                <Route path="/submitted" component={ConfirmedSubmitted} />
                <PrivateRouter path="/profile" component={ProfilePage} />
                </Switch>
        </div>
    </Router>
);

export default AppRouter;
