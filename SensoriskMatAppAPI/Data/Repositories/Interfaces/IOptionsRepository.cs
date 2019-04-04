using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface IOptionsRepository : IBaseRepository<Options>
    {
        List<Options> GetAllOptionsAnswerFromMultiQuestion(IEnumerable<MultichoiceQuestion_OptionsAnswer> list);
        List<Options> GetAllOptionsFromMultiQuestion(IEnumerable<MultichoiceQuestion_Options> mlist);
    }
}