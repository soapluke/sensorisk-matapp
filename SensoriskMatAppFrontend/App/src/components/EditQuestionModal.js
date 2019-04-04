import React from 'react';
import { connect } from 'react-redux';
import { editQuestionInChapter } from '../actions/chapters';
import { editFreeTextQuestion } from '../actions/freeTextQuestions';
import { editMultiChoiceQuestion } from '../actions/multiChoiceQuestions';
import Button from '@material-ui/core/Button';
import OutlinedInput from '@material-ui/core/OutlinedInput';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import ClearIcon from '@material-ui/icons/Clear';
import IconButton from '@material-ui/core/IconButton';
import EditIcon from '@material-ui/icons/Edit';
import Divider from '@material-ui/core/Divider';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import Checkbox from '@material-ui/core/Checkbox';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import '../styles/createsurvey.css';

class EditQuestionModal extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            showModal: false,
            currentQuestion: props.question,
            currentOption: '',
            multiChoiceOptions: props.options,
            ownOption: props.ownOption
        };
    };

    //componentDidMount() {
    //    this.setState({
    //        multiChoiceOptions: this.props.options,
    //        currentQuestion: this.props.question,
    //        ownOption: this.props.ownOption
    //    });
    //};

    //componentWillUnmount() {
    //    this.setState({
    //        currentQuestion: '',
    //        multiChoiceOptions: [],
    //        ownOption: undefined
    //    });
    //}

    handleOpenModal = () => {
        this.setState({ showModal: true });
    };

    handleCloseModal = () => {
        this.setState({ showModal: false });
    };

    handleCheckOwnOption = () => {
        this.setState({ ownOption: !this.state.ownOption });
    };

    onQuestionChange = (e) => {
        const currentQuestion = e.target.value;
        this.setState(() => ({ currentQuestion }));
    };

    onOptionChange = (e) => {
        const currentOption = e.target.value;
        this.setState(() => ({ currentOption }));
    };

    onOptionSubmit = async () => {
        await this.setState({ multiChoiceOptions: [...this.state.multiChoiceOptions, this.state.currentOption] });
        await this.setState({ currentOption: '' });
    };

    onDeleteOption = (option) => {
        let filteredState = this.state.multiChoiceOptions.filter(item => item !== option);

        this.setState({ multiChoiceOptions: filteredState });
    };

    onEditSubmit = () => {

        //await this.setState({ questionOrder: this.state.questionOrder + 1 });
        //console.log(this.state.multiChoiceOptions);
        //if (this.state.questionType === 1) {
        //    this.props.createFreeTextQuestion(this.state.currentQuestion, this.props.chapterID, this.state.questionOrder);
        //    this.props.addFreeTextQuestionToChapter(this.state.currentQuestion, this.props.chapterID, this.state.multiChoiceOptions);
        //} else if (this.state.questionType === 2) {
        //    this.props.createMultiChoiceQuestion(this.state.currentQuestion, this.state.multiChoiceOptions, this.props.chapterID, this.state.ownOption, this.state.questionOrder);
        //    this.props.addMultiChoiceQuestionToChapter(this.state.currentQuestion, this.state.multiChoiceOptions, this.state.ownOption, this.props.chapterID);
        //}

        this.props.editQuestionInChapter(this.props.chapterID, this.props.questionIndex, {
            question: this.state.currentQuestion,
            options: this.state.multiChoiceOptions,
            ownOption: this.state.ownOption
        });

        if (this.state.multiChoiceOptions.length === 0) {
            this.props.editFreeTextQuestion(this.props.question, this.state.currentQuestion);
        } else {
            this.props.editMultiChoiceQuestion(this.props.question, {
                question: this.state.currentQuestion,
                options: this.state.multiChoiceOptions,
                ownOption: this.state.ownOption
            });
        }
        
        this.handleCloseModal();
    };

    render() {

        return (
            <div>
                <IconButton className="createsurvey__editquestionbtn"
                    aria-label="Edit"
                    onClick={(e) => {
                        e.preventDefault();
                        this.handleOpenModal();
                    }}>
                    <EditIcon />
                </IconButton>
                <Dialog
                    fullWidth={true}
                    maxWidth="sm"
                    aria-labelledby="editquestion-modal-title"
                    open={this.state.showModal}
                    onClose={this.handleCloseModal}
                >
                    <DialogTitle id="editquestion-modal-title">Edit question</DialogTitle>
                    <DialogContent>
                        <OutlinedInput
                            type="text"
                            value={this.state.currentQuestion}
                            labelWidth={0}
                            autoFocus
                            onChange={this.onQuestionChange}
                        />
                        {
                            this.props.options.length > 0 &&
                            <div>
                                <FormControlLabel
                                    control={
                                        <Checkbox
                                            onChange={this.handleCheckOwnOption}
                                            checked={this.state.ownOption}
                                        />
                                    }
                                    label={"Should respondants be able to add their own option?"}
                                />
                                <FormControlLabel
                                    control={
                                        <Checkbox
                                            //onChange={this.handleCheckOneOption}
                                            //checked={this.state.oneOption}
                                        />
                                    }
                                    label={"The respondants can only choose one option"}
                                />
                                <OutlinedInput
                                    type="text"
                                    placeholder="Enter new option..."
                                    autoFocus
                                    labelWidth={0}
                                    onChange={this.onOptionChange}
                                    value={this.state.currentOption}
                                />
                                    <Button className="createsurvey__addoptionbtn" variant="contained" onClick={this.onOptionSubmit}>Add option</Button>
                                <List>
                                    {
                                        this.state.multiChoiceOptions.map((option) => {
                                            return (
                                                <div>
                                                    <ListItem key={option}>
                                                        <ListItemText primary={option} />
                                                        <ListItemSecondaryAction>
                                                            <IconButton
                                                                value={option}
                                                                onClick={(e) => {
                                                                    e.preventDefault();
                                                                    this.onDeleteOption(option);
                                                                }}>
                                                                <ClearIcon />
                                                            </IconButton>
                                                        </ListItemSecondaryAction>
                                                    </ListItem>
                                                    <Divider />
                                                </div>
                                            );
                                        })
                                    }
                                </List>
                            </div>
                        }
                        <DialogActions>
                            <Button variant="contained" onClick={this.onEditSubmit}>OK</Button>
                        </DialogActions>
                    </DialogContent>
                </Dialog>
            </div>
        );
    };
}

const mapStateToProps = (state, props) => ({
    // eslint-disable-next-line
});

const mapDispatchToProps = (dispatch) => ({
    editQuestionInChapter: (chapterID, questionIndex, edits) => dispatch(editQuestionInChapter(chapterID, questionIndex, edits)),
    editFreeTextQuestion: (oldQuestion, edited) => dispatch(editFreeTextQuestion(oldQuestion, edited)),
    editMultiChoiceQuestion: (oldQuestion, edits) => dispatch(editMultiChoiceQuestion(oldQuestion, edits))
});

export default connect(mapStateToProps, mapDispatchToProps)(EditQuestionModal);
