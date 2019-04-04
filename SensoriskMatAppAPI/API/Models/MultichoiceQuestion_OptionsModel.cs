using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace API.Models
{
    public class MultichoiceQuestion_OptionsModel
    {
        public string MultiChoiceQuestion { get; set; }
        public bool OwnOption { get; set; }
        public ICollection<string> Options { get; set; }
    }

    public class CollectionOFMultiQuestion
    {
        public int SurveyID { get; set; }
        public ICollection<MultichoiceQuestion_OptionsModel> Collection { get; set; }
    }
}
