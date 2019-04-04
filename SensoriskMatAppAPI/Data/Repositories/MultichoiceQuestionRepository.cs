using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class MultichoiceQuestionRepository : BaseRepository<MultichoiceQuestion>, IMultichoiceQuestionRepository
    {
        public MultichoiceQuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public List<MultichoiceQuestion> GetAllMultichoiceQuestionWithId(IEnumerable<Survey_MultichoiceQuestion> list)
        {
            return GetAll().Where(x => list.Any(l => l.MultichoiceQuestionID == x.ID)).ToList();
        }
    }
}

