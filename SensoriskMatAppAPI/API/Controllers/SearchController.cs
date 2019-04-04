using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Entities;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/search")]
    public class SearchController : Controller
    {

        public ISurveyRepository _sr;
        public IUnitOfWork _unitOfWork;
        public SearchController(IUnitOfWork unitOfWork, ISurveyRepository sr)
        {
            _unitOfWork = unitOfWork;
            _sr = sr;
        }

        [HttpGet]
        [Route("GetSurveyFromCode/{id}")]
        public int GetSurveyFromCode(int id)
        {
            if (_sr.CheckSurveyFromCode(id))
            {
                return _sr.GetSurveyFromCode(id);
            }
            return 0;
        }
    }
}
