import React from 'react';
import { connect } from 'react-redux';
import { addChaptersAndQuestions } from '../actions/chapters';
import { createSurvey } from '../actions/surveys';
import SurveyForm from '../components/SurveyForm';
import QuestionForm from '../components/QuestionForm';
import { history } from '../router/AppRouter';
import Typography from '@material-ui/core/Typography';
import '../styles/content-container.css';

class CreateSurvey extends React.Component {

    onSubmitSurvey = async (survey) => {

        await this.props.createSurvey(survey, this.props.id)
            .then(async response => {
                await this.props.addChaptersAndQuestions(this.props.chapters, this.props.multiChoiceQuestions, this.props.freeTextQuestions, response.data).then(history.push('/submitted'));
            }).catch(error => {
                throw (error);
            });
    };

    render() {
        return (
            <div className="content-container">
                    <Typography variant="h4" gutterBottom>Create Survey</Typography>
                <div>
                    <SurveyForm onSubmit={this.onSubmitSurvey}/>
                    <QuestionForm />
                </div>
            </div>       
        );
    }
};

const mapStateToProps = (state) => ({
    // eslint-disable-next-line
    freeTextQuestions: state.freeTextQuestions,
    multiChoiceQuestions: state.multiChoiceQuestions,
    chapters: state.chapters,
    id : state.auth.id
});

const mapDispatchToProps = (dispatch) => ({
    createSurvey: (survey, id) => dispatch(createSurvey(survey, id)),
    addChaptersAndQuestions: (chapters, multichoiceQuestion, freetextQuestion, id) => dispatch(addChaptersAndQuestions(chapters, multichoiceQuestion, freetextQuestion, id))
});

export default connect(mapStateToProps, mapDispatchToProps)(CreateSurvey);