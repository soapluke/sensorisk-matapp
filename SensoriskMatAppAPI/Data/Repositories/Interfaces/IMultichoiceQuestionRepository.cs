using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface IMultichoiceQuestionRepository : IBaseRepository<MultichoiceQuestion>
    {
        List<MultichoiceQuestion> GetAllMultichoiceQuestionWithId(IEnumerable<Survey_MultichoiceQuestion> list);
    }
}