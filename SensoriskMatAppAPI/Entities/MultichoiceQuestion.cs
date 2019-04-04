using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class MultichoiceQuestion : IEntity
    {
        public int ID { get; set; }
        public String Question { get; set; }
        public bool OwnOption { get; set; }
        public bool OneOption { get; set; }
    }
}
