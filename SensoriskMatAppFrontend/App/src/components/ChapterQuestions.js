import React from 'react';
import { connect } from 'react-redux';
import { deleteQuestionFromChapter } from '../actions/chapters';
import { deleteMultiChoiceQuestion } from '../actions/multiChoiceQuestions';
import { deleteFreeTextQuestion } from '../actions/freeTextQuestions';
import EditQuestionModal from '../components/EditQuestionModal';
import Typography from '@material-ui/core/Typography';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import IconButton from '@material-ui/core/IconButton';
import Divider from '@material-ui/core/Divider';
import DeleteIcon from '@material-ui/icons/Delete';
import '../styles/createsurvey.css';

class ChapterQuestions extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            showModal: false
        };
    };

    handleDeleteQuestion = (chapterID, questionIndex, question, checkQuestionType) => {
        this.props.deleteQuestionFromChapter(chapterID, questionIndex);
        if (checkQuestionType.length === 0) {
            this.props.deleteFreeTextQuestion(question);
        } else {
            this.props.deleteMultiChoiceQuestion(question);
        }
    };

    handleOpenModal = () => {
        this.setState({ showModal: true });
    };

    handleCloseModal = () => {
        this.setState({ showModal: false });
    };

    


    render() {
        return (
            <div>
                {this.props.chapters[this.props.chapterID - 1].questions.length === 0 ? (
                    <p>No questions.</p>
                ) : (
                        this.props.chapters[this.props.chapterID - 1].questions.map((question, i) => {
                            return (
                                <div>
                                    <Divider />
                                    <IconButton className="createsurvey__deletequestionbtn"
                                        aria-label="Delete"
                                        onClick={(e) => {
                                            e.preventDefault();
                                            this.handleDeleteQuestion(this.props.chapterID, i, question.question, question.options);
                                        }}>
                                        <DeleteIcon />
                                    </IconButton>
                                    <EditQuestionModal
                                        chapterID={this.props.chapterID}
                                        questionIndex={i}
                                        question={question.question}
                                        options={question.options}
                                        ownOption={question.ownOption}
                                    />
                                    <List
                                        key={question[i]}
                                        subheader={<Typography variant="h6">{question.question}</Typography>}
                                    >
                                        {
                                            question.options.length === 0 ? (
                                                <ListItem></ListItem>
                                            ) : (
                                            question.options.map((option) => {
                                                return <ListItem key={option}>{option}</ListItem>
                                            })
                                        )}
                                    </List>
                                    
                                </div>
                            );
                        })
                    )}

            </div>
        );
    }
}

const mapStateToProps = (state, props) => ({
    // eslint-disable-next-line
    chapters: state.chapters
});

const mapDispatchToProps = (dispatch) => ({
    deleteQuestionFromChapter: (chapterID, questionIndex) => dispatch(deleteQuestionFromChapter(chapterID, questionIndex)),
    deleteMultiChoiceQuestion: (multiChoiceQuestion) => dispatch(deleteMultiChoiceQuestion(multiChoiceQuestion)),
    deleteFreeTextQuestion: (freeTextQuestion) => dispatch(deleteFreeTextQuestion(freeTextQuestion))
});

export default connect(mapStateToProps, mapDispatchToProps)(ChapterQuestions);