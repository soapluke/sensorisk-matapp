import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { history } from '../router/AppRouter';
import { logout } from '../actions/logOut';
import LoginModel from '../components/LoginModal';
import IconButton from '@material-ui/core/IconButton';
import PersonIcon from '@material-ui/icons/Person';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import Typography from '@material-ui/core/Typography';

import '../styles/header.css'

class Header extends React.Component {
    componentDidUpdate() {
        history.push('/profile')
    }

    handleLogout = async () => {
        await this.props.logout();
}
    render() {
        return (
            <header>
                <div className="header__main">
                    <Typography className="header__title" variant="h2" align="center">Sensorisk Matapp</Typography>
                        {this.props.id ? (
                        <div className="header__content">
                            <IconButton component={Link} to="/createsurvey" className="header__option">
                                    Create Survey
                                </IconButton>
                                <div>
                                    <IconButton component={Link} to="/profile">
                                        <PersonIcon />
                                    </IconButton>
                                    <IconButton onClick={this.handleLogout}>
                                        <ExitToAppIcon />
                                    </IconButton>
                                </div>
                                
                            </div>
                        ) : (
                                <div className= "header__content">
                                    <Typography component={Link} to="/" className="header__option" variant="h3">Home</Typography>
                                    <LoginModel />
                                </div>
                                )
                        }
                </div>
            </header>
        );
    }
};

const mapStateToProps  =  (state) => ({
     id: state.auth.id
});

const mapDispatchToProps = (dispatch) => ({
    logout: () => dispatch(logout())
});
export default connect(mapStateToProps, mapDispatchToProps)(Header);