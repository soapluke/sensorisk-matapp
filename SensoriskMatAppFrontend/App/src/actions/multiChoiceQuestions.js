import axios from 'axios';
import { apiUrl } from '../constants/constants';

export const resetMultiChoiceQuestionState = () => ({
    type: 'RESET_MULTICHOICEQUESTION_STATE'
});

export const createMultiChoiceQuestion = (multiChoiceQuestion, options, chapter, ownOption, order) => ({
    type: 'CREATE_MULTICHOICEQUESTION',
    multiChoiceQuestion,
    options,
    chapter,
    ownOption,
    order
});

export const addMultiChoiceQuestionToSurvey = (multiChoiceQuestion, id) => {
    return (dispatch) => {
        console.log(multiChoiceQuestion)
        return axios.post(`${apiUrl}/MultichoiceQuestion/AddRange`, {
            SurveyID: id,
            Collection: multiChoiceQuestion
        },
            {
                headers: { 'Content-Type': 'application/json' }
            }
        ).catch(error => {
            throw (error);
        });
    }
};

export const deleteMultiChoiceQuestion = (multiChoiceQuestion) => ({
    type: 'DELETE_MULTICHOICEQUESTION',
    multiChoiceQuestion
});

export const editMultiChoiceQuestion = (oldQuestion, edits) => ({
    type: 'EDIT_MULTICHOICEQUESTION',
    oldQuestion,
    edits
});

//export const fetchAllMultiChoiceQuestions = (multiChoiceQuestions) => ({
//    type: 'FETCH_FREETEXTQUESTION',
//    multiChoiceQuestions
//});

//export const fetchAllMultiChoiceQuestionsBySurveyIdFromApi = (id) => {
//    return (dispatch) => {
//        return axios.get(`${apiUrl}/FreeTextQuestion/GetAllFreeTextQuestionFromSurvey/${id}`)
//            .then(response => {
//                dispatch(fetchAllFreeTextQuestions(response.data))
//            })
//            .catch(error => {
//                throw (error);
//            });
//    };
//};
