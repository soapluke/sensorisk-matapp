import { createStore, combineReducers, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';
import surveysReducer from '../reducers/surveys';
import freeTextQuestionsReducer from '../reducers/freeTextQuestions';
import multiChoiceQuestionsReducer from '../reducers/multiChoiceQuestion';
import chaptersReducer from '../reducers/chapters';
import viewSurveyReducer from '../reducers/viewsurvey';
import viewAnswersReducer from '../reducers/viewAnswers';
import submittedMultiAnswersReducer from '../reducers/submittedMultiAnswers';
import submittedFreetextAnswersReducer from '../reducers/submittedFreetextAnswers';
import surveyReducer from '../reducers/survey';
import organisationReducer from '../reducers/organisation';
import authReducer from '../reducers/auth';

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

export default () => {
    const store = createStore(
        combineReducers({
            surveys: surveysReducer,
            freeTextQuestions: freeTextQuestionsReducer,
            multiChoiceQuestions: multiChoiceQuestionsReducer,
            chapters: chaptersReducer,
            viewSurvey: viewSurveyReducer,
            viewAnswers: viewAnswersReducer,
            submittedMultiAnswers: submittedMultiAnswersReducer,
            submittedFreetextAnswers: submittedFreetextAnswersReducer,
            survey: surveyReducer,
            organisation: organisationReducer,
            auth: authReducer


        }),
        composeEnhancers(applyMiddleware(thunk))
    );

    return store;
};
