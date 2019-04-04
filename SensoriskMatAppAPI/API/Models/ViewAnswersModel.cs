using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace API.Models
{

    public class ViewAnswersModel
    {
        public string Title { get; set; }
        public int ChapterID { get; set; }
        public ICollection<ViewAllAnswers> AllAnswers { get; set; }
    }
    public class ViewAllAnswers
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public int Order { get; set; }
        public ICollection<string> FreeTextAnswer { get; set; }
        public List<KeyValuePair<string, int>> OptionsAnswersWithCount { get; set; }
    }
}
