import axios from 'axios';
import { apiUrl } from '../constants/constants';

export const addMultiAnswersToQuestionID = (multiID, options, ownOptions) => ({
    type: 'ADD_MULTIANSWERS_TO_QUESTIONID',
    multiID,
    options,
    ownOptions
});

export const fetchMultiQuestionIDFromSurveyID = (multiID) => ({
    type: 'FETCH_MULTIQUESTIONID_FROM_SURVEYID',
    multiID
})

export const fetchMultiQuestionIDFromSurveyIDFromApi = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/ViewSurvey/GetMultichoiceQuestionIDFromSurveyID/${id}`)
            .then(response => {
                dispatch(fetchMultiQuestionIDFromSurveyID(response.data))
            })
            .catch(error => {
                throw (error);
            });
    };
};

export const addMultiAnswersToSurveyByQuestionID = ( multiAnswers) => {
    return (dispatch) => {
        console.log(multiAnswers);
        return axios.post(`${apiUrl}/SaveAnswers/AddMultichoiceAnswer`, {
            MultichoiceAnswers: multiAnswers
        },
        {
            headers: { 'Content-Type': 'application/json' }
        }
        ).catch(error => {
            throw (error);
        });
    };
};