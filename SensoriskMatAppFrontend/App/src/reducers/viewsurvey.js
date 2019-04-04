const chapterQuestionDefaultState = [];

export default (state = chapterQuestionDefaultState, action) => {
    switch (action.type) {
        case 'FETCH_CHAPTERQUESTION':
            return action.chapterQuestion;
        default:
            return state;
    }
};


