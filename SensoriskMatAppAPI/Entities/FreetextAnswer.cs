using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class FreetextAnswer : IEntity
    {
        public int ID { get; set; }
        public String Answer { get; set; }
        public int FreetextQuestionID { get; set; }
        public virtual FreetextQuestion FreetextQuestion { get; set; }
    }
}
