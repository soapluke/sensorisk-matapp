using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace API.Models
{
    public class SaveFreetextAnswersModel
    {
        public ICollection<FreetextAnswersModel> FreetextAnswers { get; set; }
    }

    public class FreetextAnswersModel
    {
        public int FreetextID { get; set; }
        public string FreetextAnswer { get; set; }
    }

    public class SaveMultichoiceAnswerModel
    {
        public ICollection<MultichoiceAnswersModel> MultichoiceAnswers { get; set; }
    }

    public class MultichoiceAnswersModel
    {
        public int MultiID { get; set; }
        public ICollection<Options> Options { get; set; }
        public ICollection<string> OwnOptions { get; set; }
    }
}
