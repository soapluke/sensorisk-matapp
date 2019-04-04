using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationDbContext Context { get; set; }
        void SaveChanges(); //int? commandTimeoutSeconds = null
        void ClearContext();
        void ExecuteSqlTransaction(List<string> sqlCommands);
        int ExecuteSqlCommand(string sqlCommand, params object[] parameters);
    }
}
