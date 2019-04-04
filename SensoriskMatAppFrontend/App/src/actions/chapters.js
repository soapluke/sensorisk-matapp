import axios from 'axios';
import { apiUrl } from '../constants/constants';

export const createChapter = (chapterName, id) => ({
    type: 'CREATE_CHAPTER',
    chapterName,
    id
});

export const addFreeTextQuestionToChapter = (question, chapterID, options) => ({
    type: 'ADD_FREETEXTQUESTION_TO_CHAPTER',
    question,
    chapterID,
    options
});

export const addMultiChoiceQuestionToChapter = (question, options, ownOption, chapterID, order) => ({
    type: 'ADD_MULTICHOICEQUESTION_TO_CHAPTER',
    question,
    options,
    ownOption,
    chapterID,
    order
});

export const addChaptersAndQuestions = (chapters, multichoiceQuestion, freetextQuestion, id) => {
    return (dispatch) => {
        return axios.post(`${apiUrl}/Survey/AddChapter`, {
            ChaptersModel: chapters,
            MultiChoiceQModel: multichoiceQuestion,
            FreetextQModel: freetextQuestion,
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

export const editQuestionInChapter = (chapterID, questionIndex, edits) => ({
    type: 'EDIT_QUESTION_IN_CHAPTER',
    chapterID,
    questionIndex,
    edits
});

export const deleteQuestionFromChapter = (chapterID, questionIndex) => ({
    type: 'DELETE_QUESTION_FROM_CHAPTER',
    chapterID,
    questionIndex
});