import React from 'react';
import { connect } from 'react-redux';
import { fetchCheckUser } from '../actions/login';
import { fetchCheckPassword } from '../actions/login';
import IconButton from '@material-ui/core/IconButton';
import Button from '@material-ui/core/Button';
import PersonIcon from '@material-ui/icons/Person';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import OutlinedInput from '@material-ui/core/OutlinedInput';
import FormHelperText from '@material-ui/core/FormHelperText';
import '../styles/content-container.css';

class LoginModal extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            password: '',
            erroruser: ' ',
            errorpassword: ' ',
            showModal: false
        };
    }

    handleOpen = () => {
        this.setState({ showModal: true });
    };
    handleCloseModal = () => {
        this.setState({ showModal: false });
    };
    onUserChange = (e) => {
        this.setState({ email: e.target.value, errorpassword: ' ', erroruser: ' ' });
    };
    onPasswordChange = (e) => {
        this.setState({ password: e.target.value, errorpassword: ' ', erroruser: ' '  });
    };

    enterLogin = (e) => {
        if (e.keyCode === 13) {
            this.onLogin()
        }
    }

    onLogin = async () => {
        if (this.state.password.length >= 5) {
            await this.props.fetchCheckUser(this.state.email).then(response => {
                if (response.data) {
                    this.checkPassword();
                    }
                    else {
                        this.setState({ erroruser: 'This email does not exsist' });
                    }
                }).catch(error => {
                    throw (error);
                });
            }
            else {
            this.setState(() => ({
                errorpassword: 'Your password must contain at least 5 character' }));
            }
    }

    checkPassword =  () => {
        this.props.fetchCheckPassword(this.state.email, this.state.password).then(response => {
            console.log(response);
            if (this.props.id) {

            }
            else {
                this.setState({ errorpassword: 'Wrong password' });
            }
        })
    }



    render() {
        return (
            <div>
                <IconButton onClick={this.handleOpen}>
                    <PersonIcon />
                </IconButton>
                <Dialog
                    fullWidth={true}
                    maxWidth="sm"
                    aria-labelledby="login-modal-title"
                    open={this.state.showModal}
                    onClose={this.handleCloseModal}
                >
                    <DialogTitle id="login-modal-title">Login</DialogTitle>
                    <DialogContent>
                        {this.state.erroruser && <FormHelperText className="search__error">{this.state.erroruser}</FormHelperText>}
                        <OutlinedInput
                            fullWidth={true}
                            type="text"
                            placeholder="Email"
                            autoFocus
                            labelWidth={0}
                            onChange={this.onUserChange}

                        />
                        {this.state.errorpassword && <FormHelperText className="search__error">{this.state.errorpassword}</FormHelperText>}
                        <OutlinedInput
                            fullWidth={true}
                            type="password"
                            placeholder="Password"
                            labelWidth={0}
                            onChange={this.onPasswordChange}
                            onKeyDown={this.enterLogin}
                        />
                        <DialogActions>
                            <Button variant="contained" onClick={this.onLogin}>Login</Button>
                        </DialogActions>
                    </DialogContent>
                </Dialog>

            </div>
        )
    }
};



const mapDispatchToProps = (dispatch) => ({
    fetchCheckUser: (id) => dispatch(fetchCheckUser(id)),
    fetchCheckPassword: (email, password) => dispatch(fetchCheckPassword(email, password)), 
});

export default connect(undefined, mapDispatchToProps)(LoginModal);
