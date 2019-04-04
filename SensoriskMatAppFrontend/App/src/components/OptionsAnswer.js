import React from 'react';
import { connect } from 'react-redux';
import Checkbox from '@material-ui/core/Checkbox';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import ListItem from '@material-ui/core/ListItem';
import OutlinedInput from '@material-ui/core/OutlinedInput';
import FormControl from '@material-ui/core/FormControl';
import FormHelperText from '@material-ui/core/FormHelperText';
import '../styles/checkbox.css';
import { addMultiAnswersToQuestionID } from '../actions/submittedMultiAnswers';

class OptionsAnswer extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            options: [],
            ownOptions: [],
            disabled: false
        };
    }

    componentDidMount() {
        if (this.props.id) {
            this.setState({ disabled: true })
        }
    }

    handleOnChange = async (option) => {
        if (this.state.options.includes(option)) {
            let filteredState = this.state.options.filter(item => item !== option);
            await this.setState({ options: filteredState })
            this.props.addMultiAnswersToQuestionID(this.props.question.id, this.state.options, this.state.ownOptions);
        } else {
            await this.setState({ options: [...this.state.options, option] });
            this.props.addMultiAnswersToQuestionID(this.props.question.id, this.state.options, this.state.ownOptions);
        }
    }

    handleOwnOption = async (e) => {
        if (e.charCode === 13) {
            await this.setState({ ownOptions: [...this.state.ownOptions, e.target.value ]})
            this.props.addMultiAnswersToQuestionID(this.props.question.id, this.state.options, this.state.ownOptions);
        }
    }

    render() {
        return (
            <div>
                {
                    this.props.question.options.map((option) => {
                        return (
                            <ListItem key={option.id}>
                                <FormControlLabel
                                    control={
                                        <Checkbox
                                            className="checkbox__optionsanswer"
                                            onChange={() => this.handleOnChange(option)}
                                            checked={this.state.options.includes(option)}
                                            disabled={this.state.disabled}
                                        />
                                    }
                                    label={option.option}
                                />
                            </ListItem>
                        )
                    })
                }
                {
                    this.state.ownOptions.map((ownOption) => {
                        return <ListItem disableGutters key={ownOption}>{ownOption}</ListItem>
                    }
                )}
                {(this.props.question.ownOption) &&
                    <div>
                        <FormControl>
                            <OutlinedInput
                                onKeyPress={this.handleOwnOption}
                                placeholder='Eget alternativ'
                                labelWidth={0}
                                disabled={this.state.disabled}
                            
                            />
                            <FormHelperText id="component-helper-text">Press enter to add!</FormHelperText>
                        </FormControl>
                    </div>
                }
            </div>
    )};
};
const mapStateToProps = (state, props) => ({
    id: state.auth.id
});


const mapDispatchToProps = (dispatch) => ({
    addMultiAnswersToQuestionID: (multiID, options, ownOptions) => dispatch(addMultiAnswersToQuestionID(multiID, options, ownOptions)),
});

export default connect(mapStateToProps, mapDispatchToProps)(OptionsAnswer);