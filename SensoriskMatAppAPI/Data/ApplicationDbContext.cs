using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Organisation> Organisation { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<FreetextAnswer> FreetextAnswer { get; set; }
        public DbSet<FreetextQuestion> FreetextQuestion { get; set; }
        public DbSet<MultichoiceQuestion> MultichoiceQuestion { get; set; }
        public DbSet<MultichoiceQuestion_Options> MultichoiceQuestion_Options { get; set; }
        public DbSet<MultichoiceQuestion_OptionsAnswer> MultichoiceQuestion_OptionsAnswer { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<UsersOptions> UsersOptions { get; set; }
        public DbSet<MultichoiceQuestion_UsersOptions> MultichoiceQuestion_UsersOptions { get; set; }
        public DbSet<Survey_FreetextQuestion> Survey_FreetextQuestion { get; set; }
        public DbSet<Survey_MultichoiceQuestion> Survey_MultichoiceQuestion { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
    }

    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>

    {

        public ApplicationDbContext CreateDbContext(string[] args)

        {

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //builder.UseSqlServer("Server=tcp:knowitorebrotest.database.windows.net,1433;Initial Catalog=sensoriskmatapp-test;Persist Security Info=False;User ID=sensoriskmatapp-test;Password=Edgar1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            builder.UseSqlServer("Server=.\\sqlexpress;Database=Sensorisk-Matapp;Trusted_Connection=True;");

            var context = new ApplicationDbContext(builder.Options);

            return context;

        }

    }
}
