import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { history } from '../router/AppRouter';
import moment from 'moment'
import OptionsAnswer from '../components/OptionsAnswer';
import FreetextAnswer from '../components/FreetextAnswer';
import { fetchSurveyFromId } from '../actions/viewsurvey';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogTitle from '@material-ui/core/DialogTitle';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import '../styles/content-container.css';
import '../styles/viewsurvey.css';
import { resetFreeTextQuestionState } from '../actions/freeTextQuestions';
import { fetchAllChapterQuestionfromSurvey } from '../actions/viewsurvey';
import { fetchMultiQuestionIDFromSurveyIDFromApi, addMultiAnswersToSurveyByQuestionID } from '../actions/submittedMultiAnswers';
import { fetchFreetextQuestionIDFromSurveyIDFromApi, addFreetextAnswersToSurveyByQuestionID } from '../actions/submittedFreetextAnswers';

class ViewSurvey extends React.Component {
    state = {
        error: '',
        openConfirm: false
    };

    componentDidMount = async () => {
        await this.props.fetchSurveyFromId(this.props.match.params.id)
            .then(this.props.fetchAllChapterQuestionfromSurvey(this.props.match.params.id))
            .then(this.props.fetchMultiQuestionIDFromSurveyIDFromApi(this.props.match.params.id))
            .then(this.props.fetchFreetextQuestionIDFromSurveyIDFromApi(this.props.match.params.id));
    }

    componentWillUnmount() {
        this.props.resetFreeTextQuestionState();
    }

    handleClose = () => this.setState({ openConfirm: false })

    checkAnswers = () => {
            this.setState({ openConfirm: true })
    }

    onAnswerSubmit = () => {
            console.log(this.props.submittedFreetextAnswers);
            this.props.addFreetextAnswersToSurveyByQuestionID(this.props.submittedFreetextAnswers);
            this.props.addMultiAnswersToSurveyByQuestionID(this.props.submittedMultiAnswers);
            history.push('/submitted')
    }

    render() {
        return (
            <div className="content-container">
                {(this.props.id) &&
                    <div>
                        <Button variant="contained" className="viewsurvey__viewanswersbtn" component={Link} to={`/viewanswers/${this.props.match.params.id}`}>
                            View answers for this survey
                        </Button>
                    </div>
                }
                <Typography variant="h4">{this.props.survey.title}</Typography>
                <Typography variant="h5">{this.props.survey.description}</Typography>
                <Typography variant="h8">Code: {this.props.survey.code}</Typography>
                <Typography variant="h8">Start date: {moment(this.props.survey.startDate).format('MMMM DD YYYY, h:mm')}</Typography>
                <Typography variant="h8">End date: {moment(this.props.survey.endDate).format('MMMM DD YYYY, h:mm')}</Typography>
                {this.state.error && <p>{this.state.error}</p>}
                {
                    this.props.viewSurvey.map((chapter) => {
                        return (
                            <div className="content-container__view">
                                <Divider />
                                <Typography className="content-container__view-chapter" variant="h5" gutterBottom key={chapter.chapterID}>{chapter.title}</Typography>
                                        {
                                            chapter.allQuestion.map((question) => {
                                            return (
                                                <List
                                                    subheader={<Typography variant="h6">{question.question}</Typography>}
                                                >
                                                    <ListItem disableGutters={true} key={question.id}>
                                                        {
                                                            question.options === null ? (
                                                                <FreetextAnswer question={question} surveyID={this.props.match.params.id} />
                                                            ) : (
                                                                <OptionsAnswer question={question} surveyID={this.props.match.params.id} />
                                                            )
                                                        }
                                                    </ListItem>
                                                
                                                </List>
                                                )
                                            }
                                        )}
                            </div>
                        )
                    })
                }
                <Button variant="contained" onClick={this.checkAnswers}>
                    Done
                </Button>
                <Dialog
                    open={this.state.openConfirm}
                    onClose={this.handleClose}
                    aria-labelledby="alert-dialog-title"
                >
                    <DialogTitle id="alert-dialog-title">{"Are you sure you want to save the survey?"}</DialogTitle>
                    <DialogActions>
                        <Button onClick={this.handleClose} color="primary">
                            NO
                        </Button>
                        <Button onClick={this.onAnswerSubmit} color="primary" autoFocus>
                            YES
                        </Button>
                    </DialogActions>
                </Dialog>
            </div>
        );
    };
};

const mapStateToProps = (state, props) => ({
    // eslint-disable-next-line
    survey: state.survey,
    viewSurvey: state.viewSurvey,
    submittedMultiAnswers: state.submittedMultiAnswers,
    submittedFreetextAnswers: state.submittedFreetextAnswers,
    id: state.auth.id
});



const mapDispatchToProps = (dispatch) => ({
    fetchSurveyFromId: (id) => dispatch(fetchSurveyFromId(id)),
    fetchAllChapterQuestionfromSurvey: (id) => dispatch(fetchAllChapterQuestionfromSurvey(id)),
    resetFreeTextQuestionState: () => dispatch(resetFreeTextQuestionState()),
    fetchMultiQuestionIDFromSurveyIDFromApi: (id) => dispatch(fetchMultiQuestionIDFromSurveyIDFromApi(id)),
    fetchFreetextQuestionIDFromSurveyIDFromApi: (id) => dispatch(fetchFreetextQuestionIDFromSurveyIDFromApi(id)),
    addFreetextAnswersToSurveyByQuestionID: (submittedFreetextAnswers) => dispatch(addFreetextAnswersToSurveyByQuestionID(submittedFreetextAnswers)),
    addMultiAnswersToSurveyByQuestionID: (submittedMultiAnswers) => dispatch(addMultiAnswersToSurveyByQuestionID(submittedMultiAnswers))
});

export default connect(mapStateToProps, mapDispatchToProps)(ViewSurvey);