using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Data.Repositories;
using Data.Repositories.Interfaces;
using API.Utils;
using API.Models;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController : Controller
    {
        public IOrganisationRepository _or;
        public IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IOrganisationRepository or)
        {
            _unitOfWork = unitOfWork;
            _or = or;
        }

        [HttpGet]
        [Route("CheckUser/{id}")]
        public bool CheckUser(string id)
        {
            string email = id.Replace("-", ".");
            if (_or.CheckUser(email))
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("CheckPassword")]
        public int? CheckPassword([FromBody] LoginModel loginModel)
        {
            string email = loginModel.Email.Replace("-", ".");
            var hashPassword = _or.GetHashPassword(email);
            if (PasswordHasher.ValidatePassword(loginModel.Password, hashPassword))
            {

                return _or.GetIDFromMail(email);
            }
            return null;
        }

        [HttpGet]
        [Route("CreateOrg")]
        public void CreateOrg()
        {
            Organisation organisation = new Organisation
            {
                Name = "Lukas coola ställe",
                Email = "l@l.com",
                Password = PasswordHasher.CreateHash("12345")
            };
            _or.Add(organisation);
        }
    }
}
