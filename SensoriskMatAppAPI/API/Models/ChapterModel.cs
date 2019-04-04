using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class ChapterModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<FreeTextQuestionModel> FreeTextQuestionModel { get; set; }
        public ICollection<MultichoiceQuestion_OptionsModel> MultichoiceQuestion_OptionsModel { get; set; }
    }

    public class Survey_ChapterModel
    {
        public int SurveyID { get; set; }
        public ICollection<ChapterModel> ChapterModel { get; set; }
    }


    public class AddChapterModel
    {
        public int SurveyID { get; set; }
        public ICollection<ChaptersModel> ChaptersModel { get; set; }
        public ICollection<FreetextQModel> FreetextQModel { get; set; }
        public ICollection<MultiChoiceQModel> MultiChoiceQModel { get; set; }
    }

    public class ChaptersModel
    {
        public int ChapterID { get; set; }
        public string Title { get; set; }
    }
    public class FreetextQModel
    {
        public int ChapterID { get; set; }
        public string Question { get; set; }
        public int Order { get; set; }
    }
    public class MultiChoiceQModel
    {
        public int ChapterID { get; set; }
        public string Question { get; set; }
        public bool OwnOption { get; set; }
        public int Order { get; set; }
        public ICollection<string> Options { get; set; }
    }
}

