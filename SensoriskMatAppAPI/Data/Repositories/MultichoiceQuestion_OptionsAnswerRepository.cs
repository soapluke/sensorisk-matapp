using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class MultichoiceQuestion_OptionsAnswerRepository : BaseRepository<MultichoiceQuestion_OptionsAnswer>, IMultichoiceQuestion_OptionsAnswerRepository
    {
        public MultichoiceQuestion_OptionsAnswerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<MultichoiceQuestion_OptionsAnswer> GetAllOptionsAnswerFromMultichoiceQuestion(int id)
        {
            return Items.Where(x => x.MultichoiceQuestionID == id).ToList();
        }
    }
}

