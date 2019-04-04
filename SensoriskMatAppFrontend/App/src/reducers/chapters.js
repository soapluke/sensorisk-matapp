const chaptersDefaultState = [];

export default (state = chaptersDefaultState, action) => {
    switch (action.type) {
        case 'CREATE_CHAPTER':
            return [
                ...state,
                {
                    title: action.chapterName,
                    chapterID: action.id,
                    questions: []
                }
            ];
        case 'ADD_FREETEXTQUESTION_TO_CHAPTER':
            return state.map((chapter) => {
                if (chapter.chapterID === action.chapterID) {
                    return {
                        ...chapter,
                        questions: [
                            ...chapter.questions,
                            {
                                question: action.question,
                                chapterID: action.chapterID,
                                options: [...action.options]
                            }
                        ]
                    };
                } else {
                    return chapter;
                }
            });
        case 'ADD_MULTICHOICEQUESTION_TO_CHAPTER':
            return state.map((chapter) => {
                if (chapter.chapterID === action.chapterID) {
                    return {
                        ...chapter,
                        questions: [
                            ...chapter.questions,
                            {
                                question: action.question,
                                options: [...action.options],
                                ownOption: action.ownOption,
                                chapterID: action.chapterID
                            }
                        ]
                    };
                } else {
                    return chapter;
                }
            });
        case 'DELETE_QUESTION_FROM_CHAPTER':
            return state.map((chapter) => {
                if (chapter.chapterID === action.chapterID) {
                    return {
                        ...chapter,
                        questions: chapter.questions.filter((item, index) => index !== action.questionIndex)
                    }
                } else {
                    return chapter;
                }
            });
        case 'EDIT_QUESTION_IN_CHAPTER':
            return state.map((chapter) => {
                if (chapter.chapterID === action.chapterID) {
                    return {
                        ...chapter,
                        questions: chapter.questions.map((question, index) => {
                            if (index === action.questionIndex) {
                                return {
                                    ...question,
                                    ...action.edits
                                }
                            } else {
                                return question;
                            }
                        })
                    }
                } else {
                    return chapter;
                }
            });
        default:
            return state;
    }
};