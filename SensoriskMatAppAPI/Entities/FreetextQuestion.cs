using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class FreetextQuestion : IEntity
    {
        public int ID { get; set; }
        public String Question { get; set; }
        public virtual ICollection<FreetextAnswer> FreetextAnswer { get; set; }
    }
}
