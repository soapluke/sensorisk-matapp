using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class SurveyModel
    {
        public int ID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int OrganisationID { get; set; }
    }
}