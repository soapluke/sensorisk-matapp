using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class SurveyRepository : BaseRepository<Survey>, ISurveyRepository
    {
        public SurveyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public List<Survey> GetAllSurveysFromOrganisation(int id)
        {
            return Items.Where(x => x.OrganisationID == id).ToList();
        }

        public bool CheckifCodeExist(int code)
        {
            var codeExist = Items.Where(x => x.Code == code).ToList();
            if (codeExist.Any())
            {
                return true;
            }
            return false;
        }

        public int GetSurveyFromCode(int code)
        {
            var survey = Items.SingleOrDefault(x => x.Code == code);
            return survey.ID;
        }

        public bool CheckSurveyFromCode(int code)
        {
            var survey = Items.SingleOrDefault(x => x.Code == code);
            if (survey != null)
            {
                return true;
            }
            return false;
        }

        public int CountSurveyFromOrganisation(int id)
        {
            return Items.Count(x => x.OrganisationID == id);
        }
    }
}
