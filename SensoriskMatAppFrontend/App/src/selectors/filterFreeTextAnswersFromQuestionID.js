export default (freeTextAnswers, questionID) => {
    return freeTextAnswers.filter((answer) => {
        const questionAnswerMatch = questionID === question.FreetextQuestionID;
        return questionAnswerMatch;
    })
};
