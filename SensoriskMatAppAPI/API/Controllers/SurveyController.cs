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
    [Route("api/survey")]
    public class SurveyController : Controller
    {
        public ISurveyRepository _sr;
        public IMultichoiceQuestionRepository _mr;
        public ISurvey_MultichoiceQuestionRepository _smr;
        public ISurvey_FreeTextQuestionRepository _sfr;
        public IFreeTextQuestionRepository _ftr;
        public IChapterRepository _cr;
        public IOptionsRepository _or;
        public IMultichoiceQuestion_OptionsRepository _mor;
        public IUnitOfWork _unitOfWork;
        public SurveyController(IUnitOfWork unitOfWork,
                                ISurveyRepository sr,
                                IMultichoiceQuestionRepository mr,
                                ISurvey_MultichoiceQuestionRepository smr,
                                ISurvey_FreeTextQuestionRepository sfr,
                                IFreeTextQuestionRepository ftr,
                                IChapterRepository cr,
                                IOptionsRepository or,
                                IMultichoiceQuestion_OptionsRepository mor)
        {
            _unitOfWork = unitOfWork;
            _sr = sr;
            _mr = mr;
            _smr = smr;
            _sfr = sfr;
            _ftr = ftr;
            _cr = cr;
            _or = or;
            _mor = mor;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Survey> GetAll()
        {
            return _sr.GetAll();
        }

        [HttpGet]
        [Route("GetSurveyFromOrganisation/{id}")]
        public IEnumerable<Survey> GetAllSurveysFromOrganisation(int id)
        {
            return _sr.GetAllSurveysFromOrganisation(id);
        }

        [HttpPost]
        [Route("AddSurvey")]
        public int AddSurvey([FromBody] SurveyModel survey)
        {
            Survey sur = new Survey
            {
                Title = survey.Title,
                Description = survey.Description,
                Code = GenerateCode(),
                OrganisationID = survey.OrganisationID,
                StartDate = CheckStartDate(survey.StartDate),
                EndDate = CheckEndDate(survey.EndDate)
            };
            var surveyid = _sr.Add(sur);
            return surveyid.ID;

        }

        public DateTime? CheckStartDate(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now.AddHours(1);
            }
            return dateTime;
        }

        public DateTime? CheckEndDate(DateTime? datetime)
        {
            if (datetime == null)
            {
                datetime = DateTime.Now.AddMonths(1);
            }
            return datetime;
        }

        //Vad händer när 4000 koder är upptagna? You tell me
        [HttpGet]
        [Route("GenerateCode")]
        public int GenerateCode()
        {
            int count = 0;
            Random rand = new Random();
            int code = rand.Next(1000, 9999);

            while (_sr.CheckifCodeExist(code) && count < 4000)
            {
                count++;
                code = rand.Next(1000, 9999);
            }
            return code;
        }


        [HttpGet]
        [Route("GetAllMultichoiceQuestionFromSurvey/{id}")]
        public IEnumerable<MultichoiceQuestion> GetAllMultichoiceQuestionFromSurvey(int id)
        {
            IEnumerable<Survey_MultichoiceQuestion> smList = _smr.GetAllMultichoiceQuestionFromSurvey(id);
            var list = _mr.GetAllMultichoiceQuestionWithId(smList);
            return list;
        }

        [HttpGet]
        [Route("GetAllFreetextQuestionFromSurvey/{id}")]
        public IEnumerable<FreetextQuestion> GetAllFreetextQuestionFromSurvey(int id)
        {
            IEnumerable<Survey_FreetextQuestion> list = _sfr.GetAllFreeTextQuestionFromSurvey(id);
            return _ftr.GetAllFreeTextQuestionFromSurvey(list);
        }

        // -------Lägger till chapter och frågor. 

        [HttpPost]
        [Route("AddChapter")]
        public void AddChapter([FromBody] AddChapterModel chapter)
        {

            foreach (var item in chapter.ChaptersModel)
            {
                List<FreetextQModel> fqList = new List<FreetextQModel>();
                List<MultiChoiceQModel> mcList = new List<MultiChoiceQModel>();

                foreach (var items in chapter.FreetextQModel)
                {
                    if (item.ChapterID == items.ChapterID)
                    {
                        fqList.Add(items);
                    }
                }
                foreach (var items in chapter.MultiChoiceQModel)
                {
                    if (item.ChapterID == items.ChapterID)
                    {
                        mcList.Add(items);
                    }
                }
                var newChapter = new Chapter
                {
                    Title = item.Title
                };
                var chapterItem = _cr.Add(newChapter);
                AddFreeQuestionRange(fqList, chapterItem.ID, chapter.SurveyID);
                AddMultiQuestionRange(mcList, chapterItem.ID, chapter.SurveyID);
            }
        }

        public void AddMultiQuestionRange(ICollection<MultiChoiceQModel> multiChoice, int chapterID, int surveyID)
        {
            foreach (var item in multiChoice)
            {
                AddMultiQuestion(item, chapterID, surveyID);
            }
        }
        public void AddMultiQuestion(MultiChoiceQModel multiChoice, int chapterID, int surveyID)
        {
            MultichoiceQuestion multichoiceQuestion = new MultichoiceQuestion
            {
                Question = multiChoice.Question,
                OwnOption = multiChoice.OwnOption,
            };
            var multiQuestionItem = _mr.Add(multichoiceQuestion);

            var optionsList = AddOption(multiChoice.Options); //---- finns längre upp så länge

            AddMultiQuestion_Options(optionsList, multiQuestionItem.ID);
            AddMultiQuestion_Survey(surveyID, chapterID, multiQuestionItem.ID, multiChoice.Order);

        }

        private IEnumerable<Options> AddOption(ICollection<string> options)
        {
            List<Options> optionsList = new List<Options>();
            foreach (var items in options)
            {
                Options option = new Options
                {
                    Option = items
                };
                optionsList.Add(option);
            }
            var optionsItems = _or.AddRange(optionsList);

            return optionsItems;
        }

        public void AddMultiQuestion_Options(IEnumerable<Options> options, int multiQuestionID)
        {
            foreach (var option in options)
            {
                MultichoiceQuestion_Options multiQuestionOption = new MultichoiceQuestion_Options
                {
                    OptionsID = option.ID,
                    MultichoiceQuestionID = multiQuestionID
                };
                _mor.Add(multiQuestionOption);
            }
        }

        public void AddMultiQuestion_Survey(int surveyID, int chapterID, int multiID, int order)
        {
            Survey_MultichoiceQuestion survey_MultichoiceQuestion = new Survey_MultichoiceQuestion
            {
                SurveyID = surveyID,
                MultichoiceQuestionID = multiID,
                ChapterID = chapterID,
                Order = order
            };
            _smr.Add(survey_MultichoiceQuestion);
        }

        public void AddFreeQuestionRange(ICollection<FreetextQModel> freetext, int chapterID, int surveyID)
        {
            foreach (var item in freetext)
            {
                FreetextQuestion freetextQuestion = new FreetextQuestion
                {
                    Question = item.Question
                };
                var freetextQuestionItem = _ftr.Add(freetextQuestion);
                AddSurvey_FreeTextQuestion(freetextQuestionItem, item.Order, chapterID, surveyID);
            }
        }

        public void AddSurvey_FreeTextQuestion(FreetextQuestion freetextQuestion, int order, int chapterID, int surveyID)
        {
            Survey_FreetextQuestion survey_FreetextQuestion = new Survey_FreetextQuestion
            {
                FreetextQuestionID = freetextQuestion.ID,
                Order = order,
                SurveyId = surveyID,
                ChapterID = chapterID
            };
            _sfr.Add(survey_FreetextQuestion);
        }

        //[Route("api/Survey/GetAllQuestions")]
        //[HttpGet]
        //public HttpResponseMessage GetAllQuestions()
        //{
        //    var lista1 = GetAllFreetextQuestionFromSurvey(1);
        //    var lista2 = GetAllMultichoiceQuestionFromSurvey(1);

        //    return ControllerContext.Request
        //        .CreateResponse(HttpStatusCode.OK, new { lista1, lista2 });
        //}
    }
}