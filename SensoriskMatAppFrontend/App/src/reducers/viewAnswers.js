const viewAnswersDefaultState = [];

export default (state = viewAnswersDefaultState, action) => {
    switch (action.type) {
        case 'FETCH_ALLANSWERS':
            return action.allAnswers;
        default:
            return state;
    }
};
