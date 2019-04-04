using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Survey_FreeTextQuestionModel
    {
        public ICollection<string> Question { get; set; }
        public int SurveyID { get; set; }
    }

    public class FreeTextQuestionModel
    {
        public string Question { get; set; }
    }
}

