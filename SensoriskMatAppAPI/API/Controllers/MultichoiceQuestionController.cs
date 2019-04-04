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
    [Route("api/multichoicequestion")]
    public class MultichoiceQuestionController : Controller
    {
        public IMultichoiceQuestionRepository _mr;

        public IOptionsRepository _or;
        public IMultichoiceQuestion_OptionsRepository _mor;
        public IMultichoiceQuestion_OptionsAnswerRepository _moar;
        public ISurvey_MultichoiceQuestionRepository _smqr_;
        public IUnitOfWork _unitOfWork;
        public MultichoiceQuestionController(IUnitOfWork unitOfWork,
                                             IMultichoiceQuestionRepository mr,
                                             IOptionsRepository or,
                                             IMultichoiceQuestion_OptionsRepository mor,
                                             IMultichoiceQuestion_OptionsAnswerRepository moar,
                                             ISurvey_MultichoiceQuestionRepository smqr)
        {
            _unitOfWork = unitOfWork;
            _mr = mr;
            _or = or;
            _mor = mor;
            _moar = moar;
            _smqr_ = smqr;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Options> GetAll()
        {
            return _or.GetAll();
        }

        [HttpGet]
        [Route("GetAllOptionsFromMultiQuestion/{id}")]
        public IEnumerable<Options> GetAllOptionsFromMultiQuestion(int id)
        {
            IEnumerable<MultichoiceQuestion_Options> moList = _mor.GetAllOptionsFromQuestion(id);
            return _or.GetAllOptionsFromMultiQuestion(moList);
        }

        [HttpGet]
        [Route("GetAllOptionsAnswerFromMultiQuestion/{id}")]
        public IEnumerable<Options> GetAllOptionsAnswerFromMultiQuestion(int id)
        {
            IEnumerable<MultichoiceQuestion_OptionsAnswer> list = _moar.GetAllOptionsAnswerFromMultichoiceQuestion(id);
            return _or.GetAllOptionsAnswerFromMultiQuestion(list);
        }

        [HttpPost]
        [Route("Add")]
        public void Add(int surveyID, MultichoiceQuestion_OptionsModel multichoiceQuestion_Options)
        {
            MultichoiceQuestion multichoiceQuestion = new MultichoiceQuestion
            {
                Question = multichoiceQuestion_Options.MultiChoiceQuestion,
                OwnOption = multichoiceQuestion_Options.OwnOption
            };
            var multichoice = _mr.Add(multichoiceQuestion);

            List<Options> optionsList = AddOption(multichoiceQuestion_Options);
            var optionsitem = _or.AddRange(optionsList);

            AddMultiQuestion_Options(optionsitem, multichoice.ID);
            AddMultiQuestion_Survey(surveyID, multichoice.ID);
        }

        public void AddRange(CollectionOFMultiQuestion collectionOFMultiQuestion)
        {
            foreach (var item in collectionOFMultiQuestion.Collection)
            {
                Add(collectionOFMultiQuestion.SurveyID, item);
            }
        }

        private static List<Options> AddOption(MultichoiceQuestion_OptionsModel multichoiceQuestion_Options)
        {
            List<Options> optionsList = new List<Options>();
            foreach (var items in multichoiceQuestion_Options.Options)
            {
                Options option = new Options
                {
                    Option = items
                };
                optionsList.Add(option);
            }

            return optionsList;
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

        public void AddMultiQuestion_Survey(int surveyID, int multiID)
        {
            Survey_MultichoiceQuestion survey_MultichoiceQuestion = new Survey_MultichoiceQuestion
            {
                SurveyID = surveyID,
                MultichoiceQuestionID = multiID
            };
            _smqr_.Add(survey_MultichoiceQuestion);
        }


        //Tester
        [HttpGet]
        [Route("Test")]
        public void Test()
        {
            var list = new List<string>();

            list.Add("Brödigt");
            list.Add("Mjöligt");
            list.Add("Stramt");

            var list2 = new List<string>();

            list2.Add("Brödigt");
            list2.Add("Mjöligt");
            list2.Add("Stramt");

            var multichoicequestion = new MultichoiceQuestion_OptionsModel
            {
                MultiChoiceQuestion = "Hur tyckte du att brödet smakade?",
                Options = list,
            };
            var multichoicequestion2 = new MultichoiceQuestion_OptionsModel
            {
                MultiChoiceQuestion = "Hur tyckte du att brödet smakade?",
                Options = list2,
            };
            var multilista = new List<MultichoiceQuestion_OptionsModel>();
            multilista.Add(multichoicequestion);
            multilista.Add(multichoicequestion2);

            var collection = new CollectionOFMultiQuestion
            {
                SurveyID = 2,
                Collection = multilista
            };

            AddRange(collection);
        }
    }
}