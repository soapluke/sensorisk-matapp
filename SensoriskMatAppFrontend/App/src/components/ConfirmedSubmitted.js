import React from 'react';
import { history } from '../router/AppRouter';
import { connect } from 'react-redux';
import Typography from '@material-ui/core/Typography';
import CheckIcon from '@material-ui/icons/Check';
import '../styles/content-container.css';
import '../styles/submitted.css';

class ConfirmedSubmitted extends React.Component {
    componentDidMount() {
        this.timeoutHandle = setTimeout(() => {
            if(this.props.id){
                history.push('profile');
            }else {
                history.push('/');
            }
        }, 3000);
    }

    componentWillUnmount() {
        clearTimeout(this.timeoutHandle); 
    }


    render() {
        return (
            <div className="content-container">
                <div className="submitted__thank">
                    <CheckIcon className="submitted__icon"/>
                    <Typography variant="h3" align="center" >Thank you!</Typography>
                </div>
            </div>
        )
    }
};

const mapStateToProps = (state, props) => ({
    id: state.auth.id

});

export default connect(mapStateToProps, undefined)(ConfirmedSubmitted);