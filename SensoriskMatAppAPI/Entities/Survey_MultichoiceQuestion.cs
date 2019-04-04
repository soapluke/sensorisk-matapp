using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Survey_MultichoiceQuestion : IEntity
    {
        public int ID { get; set; }
        public int SurveyID { get; set; }
        public int MultichoiceQuestionID { get; set; }
        public int? ChapterID { get; set; }
        public int Order { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual MultichoiceQuestion MultichoiceQuestion { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
