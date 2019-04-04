const submittedMultiAnswersDefaultState = [];

export default (state = submittedMultiAnswersDefaultState, action) => {
    switch (action.type) {
        case 'ADD_MULTIANSWERS_TO_QUESTIONID':
            return state.map((question) => {
               if (question.multiID === action.multiID) {
                    return {
                        ...question,
                        options: [...action.options],
                        ownOptions: [...action.ownOptions] 
                    }
                } else {
                    return question;
                }
            });
        case 'FETCH_MULTIQUESTIONID_FROM_SURVEYID':
            return action.multiID.map((id) => {
                return {
                    multiID: id,
                    options: [],
                    ownOptions: []
                }
            });
                
        default:
            return state;
    }
};