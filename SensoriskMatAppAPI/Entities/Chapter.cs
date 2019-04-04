using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Chapter : IEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public String Description { get; set; }

    }
}
