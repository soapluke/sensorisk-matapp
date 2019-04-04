import axios from 'axios';
import { apiUrl } from '../constants/constants';

export const addFreetextAnswersToQuestionID = (freetextID, freetextAnswer) => ({
    type: 'ADD_FREETEXTANSWERS_TO_QUESTIONID',
    freetextID,
    freetextAnswer
});


export const fetchFreetextQuestionIDFromSurveyID = (freetextID) => ({
    type: 'FETCH_FREETEXTQUESTIONID_FROM_SURVEYID',
    freetextID
})

export const fetchFreetextQuestionIDFromSurveyIDFromApi = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/ViewSurvey/GetFreetextQuestionIDFromSurveyID/${id}`)
            .then(response => {
                dispatch(fetchFreetextQuestionIDFromSurveyID(response.data))
            })
            .catch(error => {
                throw (error);
            });
    };
};

export const addFreetextAnswersToSurveyByQuestionID = (freetextAnswers) => {
    return (dispatch) => {
        return axios.post(`${apiUrl}/SaveAnswers/AddFreetextAnswer`, {
            FreetextAnswers: freetextAnswers
        },
        {
            headers: { 'Content-Type': 'application/json' }
        }
        ).catch(error => {
            throw (error);
        });
    };
};