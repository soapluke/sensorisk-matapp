using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class ChapterRepository : BaseRepository<Chapter>, IChapterRepository
    {
        public ChapterRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Chapter> GetAllChapterFromSurvey(List<int?> chapter)
        {
            return GetAll().Where(x => chapter.Any(c => c == x.ID)).ToList();
        }
        public Chapter Get(int? id)
        {
            return Items.Find(id);
        }
    }

}

