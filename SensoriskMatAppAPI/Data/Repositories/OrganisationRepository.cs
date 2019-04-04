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
    public class OrganisationRepository : BaseRepository<Organisation>, IOrganisationRepository
    {
        public OrganisationRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public string GetHashPassword(string email)
        {
            var organisation = Items.SingleOrDefault(x => x.Email == email);

            return organisation.Password;
        }

        public int GetIDFromMail(string email)
        {
            var organisation = Items.Single(x => x.Email == email);
            return organisation.ID;
        }

        public bool CheckUser(string email)
        {
            var organisation = Items.SingleOrDefault(x => x.Email == email);
            if (organisation != null)
            {
                return true;
            }
            return false;
        }
    }
}

