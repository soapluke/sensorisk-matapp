using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Survey_FreetextQuestion : IEntity
    {
        public int ID { get; set; }
        public int SurveyId { get; set; }
        public int FreetextQuestionID { get; set; }
        public int? ChapterID { get; set; }
        public int Order { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual FreetextQuestion FreetextQuestion { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
