using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class OptionsRepository : BaseRepository<Options>, IOptionsRepository
    {

        public OptionsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Options> GetAllOptionsFromMultiQuestion(IEnumerable<MultichoiceQuestion_Options> mlist)
        {
            var test = GetAll().Where(x => mlist.Any(a => a.OptionsID == x.ID));
            return test.ToList();
        }

        public List<Options> GetAllOptionsAnswerFromMultiQuestion(IEnumerable<MultichoiceQuestion_OptionsAnswer> list)
        {
            List<Options> options = new List<Options>();

            foreach (var item in list)
            {
                var option = Get(item.OptionsID);
                options.Add(option);
            }
            return options;
        }
    }
}