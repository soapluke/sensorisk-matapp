//const multiChoiceQuestionDefaultState = {
//    multichoiceQuestion: '',
//    options: []
//};

const multiChoiceQuestionDefaultState = [];

export default (state = multiChoiceQuestionDefaultState, action) => {
    switch (action.type) {
        case 'CREATE_MULTICHOICEQUESTION':
            return [
                ...state,
                {
                    question: action.multiChoiceQuestion,
                    options: action.options,
                    chapterID: action.chapter,
                    ownOption: action.ownOption,
                    order: action.order
                }
            ];
        case 'FETCH_MULTICHOICEQUESTION':
            return action.multiChoiceQuestion;
        case 'RESET_MULTICHOICEQUESTION_STATE':
            return multiChoiceQuestionDefaultState;
        case 'EDIT_MULTICHOICEQUESTION':
            return state.map((multiChoiceQuestion) => {
                if (multiChoiceQuestion.question === action.oldQuestion) {
                    return {
                        ...multiChoiceQuestion,
                        ...action.edits
                    }
                } else {
                    return multiChoiceQuestion;
                }
            });
        case 'DELETE_MULTICHOICEQUESTION':
            return state.filter((item) => item.question !== action.multiChoiceQuestion);
        default:
            return state;
    }
};
