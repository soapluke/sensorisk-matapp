using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface IMultichoiceQuestion_OptionsAnswerRepository : IBaseRepository<MultichoiceQuestion_OptionsAnswer>
    {
        List<MultichoiceQuestion_OptionsAnswer> GetAllOptionsAnswerFromMultichoiceQuestion(int id);
    }
}