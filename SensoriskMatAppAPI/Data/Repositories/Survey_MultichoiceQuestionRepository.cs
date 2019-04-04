using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class Survey_MultichoiceQuestionRepository : BaseRepository<Survey_MultichoiceQuestion>, ISurvey_MultichoiceQuestionRepository
    {
        public Survey_MultichoiceQuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public List<Survey_MultichoiceQuestion> GetAllMultichoiceQuestionFromSurvey(int surveyId)
        {
            return Items.Where(x => x.SurveyID == surveyId).ToList();
        }

        public List<Survey_MultichoiceQuestion> GetAllMultiQuestionFromChapterID(Chapter chapter, int surveyID)
        {
            return GetAll().Where(x => x.ChapterID == chapter.ID && x.SurveyID == surveyID).ToList();
        }

        public List<int?> GetChapterFromSurvey(int surveyID)
        {
            var list = GetAllMultichoiceQuestionFromSurvey(surveyID);
            var lista = list.Select(x => x.ChapterID);
            List<int?> chapter = new List<int?>();
            foreach (var item in lista)
            {
                chapter.Add(item);
            }
            return chapter;
        }

        public List<int> getQuestionID(int surveyID)
        {
            var list = GetAllMultichoiceQuestionFromSurvey(surveyID);
            var questionID = list.Select(x => x.MultichoiceQuestionID);
            return questionID.ToList();
        }
    }
}
