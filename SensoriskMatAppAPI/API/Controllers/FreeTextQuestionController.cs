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
using API.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/freetextquestion")]
    public class FreeTextQuestionController : Controller
    {
        public IFreeTextQuestionRepository _fqr;
        public ISurvey_FreeTextQuestionRepository _sfqr;
        public IFreeTextAnswerRepository _far;
        public IUnitOfWork _unitOfWork;
        public FreeTextQuestionController(IUnitOfWork unitOfWork,
                                          IFreeTextQuestionRepository fqr,
                                          ISurvey_FreeTextQuestionRepository sfqr,
                                          IFreeTextAnswerRepository far)
        {
            _unitOfWork = unitOfWork;
            _fqr = fqr;
            _sfqr = sfqr;
            _far = far;
        }

        [HttpGet]
        [Route("GetAllFreeTextQuestionFromSurvey/{id}")]
        public IEnumerable<FreetextQuestion> GetAllFreeTextQuestionFromSurvey(int id)
        {
            IEnumerable<Survey_FreetextQuestion> list = _sfqr.GetAllFreeTextQuestionFromSurvey(id);
            return _fqr.GetAllFreeTextQuestionFromSurvey(list);
        }

        [HttpPost]
        [Route("Add")]
        public void Add(FreetextQuestion freetextQuestion)
        {
            FreetextQuestion freetext = new FreetextQuestion
            {
                Question = freetextQuestion.Question
            };
            var freetextitem = _fqr.Add(freetext);
            Survey_FreetextQuestion survey_FreetextQuestion = new Survey_FreetextQuestion
            {
                SurveyId = freetextQuestion.ID,
                FreetextQuestionID = freetextitem.ID
            };
            _sfqr.Add(survey_FreetextQuestion);
        }

        [HttpPost]
        [Route("AddRange")]
        public void AddRange(Survey_FreeTextQuestionModel freetextQuestion)
        {
            List<FreetextQuestion> fqList = new List<FreetextQuestion>();

            foreach (var items in freetextQuestion.Question)
            {
                FreetextQuestion freeQuestion = new FreetextQuestion
                {
                    Question = items
                };

                fqList.Add(freeQuestion);
            }

            var freetextitems = _fqr.AddRange(fqList);

            foreach (var freetext in freetextitems)
            {
                Survey_FreetextQuestion survey_FreetextQuestion = new Survey_FreetextQuestion
                {
                    FreetextQuestionID = freetext.ID,
                    SurveyId = freetextQuestion.SurveyID
                };
                _sfqr.Add(survey_FreetextQuestion);
            }
        }

        [HttpPost]
        [Route("AddAnswer")]
        public void AddAnswer(FreetextAnswer freetextAnswer, int id)
        {
            FreetextAnswer answer = new FreetextAnswer
            {
                Answer = freetextAnswer.Answer,
                FreetextQuestionID = id
            };
            _far.Add(answer);
        }
        //tester

        [HttpGet]
        [Route("TestAnswer")]
        public int TestAnswer()
        {
            //FreetextAnswer freetextAnswer = new FreetextAnswer
            //{
            //    Answer = "Jag tyckte det var rätt gott."
            //};
            //AddAnswer(freetextAnswer, 2);
            return 1;
        }

        //[Route("/api/FreeTextQuestion/Test")]
        //[HttpGet]
        //public void test()
        //{
        //    FreetextQuestion test = new FreetextQuestion
        //    {
        //        Question = "Hur mår du idag?"
        //    };
        //    Add(test, 2);
        //}

        //[Route("/api/FreeTextQuestion/TestRange")]
        //[HttpGet]
        //public void testRange()
        //{
        //    var list = new List<FreetextQuestion>
        //    {
        //        new FreetextQuestion {Question="Vad tycker du om vädret?"},
        //        new FreetextQuestion {Question="Vad heter din mamma?"},
        //        new FreetextQuestion {Question="Vad säger du?"}
        //    };

        //    AddRange(list, 1);
        //}
    }



}

