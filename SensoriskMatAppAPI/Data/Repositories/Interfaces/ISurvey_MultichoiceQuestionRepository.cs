using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface ISurvey_MultichoiceQuestionRepository : IBaseRepository<Survey_MultichoiceQuestion>
    {
        List<Survey_MultichoiceQuestion> GetAllMultichoiceQuestionFromSurvey(int surveyId);
        List<Survey_MultichoiceQuestion> GetAllMultiQuestionFromChapterID(Chapter chapter, int surveyID);
        List<int?> GetChapterFromSurvey(int surveyID);
        List<int> getQuestionID(int surveyID);
    }
}