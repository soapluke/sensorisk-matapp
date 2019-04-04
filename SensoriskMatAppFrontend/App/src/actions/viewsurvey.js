import axios from 'axios';
import { apiUrl } from '../constants/constants';


export const fetchAllChapterQuestion = (chapterQuestion) => ({
    type: 'FETCH_CHAPTERQUESTION',
    chapterQuestion
});

export const fetchAllChapterQuestionfromSurvey = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/ViewSurvey/GetAllQuestionChapterFromSurvey/${id}`)
            .then(response => {
                dispatch(fetchAllChapterQuestion(response.data))
            })
            .catch(error => {
                throw (error);
            });
    };
};


export const fetchSurvey = (survey) => ({
    type: 'FETCH_SURVEY',
    survey
});

export const fetchSurveyFromId = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/ViewSurvey/GetAllSurveyFromId/${id}`)
            .then(response => {
                dispatch(fetchSurvey(response.data))
            })
            .catch(error => {
                throw (error);
            });
    };
};