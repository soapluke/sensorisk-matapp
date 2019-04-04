using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class MultichoiceQuestion_OptionsRepository : BaseRepository<MultichoiceQuestion_Options>, IMultichoiceQuestion_OptionsRepository
    {
        public MultichoiceQuestion_OptionsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public List<MultichoiceQuestion_Options> GetAllOptionsFromQuestion(int multiQuestionid)
        {
            return Items.Where(x => x.MultichoiceQuestionID == multiQuestionid).ToList();
        }

    }
}

