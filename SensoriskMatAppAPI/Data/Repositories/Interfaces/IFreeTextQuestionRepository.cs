using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface IFreeTextQuestionRepository : IBaseRepository<FreetextQuestion>
    {
        ICollection<FreetextQuestion> GetAllFreeTextQuestionFromSurvey(IEnumerable<Survey_FreetextQuestion> list);
    }
}