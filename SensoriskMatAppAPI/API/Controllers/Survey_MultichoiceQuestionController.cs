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

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/survey_multichoicequestion")]
    public class Survey_MultichoiceQuestionController : Controller
    {
        public ISurvey_MultichoiceQuestionRepository _smr;
        public IUnitOfWork _unitOfWork;
        public Survey_MultichoiceQuestionController(IUnitOfWork unitOfWork, ISurvey_MultichoiceQuestionRepository smr)
        {
            _unitOfWork = unitOfWork;
            _smr = smr;
        }

        [HttpGet]
        [Route("GetAllMultichoiceQuestionFromSurvey/{id}")]
        public IEnumerable<Survey_MultichoiceQuestion> GetAllMultichoiceQuestionFromSurvey(int id)
        {
            return _smr.GetAllMultichoiceQuestionFromSurvey(id);
        }
    }
}