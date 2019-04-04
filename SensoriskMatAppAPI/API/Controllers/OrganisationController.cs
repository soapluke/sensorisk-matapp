using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Data;
using API.Models;
using Data.Repositories.Interfaces;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/organisation")]
    public class OrganisationController : Controller
    {
        public IOrganisationRepository _or;
        public ISurveyRepository _sr;
        public IUnitOfWork _unitOfWork;
        public OrganisationController(IUnitOfWork unitOfWork, IOrganisationRepository or, ISurveyRepository sr)
        {
            _unitOfWork = unitOfWork;
            _or = or;
            _sr = sr;
        }


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Organisation> GetAll()
        {
            //return new List<Organisation>();
            return _or.GetAll();
        }

        [HttpGet]
        [Route("GetOrganisation/{id}")]
        public ProfilePageModel GetOrganisation(int id)
        {
            List<OrganisationSurveyModel> surveys = new List<OrganisationSurveyModel>();
            var list = _sr.GetAllSurveysFromOrganisation(id);
            foreach (var item in list)
            {
                OrganisationSurveyModel survey = new OrganisationSurveyModel
                {
                    ID = item.ID,
                    Title = item.Title
                };
                surveys.Add(survey);
            }

            var organisation = _or.Get(id);
            ProfilePageModel profilePage = new ProfilePageModel
            {
                Name = organisation.Name,
                Email = organisation.Email,
                Count = _sr.CountSurveyFromOrganisation(id),
                OrganisationSurvey = surveys
            };
            return profilePage;

        }
    }
}
