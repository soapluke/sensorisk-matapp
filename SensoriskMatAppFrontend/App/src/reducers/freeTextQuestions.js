const freeTextQuestionDefaultState = [];

export default (state = freeTextQuestionDefaultState, action) => {
    switch (action.type) {
        case 'CREATE_FREETEXTQUESTION':
            return [
                ...state,
                {
                    question: action.freeTextQuestion,
                    chapterID: action.chapter,
                    order: action.order
                }
            ];
        case 'FETCH_FREETEXTQUESTION':
            return action.freeTextQuestions;
        case 'RESET_FREETEXTQUESTION_STATE':
            return freeTextQuestionDefaultState;
        case 'EDIT_FREETEXTQUESTION':
            return state.map((freeTextQuestion) => {
                if (freeTextQuestion.question === action.oldQuestion) {
                    return {
                        ...freeTextQuestion,
                        question: freeTextQuestion.question.replace(action.oldQuestion, action.edited)
                    }
                } else {
                    return freeTextQuestion;
                }
            });
        case 'DELETE_FREETEXTQUESTION':
            return state.filter((question) => question.question !== action.freeTextQuestion);
        default:
            return state;
    }
};