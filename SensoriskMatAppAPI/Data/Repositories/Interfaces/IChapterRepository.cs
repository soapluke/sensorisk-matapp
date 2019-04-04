using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface IChapterRepository : IBaseRepository<Chapter>
    {
        Chapter Get(int? id);
        List<Chapter> GetAllChapterFromSurvey(List<int?> chapter);
    }
}