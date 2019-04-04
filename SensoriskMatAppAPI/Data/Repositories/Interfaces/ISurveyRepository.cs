using System.Collections.Generic;
using Entities;

namespace Data.Repositories.Interfaces
{
    public interface ISurveyRepository : IBaseRepository<Survey>
    {
        bool CheckifCodeExist(int code);
        bool CheckSurveyFromCode(int code);
        int CountSurveyFromOrganisation(int id);
        List<Survey> GetAllSurveysFromOrganisation(int id);
        int GetSurveyFromCode(int code);
    }
}