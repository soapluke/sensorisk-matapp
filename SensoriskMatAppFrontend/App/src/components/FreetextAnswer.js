import React from 'react';
import { connect } from 'react-redux';
import TextField from '@material-ui/core/TextField';
import '../styles/viewsurvey.css';
import '../styles/content-container.css';
import { addFreetextAnswersToQuestionID } from '../actions/submittedFreetextAnswers';

class FreetextAnswer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            freetextAnswer: '',
            disabled: false
        };
    }

    componentDidMount() {
        if (this.props.id) {
            this.setState({ disabled: true })
        }
    }

    handleOnChange = async (e) => {
        const freetextAnswer = e.target.value;
        await this.setState(() => ({ freetextAnswer }));
        this.props.addFreetextAnswersToQuestionID(this.props.question.id, this.state.freetextAnswer);
    }

    render() {
        return (
            <TextField
                fullWidth={true}
                multiline
                rows="4"
                variant="outlined"
                onChange={this.handleOnChange}
                placeholder='Try adding multiple lines eller nå'
                disabled={this.state.disabled}
            />
        );
    }
}

const mapStateToProps = (state, props) => ({
    id: state.auth.id
});

const mapDispatchToProps = (dispatch) => ({
    addFreetextAnswersToQuestionID: (questionID, freetextAnswer) => dispatch(addFreetextAnswersToQuestionID(questionID, freetextAnswer))
});

export default connect(mapStateToProps, mapDispatchToProps)(FreetextAnswer);