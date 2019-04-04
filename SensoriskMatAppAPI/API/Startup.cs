using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories.Interfaces;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Data;
using API.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.Features;
using System.Reflection;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().AddControllersAsServices();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SensoriskMatappDatabase")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IFreeTextAnswerRepository, FreeTextAnswerRepository>();
            services.AddScoped<IFreeTextQuestionRepository, FreeTextQuestionRepository>();
            services.AddScoped<IMultichoiceQuestion_OptionsAnswerRepository, MultichoiceQuestion_OptionsAnswerRepository>();
            services.AddScoped<IMultichoiceQuestion_OptionsRepository, MultichoiceQuestion_OptionsRepository>();
            services.AddScoped<IMultichoiceQuestionRepository, MultichoiceQuestionRepository>();
            services.AddScoped<IOptionsRepository, OptionsRepository>();
            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
            services.AddScoped<ISurvey_FreeTextQuestionRepository, Survey_FreeTextQuestionRepository>();
            services.AddScoped<ISurvey_MultichoiceQuestionRepository, Survey_MultichoiceQuestionRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

          

            if (env.IsDevelopment())
            {
                app.UseCors(
               builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod()
               .AllowAnyHeader().AllowCredentials());
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseCors(
               builder => builder.WithOrigins("https://sensoriskmatapp-test.azurewebsites.net").AllowAnyMethod()
               .AllowAnyHeader().AllowCredentials());
            }

            app.UseCors(
              builder => builder.WithOrigins("https://www.swish.bankgirot.se/qrg-swish/api/").AllowAnyMethod()
                  .AllowAnyHeader().AllowCredentials());

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
