import axios from 'axios';
import { apiUrl } from '../constants/constants';


export const fetchAllAnswers = (allAnswers) => ({
    type: 'FETCH_ALLANSWERS',
    allAnswers
});

export const fetchAllAnswersBySurveyIdFromApi = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/ViewAnswers/GetAllAnswersFromSurvey/${id}`)
            .then(response => {
                dispatch(fetchAllAnswers(response.data))
            })
            .catch(error => {
                throw (error);
            });
    };
};
