import React from 'react';
import { connect } from 'react-redux';
import { fetchSurveyFromId } from '../actions/viewsurvey';
import moment from 'moment'
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import '../styles/content-container.css';
import { fetchAllAnswersBySurveyIdFromApi } from '../actions/viewAnswers';

class ViewAnswers extends React.Component {

    componentDidMount() {
        this.props.fetchSurveyFromId(this.props.match.params.id);
        this.props.fetchAllAnswersBySurveyIdFromApi(this.props.match.params.id);
    }


    render() {
        return (
            <div className="content-container">
                <Typography variant="h4">{this.props.survey.title}</Typography>
                <Typography variant="h5">{this.props.survey.description}</Typography>
                <Typography variant="h8">Code: {this.props.survey.code}</Typography>
                <Typography variant="h8">Start date: {moment(this.props.survey.startDate).format('MMMM DD YYYY, h:mm')}</Typography>
                <Typography variant="h8">End date: {moment(this.props.survey.endDate).format('MMMM DD YYYY, h:mm')}</Typography>
             {
                this.props.viewAnswers.map((answerChapter) => {
                        return (
                            <div className="content-container__view">
                                <Divider />
                                <Typography className="content-container__view-chapter" variant="h5" gutterBottom key={answerChapter.chapterID}>{answerChapter.title}</Typography>
                                
                                    {
                                        answerChapter.allAnswers.map((answer) => {
                                            return (
                                                <List
                                                    key={answer}
                                                    subheader={<Typography variant="h6">{answer.question}</Typography>}
                                                >
                                                        {
                                                            answer.optionsAnswersWithCount === null ? (
                                                                answer.freeTextAnswer.map((freeTextAnswer) => {
                                                                        return <ListItem as="h5">{freeTextAnswer}</ListItem>
                                                                })
                                                            ) : (
                                                                answer.optionsAnswersWithCount.map((option) => {
                                                                    return <ListItem as="h5">{option.key}: {option.value}</ListItem>
                                                                })
                                                            )
                                                        }
                                                </List>
                                            )
                                        }
                                   )}
                                
                        </div>
                    )
                })
            }
            </div>
        );
    };
};

const mapStateToProps = (state, props) => ({
    // eslint-disable-next-line
    survey: state.survey,
    viewAnswers: state.viewAnswers
});

const mapDispatchToProps = (dispatch) => ({
    fetchSurveyFromId: (id) => dispatch(fetchSurveyFromId(id)),
    fetchAllAnswersBySurveyIdFromApi: (id) => dispatch(fetchAllAnswersBySurveyIdFromApi(id))
});

export default connect(mapStateToProps, mapDispatchToProps)(ViewAnswers);