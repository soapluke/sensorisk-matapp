export default (chapters, chapterID) => {
    return chapters.filter((chapter) => {
        const chapterMatch = chapterID === chapter.chapterID;
        return chapterMatch;
    })
};
