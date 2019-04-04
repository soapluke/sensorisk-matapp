using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface IMultichoiceQuestion_OptionsRepository : IBaseRepository<MultichoiceQuestion_Options>
    {
        List<MultichoiceQuestion_Options> GetAllOptionsFromQuestion(int multiQuestionid);
    }
}