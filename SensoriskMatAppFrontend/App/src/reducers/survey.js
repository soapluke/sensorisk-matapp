const surveyDefaultState = [];

export default (state = surveyDefaultState, action) => {
    switch (action.type) {
        case 'FETCH_SURVEY':
            return action.survey;
        default:
            return state;
    }
};
