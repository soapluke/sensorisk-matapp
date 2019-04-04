using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Entities;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using API.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/viewsurvey")]
    public class ViewSurveyController : Controller
    {
        public MultichoiceQuestionRepository _mr;
        public Survey_MultichoiceQuestionRepository _smr;
        public Survey_FreeTextQuestionRepository _sfr;
        public FreeTextQuestionRepository _ftr;
        public ChapterRepository _cr;
        public OptionsRepository _or;
        public MultichoiceQuestion_OptionsRepository _mor;
        public SurveyRepository _sr;
        public IUnitOfWork _unitOfWork;
        public ViewSurveyController(IUnitOfWork unitOfWork, MultichoiceQuestionRepository mr, Survey_MultichoiceQuestionRepository smr, Survey_FreeTextQuestionRepository sfr, FreeTextQuestionRepository ftr, ChapterRepository cr, OptionsRepository or, MultichoiceQuestion_OptionsRepository mor, SurveyRepository sr)
        {
            _unitOfWork = unitOfWork;
            _mr = mr;
            _smr = smr;
            _sfr = sfr;
            _ftr = ftr;
            _cr = cr;
            _or = or;
            _mor = mor;
            _sr = sr;
        }

        [HttpGet]
        [Route("GetAllSurveyFromId/{id}")]
        public Survey GetAllSurveyFromId(int id)
        {
            return _sr.Get(id);
        }

        [HttpGet]
        [Route("GetAllQuestionChapterFromSurvey/{id}")]
        public List<ViewModel> GetAllQuestionChapterFromSurvey(int id)
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

            List<ViewModel> allChapter = new List<ViewModel>();
            foreach (var item in chapterList)
            {
                List<ViewAllQuestion> allQuestion = new List<ViewAllQuestion>();
                var chapterfreetext = _sfr.GetAllFreetextQuestionFromChapterID(item, id);
                var chaptermultichoice = _smr.GetAllMultiQuestionFromChapterID(item, id);
                foreach (var items in chapterfreetext)
                {
                    var freetext = _ftr.Get(items.FreetextQuestionID);
                    ViewAllQuestion question = new ViewAllQuestion
                    {
                        ID = freetext.ID,
                        Question = freetext.Question,
                        Order = items.Order
                    };
                    allQuestion.Add(question);
                }
                foreach (var items in chaptermultichoice)
                {
                    var multichoice = _mr.Get(items.MultichoiceQuestionID);
                    var options = GetOptions(multichoice.ID);
                    ViewAllQuestion question = new ViewAllQuestion
                    {
                        ID = multichoice.ID,
                        Question = multichoice.Question,
                        Order = items.Order,
                        OwnOption = multichoice.OwnOption,
                        Options = options
                    };
                    allQuestion.Add(question);
                }
                var questions = allQuestion.OrderBy(x => x.Order).ToList();
                ViewModel viewAll = new ViewModel
                {
                    ChapterID = item.ID,
                    Title = item.Title,
                    AllQuestion = questions
                };
                allChapter.Add(viewAll);
            }
            return allChapter;
        }

        public List<Options> GetOptions(int id)
        {
            var multioOption = _mor.GetAllOptionsFromQuestion(id);
            var options = _or.GetAllOptionsFromMultiQuestion(multioOption);
            return options;
        }


        [HttpGet]
        [Route("GetFreetextQuestionIDFromSurveyID/{id}")]
        public List<int> GetFreetextQuestionIDFromSurveyID(int id)
        {
            List<int> questionID = new List<int>();
            var freetextID = _sfr.getQuestionID(id);
            questionID.AddRange(freetextID);
            return questionID;
        }

        [HttpGet]
        [Route("GetMultichoiceQuestionIDFromSurveyID/{id}")]
        public List<int> GetMultichoiceQuestionIDFromSurveyID(int id)
        {
            List<int> questionID = new List<int>();
            var multiID = _smr.getQuestionID(id);
            questionID.AddRange(multiID);
            return questionID;

        }
    }
}