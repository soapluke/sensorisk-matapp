const surveysDefaultState = [];

export default (state = surveysDefaultState, action) => {
    switch (action.type) {
        case 'CREATE_SURVEY':
            return [
                ...state,
                action.survey
            ];
        case 'FETCH_SURVEYS':
            return action.surveys;
        default:
            return state;
    }
};