using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MultichoiceQuestion_UsersOptions : IEntity
    {
        public int ID { get; set; }
        public int MultichoiceQuestionID { get; set; }
        public int UsersOptionsID { get; set; }

        public virtual MultichoiceQuestion MultichoiceQuestion { get; set; }
        public virtual UsersOptions UsersOptions { get; set; }
    }
}
