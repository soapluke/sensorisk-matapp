using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace API.Models
{
    public class ProfilePageModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Count { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<OrganisationSurveyModel> OrganisationSurvey { get; set; }
    }

    public class OrganisationSurveyModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
    }
}