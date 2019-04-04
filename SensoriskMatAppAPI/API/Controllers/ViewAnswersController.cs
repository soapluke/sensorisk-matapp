using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using API.Models;
using Data.Repositories;
using Data.Repositories.Interfaces;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/viewanswers")]
    public class ViewAnswersController : Controller
    {
        public IMultichoiceQuestionRepository _mr;
        public ISurvey_MultichoiceQuestionRepository _smr;
        public ISurvey_FreeTextQuestionRepository _sfr;
        public IFreeTextQuestionRepository _ftr;
        public IFreeTextAnswerRepository _ftar;
        public IChapterRepository _cr;
        public IOptionsRepository _or;
        public IMultichoiceQuestion_OptionsRepository _mor;
        public IMultichoiceQuestion_OptionsAnswerRepository _moar;
        public IUnitOfWork _unitOfWork;
        public ViewAnswersController(IUnitOfWork unitOfWork,
                                        IMultichoiceQuestionRepository mr,
                                        ISurvey_MultichoiceQuestionRepository smr,
                                        ISurvey_FreeTextQuestionRepository sfr,
                                        IFreeTextAnswerRepository ftar,
                                        IFreeTextQuestionRepository ftr,
                                        IChapterRepository cr,
                                        IOptionsRepository or,
                                        IMultichoiceQuestion_OptionsRepository mor,
                                        IMultichoiceQuestion_OptionsAnswerRepository moar)
        {
            _unitOfWork = unitOfWork;
            _mr = mr;
            _smr = smr;
            _sfr = sfr;
            _ftar = ftar;
            _ftr = ftr;
            _cr = cr;
            _or = or;
            _mor = mor;
            _moar = moar;
        }

        [HttpGet]
        [Route("GetAllAnswersFromSurvey/{id}")]
        public List<ViewAnswersModel> GetAllAnswersFromSurvey(int id)
        {
            List<Chapter> chapterList = new List<Chapter>();
            var chapterfree = _sfr.GetChapter(id);
            var chaptermulti = _smr.GetAllMultichoiceQuestionFromSurvey(id);
            foreach (var item in chapterfree)
            {
                var chapter = _cr.Get(item.ChapterID);
                if (!chapterList.Contains(chapter))
                {
                    chapterList.Add(chapter);
                }
            }
            foreach (var item in chaptermulti)
            {
                var chapter = _cr.Get(item.ChapterID);
                if (!chapterList.Contains(chapter))
                {
                    chapterList.Add(chapter);
                }
            }

            List<ViewAnswersModel> viewAnswers = new List<ViewAnswersModel>();
            foreach (var item in chapterList)
            {
                List<ViewAllAnswers> viewAllAnswers = new List<ViewAllAnswers>();
                var chapterfreetext = _sfr.GetAllFreetextQuestionFromChapterID(item, id);
                var chaptermultichoice = _smr.GetAllMultiQuestionFromChapterID(item, id);
                foreach (var items in chapterfreetext)
                {
                    var freeTextQuestion = _ftr.Get(items.FreetextQuestionID);
                    var freeTextAnswer = _ftar.GetFreeTextAnswerFromQuestion(items.FreetextQuestionID);
                    ViewAllAnswers answer = new ViewAllAnswers
                    {
                        ID = freeTextQuestion.ID,
                        Question = freeTextQuestion.Question,
                        Order = items.Order,
                        FreeTextAnswer = freeTextAnswer
                    };
                    viewAllAnswers.Add(answer);
                }

                foreach (var items in chaptermultichoice)
                {
                    var multichoice = _mr.Get(items.MultichoiceQuestionID);
                    var optionsAnswer = GetOptions(multichoice.ID);

                    Dictionary<string, int> optionsAnswersWithCount = new Dictionary<string, int>();

                    foreach (var option in optionsAnswer.GroupBy(o => o.Option)
                        .Select(group => new
                        {
                            Option = group.Key,
                            Count = group.Count()
                        })
                        .OrderBy(x => x.Option))
                    {
                        optionsAnswersWithCount.Add(option.Option, option.Count);
                    }

                    var optionsDictionaryToList = optionsAnswersWithCount.ToList();

                    ViewAllAnswers answer = new ViewAllAnswers
                    {
                        ID = multichoice.ID,
                        Question = multichoice.Question,
                        Order = items.Order,
                        OptionsAnswersWithCount = optionsDictionaryToList
                    };
                    viewAllAnswers.Add(answer);
                }
                var answers = viewAllAnswers.OrderBy(x => x.Order).ToList();
                ViewAnswersModel allAnswers = new ViewAnswersModel
                {
                    ChapterID = item.ID,
                    Title = item.Title,
                    AllAnswers = answers
                };
                viewAnswers.Add(allAnswers);
            }
            return viewAnswers;
        }

        public List<Options> GetOptions(int id)
        {
            var multioOption = _moar.GetAllOptionsAnswerFromMultichoiceQuestion(id);
            var options = _or.GetAllOptionsAnswerFromMultiQuestion(multioOption);
            return options;
        }
    }
}