using Entities;

namespace Data.Repositories.Interfaces
{
    public interface IOrganisationRepository : IBaseRepository<Organisation>
    {
        bool CheckUser(string email);
        string GetHashPassword(string email);
        int GetIDFromMail(string email);
    }
}