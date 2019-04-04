using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public ApplicationDbContext Context { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }

        //protected abstract DbContext CreateContext();

        //protected internal DbContext Context
        //{
        //    get
        //    {
        //        if (this._context == null)
        //        {
        //            _context = CreateContext();
        //        }

        //        return this._context;
        //    }
        //}

        public void ClearContext()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }

        public void ExecuteSqlTransaction(List<string> sqlCommands)
        {
            using (var dbContextTransaction = Context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var sqlCommand in sqlCommands)
                    {
                        Context.Database.ExecuteSqlCommand(sqlCommand);
                    }

                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
        }

        public int ExecuteSqlCommand(string sqlCommand, params object[] parameters)
        {
            return Context.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        public virtual void SaveChanges() //int? commandTimeoutSeconds = null
        {

            Context.SaveChanges();

            //try
            //{
            //    OnBeforeSaveChanges();

            //    var result = SaveChangesWithTimeout(commandTimeoutSeconds);

            //    OnAfterSaveChanges();

            //    return result;
            //}
            //catch (DbEntityValidationException e)
            //{
            //    var validationMessage = CreateValidationMessage(e);

            //    throw new ApplicationException(validationMessage, e);
            //}

        }

        protected virtual void OnBeforeSaveChanges()
        {

        }
        protected virtual void OnAfterSaveChanges()
        {

        }

        //private int SaveChangesWithTimeout(int? commandTimeoutSeconds)
        //{
        //    int? defaultCommandTimeout = Context.Database.CommandTimeout;

        //    if (commandTimeoutSeconds.HasValue)
        //    {
        //        Context.Database.CommandTimeout = commandTimeoutSeconds;
        //    }

        //    try
        //    {
        //        return Context.SaveChanges();
        //    }
        //    finally
        //    {
        //        Context.Database.CommandTimeout = defaultCommandTimeout;
        //    }
        //}

        //private string CreateValidationMessage(DbEntityValidationException e)
        //{
        //    var sb = new StringBuilder();

        //    foreach (var eve in e.EntityValidationErrors)
        //    {
        //        sb.AppendLine(string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //            eve.Entry.Entity.GetType().Name, eve.Entry.State));

        //        foreach (var ve in eve.ValidationErrors)
        //        {
        //            sb.AppendLine(string.Format("- Property: \"{0}\", Error: \"{1}\"",
        //                ve.PropertyName, ve.ErrorMessage));
        //        }
        //    }

        //    return sb.ToString();
        //}

        public void Dispose()
        {
            ClearContext();
        }
    }
}

