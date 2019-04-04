using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface ISurvey_FreeTextQuestionRepository : IBaseRepository<Survey_FreetextQuestion>
    {
        List<Survey_FreetextQuestion> GetAllFreetextQuestionFromChapterID(Chapter chapter, int surveyID);
        List<Survey_FreetextQuestion> GetAllFreeTextQuestionFromSurvey(int surveyId);
        List<Survey_FreetextQuestion> GetChapter(int surveyID);
        List<int?> GetChapterFromSurvey(int surveyID);
        List<int> getQuestionID(int surveyID);
    }
}