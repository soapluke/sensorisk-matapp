const submittedFreetextAnswersDefaultState = [];

export default (state = submittedFreetextAnswersDefaultState, action) => {
    switch (action.type) {
        case 'ADD_FREETEXTANSWERS_TO_QUESTIONID':
            return state.map((question) => {
                if (question.freetextID === action.freetextID) {
                    return {
                        ...question,
                        freetextAnswer: action.freetextAnswer
                    }
                } else {
                    return question;
                }
            });
        case 'FETCH_FREETEXTQUESTIONID_FROM_SURVEYID':
            return action.freetextID.map((id) => {
                return {
                    freetextID: id,
                    freetextAnswer: ''
                }
            });
        default:
            return state;
    }
};