using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class MultichoiceQuestion_OptionsAnswer : IEntity
    {
        public int ID { get; set; }
        public int MultichoiceQuestionID { get; set; }
        public int OptionsID { get; set; }

        public virtual MultichoiceQuestion MultichoiceQuestion { get; set; }
        public virtual Options Options { get; set; }
    }
}
