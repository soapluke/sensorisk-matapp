export default (chapterState, chapterID, questionIndex) => {
    return chapterState.map((chapter) => {
        if (chapter.chapterID === chapterID) {
            return chapter.questions.filter((item, index) => index === questionIndex)
        } else {
            return chapterState;
        }
    }
)};