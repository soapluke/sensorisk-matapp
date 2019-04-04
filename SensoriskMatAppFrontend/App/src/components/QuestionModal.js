import React from 'react';
import { connect } from 'react-redux';
import { createFreeTextQuestion } from '../actions/freeTextQuestions';
import { createMultiChoiceQuestion } from '../actions/multiChoiceQuestions';
import { addFreeTextQuestionToChapter, addMultiChoiceQuestionToChapter } from '../actions/chapters';
import Button from '@material-ui/core/Button';
import OutlinedInput from '@material-ui/core/OutlinedInput';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import QuestionModalContentMultiChoice from '../components/QuestionModalContentMultiChoice';
import '../styles/createsurvey.css';

class QuestionModal extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            currentQuestion: '',
            currentOption: '',
            multiChoiceOptions: [],
            questionType: 0,
            questionOrder: 0,
            ownOption: false,
            showModal: false
        };
    };

    handleDropdownChange = async (event) => {
        await this.setState({ questionType: event.target.value });
    };

    handleOpenModal = () => {
        this.setState({ showModal: true });
    };

    handleCloseModal = () => {
        this.setState({ showModal: false });
    };

    handleCheckToggle = () => {
        this.setState({ checked: !this.state.checked });
    };

    onQuestionChange = (e) => {
        const currentQuestion = e.target.value;
        this.setState(() => ({ currentQuestion }));
    };

    onOptionChange = (e) => {
        const currentOption = e.target.value;
        this.setState(() => ({ currentOption }));
    };

    onDeleteOption = (option) => {
        let filteredState = this.state.multiChoiceOptions.filter(item => item !== option);

        this.setState({ multiChoiceOptions: filteredState });
    };

    onOptionSubmit = (multiChoiceOptions, ownOption) => {
        this.setState({
            multiChoiceOptions,
            ownOption
        });
    };

    onQuestionSubmit = async () => {

        await this.setState({ questionOrder: this.state.questionOrder + 1 });
        console.log(this.state.multiChoiceOptions);
        if (this.state.questionType === 1) {
            this.props.createFreeTextQuestion(this.state.currentQuestion, this.props.chapterID, this.state.questionOrder);
            this.props.addFreeTextQuestionToChapter(this.state.currentQuestion, this.props.chapterID, this.state.multiChoiceOptions);
        } else if (this.state.questionType === 2) {
            this.props.createMultiChoiceQuestion(this.state.currentQuestion, this.state.multiChoiceOptions, this.props.chapterID, this.state.ownOption, this.state.questionOrder);
            this.props.addMultiChoiceQuestionToChapter(this.state.currentQuestion, this.state.multiChoiceOptions, this.state.ownOption, this.props.chapterID);
        }

        await this.setState({
            multiChoiceOptions: [],
            showModal: false
        });
    };

    render() {

        return (
            <div>
                <Button className="createsurvey__addquestionbtn" variant="contained" onClick={this.handleOpenModal}>Add Question</Button>
                <Dialog
                    fullWidth={true}
                    maxWidth="sm"
                    aria-labelledby="question-modal-title"
                    open={this.state.showModal}
                    onClose={this.handleCloseModal}
                >
                    <DialogTitle id="question-modal-title">Add a question to the survey</DialogTitle>
                    <DialogContent>
                        <FormControl variant="outlined">
                            <Select
                                className="createsurvey__selectquestion"
                                autoWidth={true}
                                value={this.state.questionType}
                                onChange={this.handleDropdownChange}
                                input={<OutlinedInput
                                    labelWidth={0}
                                    name="age"
                                    id="outlined-questions"
                                />}
                            >
                                <MenuItem value={0}>Question type</MenuItem>
                                <MenuItem value={1}>Free text question</MenuItem>
                                <MenuItem value={2}>Multi choice question</MenuItem>
                            </Select>
                        </FormControl>
                        <OutlinedInput
                            type="text"
                            placeholder="Enter question..."
                            labelWidth={0}
                            autoFocus
                            onChange={this.onQuestionChange}
                        />
                        {
                            this.state.questionType === 2 &&
                            <QuestionModalContentMultiChoice onDeleteOption={this.onDeleteOption} onOptionSubmit={this.onOptionSubmit} />
                        }
                        <DialogActions>
                            <Button variant="contained" onClick={this.onQuestionSubmit}>OK</Button>
                        </DialogActions>
                    </DialogContent>
                </Dialog>
            </div>
        );
    };
}

const mapDispatchToProps = (dispatch) => ({
    createFreeTextQuestion: (freeTextQuestion, chapter, order) => dispatch(createFreeTextQuestion(freeTextQuestion, chapter, order)),
    createMultiChoiceQuestion: (multiChoiceQuestion, options, chapter, ownOption, order) => dispatch(createMultiChoiceQuestion(multiChoiceQuestion, options, chapter, ownOption, order)),
    addFreeTextQuestionToChapter: (freeTextQuestion, chapter, options) => dispatch(addFreeTextQuestionToChapter(freeTextQuestion, chapter, options)),
    addMultiChoiceQuestionToChapter: (multiChoiceQuestion, options, ownOption, chapter) => dispatch(addMultiChoiceQuestionToChapter(multiChoiceQuestion, options, ownOption, chapter))
});

export default connect(undefined, mapDispatchToProps)(QuestionModal);