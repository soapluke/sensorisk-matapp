using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class Survey_FreeTextQuestionRepository : BaseRepository<Survey_FreetextQuestion>, ISurvey_FreeTextQuestionRepository
    {
        public Survey_FreeTextQuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<Survey_FreetextQuestion> GetAllFreeTextQuestionFromSurvey(int surveyId)
        {
            return Items.Where(x => x.SurveyId == surveyId).ToList();
        }

        public List<Survey_FreetextQuestion> GetAllFreetextQuestionFromChapterID(Chapter chapter, int surveyID)
        {
            return GetAll().Where(x => x.ChapterID == chapter.ID && x.SurveyId == surveyID).ToList();
        }

        public List<int?> GetChapterFromSurvey(int surveyID)
        {
            var list = GetAllFreeTextQuestionFromSurvey(surveyID);
            var lista = list.Select(x => x.ChapterID);
            List<int?> chapter = new List<int?>();
            foreach (var item in lista)
            {
                chapter.Add(item);
            }
            return chapter;
        }

        public List<Survey_FreetextQuestion> GetChapter(int surveyID)
        {
            return GetAll().Where(x => x.SurveyId == surveyID).ToList();
        }

        public List<int> getQuestionID(int surveyID)
        {
            var list = GetAllFreeTextQuestionFromSurvey(surveyID);
            var questionID = list.Select(x => x.FreetextQuestionID);
            return questionID.ToList();
        }
    }
}

