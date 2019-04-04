export default (multiChoiceQuestions, chapterID) => {
    return multiChoiceQuestions.filter((question) => {
        const questionChapterMatch = chapterID === question.chapterID;
        return questionChapterMatch;
    }
)};
