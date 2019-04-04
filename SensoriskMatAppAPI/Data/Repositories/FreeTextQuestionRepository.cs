using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class FreeTextQuestionRepository : BaseRepository<FreetextQuestion>, IFreeTextQuestionRepository
    {
        public FreeTextQuestionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public ICollection<FreetextQuestion> GetAllFreeTextQuestionFromSurvey(IEnumerable<Survey_FreetextQuestion> list)
        {
            return GetAll().Where(x => list.Any(l => l.FreetextQuestionID == x.ID)).ToList();
        }
    }
}

