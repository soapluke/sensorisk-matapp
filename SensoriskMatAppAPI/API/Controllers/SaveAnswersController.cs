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
    [Route("api/saveanswers")]
    public class SaveAnswersController : Controller
    {
        public IFreeTextAnswerRepository _far;
        public IMultichoiceQuestion_OptionsAnswerRepository _moar;
        public IOptionsRepository _or;
        public IUnitOfWork _unitOfWork;


        public SaveAnswersController(IUnitOfWork unitOfWork,
                                     IFreeTextAnswerRepository far,
                                     IMultichoiceQuestion_OptionsAnswerRepository moar,
                                     IOptionsRepository or)
        {
            _unitOfWork = unitOfWork;
            _far = far;
            _moar = moar;
            _or = or;

        }

        [HttpPost]
        [Route("AddFreetextAnswer")]
        public void AddFreetextAnswer(SaveFreetextAnswersModel freetextAnswersModel)
        {
            foreach (var item in freetextAnswersModel.FreetextAnswers)
            {
                if (!String.IsNullOrEmpty(item.FreetextAnswer))
                {
                    FreetextAnswer freetextAnswer = new FreetextAnswer
                    {
                        Answer = item.FreetextAnswer,
                        FreetextQuestionID = item.FreetextID
                    };
                    _far.Add(freetextAnswer);
                }
            }
        }

        [HttpPost]
        [Route("AddMultichoiceAnswer")]
        public void AddMultichoiceAnswer(SaveMultichoiceAnswerModel multichoiceAnswerModel)
        {
            foreach (var item in multichoiceAnswerModel.MultichoiceAnswers)
            {
                foreach (var items in item.Options)
                {

                    MultichoiceQuestion_OptionsAnswer multichoiceQuestion_OptionsAnswer = new MultichoiceQuestion_OptionsAnswer
                    {
                        OptionsID = items.ID,
                        MultichoiceQuestionID = item.MultiID
                    };
                    _moar.Add(multichoiceQuestion_OptionsAnswer);
                }
                foreach (var ownOption in item.OwnOptions)
                {
                    Options option = new Options
                    {
                        Option = ownOption
                    };
                    var optionID = _or.Add(option);
                    MultichoiceQuestion_OptionsAnswer multichoiceQuestion_OptionsAnswer = new MultichoiceQuestion_OptionsAnswer
                    {
                        OptionsID = optionID.ID,
                        MultichoiceQuestionID = item.MultiID
                    };
                    _moar.Add(multichoiceQuestion_OptionsAnswer);
                }
            }
        }
    }
}