using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface IFreeTextAnswerRepository : IBaseRepository<FreetextAnswer>
    {
        ICollection<string> GetFreeTextAnswerFromQuestion(int questionId);
    }
}