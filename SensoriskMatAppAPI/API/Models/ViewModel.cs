using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace API.Models
{
    public class ViewModel
    {
        public string Title { get; set; }
        public int ChapterID { get; set; }
        public ICollection<ViewAllQuestion> AllQuestion { get; set; }
    }
    public class ViewAllQuestion
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public int Order { get; set; }
        public bool OwnOption { get; set; }
        public ICollection<Options> Options { get; set; }
    }
}
