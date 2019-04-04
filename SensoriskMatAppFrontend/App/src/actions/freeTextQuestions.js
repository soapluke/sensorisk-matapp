import axios from 'axios';
import { apiUrl } from '../constants/constants';


export const resetFreeTextQuestionState = () => ({
    type: 'RESET_FREETEXTQUESTION_STATE'
});

export const createFreeTextQuestion = (freeTextQuestion, chapter, order) => ({
    type: 'CREATE_FREETEXTQUESTION',
    freeTextQuestion,
    chapter,
    order
});

export const addFreeTextQuestionToSurvey = (question, id) => {
    return (dispatch) => {
        return axios.post(`${apiUrl}/FreeTextQuestion/AddRange`, {
            Question: question,
            SurveyID: id
        },
            {
                headers: { 'Content-Type': 'application/json' }
            }
        ).catch(error => {
            throw (error);
        });
    }
};

export const deleteFreeTextQuestion = (freeTextQuestion) => ({
    type: 'DELETE_FREETEXTQUESTION',
    freeTextQuestion
});

export const editFreeTextQuestion = (oldQuestion, edited) => ({
    type: 'EDIT_FREETEXTQUESTION',
    oldQuestion,
    edited
})

export const fetchAllFreeTextQuestions = (freeTextQuestions) => ({
    type: 'FETCH_FREETEXTQUESTION',
    freeTextQuestions
});

export const fetchAllFreeTextQuestionsBySurveyIdFromApi = (id) => {
    return (dispatch) => {
        return axios.get(`${apiUrl}/FreeTextQuestion/GetAllFreeTextQuestionFromSurvey/${id}`)
            .then(response => {
                dispatch(fetchAllFreeTextQuestions(response.data))
            })
            .catch(error => {
                throw (error);
            });
    };
};