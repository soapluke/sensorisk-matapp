using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Entities;

namespace Data.Repositories
{
    public class FreeTextAnswerRepository : BaseRepository<FreetextAnswer>, IFreeTextAnswerRepository
    {
        public FreeTextAnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public ICollection<string> GetFreeTextAnswerFromQuestion(int questionId)
        {
            var list = Items.Where(x => x.FreetextQuestionID == questionId).ToList();
            var answer = list.Select(x => x.Answer).ToList();
            return answer;
        }
    }
}

