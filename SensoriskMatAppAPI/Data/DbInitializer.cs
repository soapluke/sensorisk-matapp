using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DbInitializer
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            var organisations = new List<Organisation>
            {
                new Organisation {Name="Arla", Email="arla@gmail.com", Password="test12"},
                new Organisation {Name="Pepsi", Email="pepsi@gmail.com", Password="test12"}
            };

            organisations.ForEach(o => context.Organisation.Add(o));
            context.SaveChanges();

            var surveys = new List<Survey>
            {
                new Survey {Title="Test survey 1", Description="Hur smakar denna produkt?", Code=1234, StartDate=DateTime.Now, EndDate =DateTime.Now.AddMonths(1), OrganisationID=1},
                new Survey {Title="Test survey 2", Description="Hur smakar denna produkt?", Code=1235, StartDate =DateTime.Now, EndDate =DateTime.Now.AddMonths(5), OrganisationID=1},
                new Survey {Title="Test survey 3", Description="Hur smakar denna produkt?", Code=1236, StartDate=DateTime.Now, EndDate =DateTime.Now.AddMonths(3), OrganisationID=2},
                new Survey {Title="GRÅÄRTSRULLE", Description="Bedöm gråärtsrulle; hur du upplever och vad du tycker om den", Code=1337, StartDate=DateTime.Now, EndDate =DateTime.Now.AddMonths(3), OrganisationID=1}
            };

            surveys.ForEach(s => context.Survey.Add(s));
            context.SaveChanges();

            var freetextQuestions = new List<FreetextQuestion>
            {
                new FreetextQuestion {Question="Tyckte du om denna produkt?"},
                new FreetextQuestion {Question="Gillar du smör"},
                new FreetextQuestion {Question="Tycker du om salt?"}
            };

            freetextQuestions.ForEach(f => context.FreetextQuestion.Add(f));
            context.SaveChanges();

            var freetextAnswers = new List<FreetextAnswer>
            {
                new FreetextAnswer{FreetextQuestionID=1, Answer="Jag tycker det var gott"},
                new FreetextAnswer{FreetextQuestionID=3, Answer="Jag tycker det var gott"},
                new FreetextAnswer{FreetextQuestionID=1, Answer="Det kanske låter gott"},
                new FreetextAnswer{FreetextQuestionID=2, Answer="Jag älskar smör."},
                new FreetextAnswer{FreetextQuestionID=2, Answer="Jag tycker det var gott"}
            };
            freetextAnswers.ForEach(fa => context.FreetextAnswer.Add(fa));
            context.SaveChanges();

            var multichoiceQuestions = new List<MultichoiceQuestion>
            {
                new MultichoiceQuestion {Question="Fyll i dem alternativen du tycker stämmer.", OwnOption = false},
                new MultichoiceQuestion {Question="Hur tycker du att maten smakade?", OwnOption = true},
                new MultichoiceQuestion {Question="Jag har läst och förstått texten ovan och väljer att vara med i undersökningen.", OwnOption = false},
                new MultichoiceQuestion {Question="Övergripande, vad tycker du om GRÅÄRTSRULLEN?", OwnOption = false},
                new MultichoiceQuestion {Question="Kryssa för de ord du tycker stämmer in på GRÅÄRTSRULLEN (välj så många ord du vill)", OwnOption = true},
                new MultichoiceQuestion {Question="Kryssa för de ord du tycker stämmer in på hur du skulle vilja ha GRÅÄRTSRULLEN, hur din GODASTE/BÄSTA skulle vara (välj så många ord du vill)", OwnOption = true},
                new MultichoiceQuestion {Question="Din ålder?", OwnOption = false}
            };

            multichoiceQuestions.ForEach(mq => context.MultichoiceQuestion.Add(mq));
            context.SaveChanges();

            var options = new List<Options>
            {
                new Options{Option="Sött"},
                new Options{Option="Salt"},
                new Options{Option="Beskt"},
                new Options{Option="Umami"},
                new Options{Option="Surt"},
                new Options{Option="Hett"},
                new Options{Option="Krispig"},
                new Options{Option="Ja"},
                new Options{Option="Nej"},
                new Options{Option="Superbra"},
                new Options{Option="Mycket bra"},
                new Options{Option="Bra"},
                new Options{Option="Varken bra eller dåligt"},
                new Options{Option="Dåligt"},
                new Options{Option="Mycket dåligt"},
                new Options{Option="Superdåligt"},
                new Options{Option="Smakrik"},
                new Options{Option="Unik/ny"},
                new Options{Option="Fräsch"},
                new Options{Option="Naturlig"},
                new Options{Option="Vegetarisk"},
                new Options{Option="Hantverksmässig"},
                new Options{Option="Grön"},
                new Options{Option="Smaklös"},
                new Options{Option="Gammal/traditionell"},
                new Options{Option="Trist/tråkig"},
                new Options{Option="Tillgjord"},
                new Options{Option="Köttig"},
                new Options{Option="Industriell"},
                new Options{Option="9 år eller yngre"},
                new Options{Option="10 – 12 år"},
                new Options{Option="13 – 14 år"},
                new Options{Option="15 – 16 år"},
                new Options{Option="17 – 18 år"},
                new Options{Option="19 år eller äldre"}

            };

            options.ForEach(o => context.Options.Add(o));
            context.SaveChanges();

            var chapters = new List<Chapter>
            {
                new Chapter{Title="Gråbönan", Description="Detta kapitel handlar om den omtalade gråbönan."},
                new Chapter{Title="Mjölk", Description="Detta kapitel handlar om mjölk. Mjölk är vitt och kommer från kon."},
                new Chapter{Title="Gluten", Description="Detta kapitel handlar om gluten. Om du är glutenintolerant ska du inte äta spagetti."},
                new Chapter{Title="Gråärtsrulle", Description="Gråärtsrulle, bu eller bä?"},
            };

            chapters.ForEach(c => context.Chapters.Add(c));
            context.SaveChanges();

            var survey_freetextQuestions = new List<Survey_FreetextQuestion>
            {
                new Survey_FreetextQuestion {FreetextQuestionID=1, SurveyId=1, ChapterID=1, Order=1},
                new Survey_FreetextQuestion {FreetextQuestionID=1, SurveyId=2, ChapterID=1, Order=1},
                new Survey_FreetextQuestion {FreetextQuestionID=3, SurveyId=1, ChapterID=3, Order=2},
                new Survey_FreetextQuestion {FreetextQuestionID=2, SurveyId=1, ChapterID=3, Order=5},
                new Survey_FreetextQuestion {FreetextQuestionID=1, SurveyId=3, ChapterID=2, Order=1}
            };

            survey_freetextQuestions.ForEach(sf => context.Survey_FreetextQuestion.Add(sf));
            context.SaveChanges();

            var survey_MultichoiceQuestions = new List<Survey_MultichoiceQuestion>
            {
                new Survey_MultichoiceQuestion{SurveyID=1, MultichoiceQuestionID=1, ChapterID=1, Order=3},
                new Survey_MultichoiceQuestion{SurveyID=1, MultichoiceQuestionID=2, ChapterID=2, Order=4},
                new Survey_MultichoiceQuestion{SurveyID=2, MultichoiceQuestionID=1, ChapterID=2, Order=2},
                new Survey_MultichoiceQuestion{SurveyID=3, MultichoiceQuestionID=1, ChapterID=3, Order=2},
                new Survey_MultichoiceQuestion{SurveyID=4, MultichoiceQuestionID=3, ChapterID=4, Order=1},
                new Survey_MultichoiceQuestion{SurveyID=4, MultichoiceQuestionID=4, ChapterID=4, Order=2},
                new Survey_MultichoiceQuestion{SurveyID=4, MultichoiceQuestionID=5, ChapterID=4, Order=3},
                new Survey_MultichoiceQuestion{SurveyID=4, MultichoiceQuestionID=6, ChapterID=4, Order=4},
                new Survey_MultichoiceQuestion{SurveyID=4, MultichoiceQuestionID=7, ChapterID=4, Order=5},
            };

            survey_MultichoiceQuestions.ForEach(sm => context.Survey_MultichoiceQuestion.Add(sm));
            context.SaveChanges();

            var multichoiceQuestion_Options = new List<MultichoiceQuestion_Options>
            {
                new MultichoiceQuestion_Options {MultichoiceQuestionID =1 , OptionsID=1},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =1 , OptionsID=2},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =1 , OptionsID=3},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =1 , OptionsID=4},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =2 , OptionsID=1},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =2 , OptionsID=5},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =2 , OptionsID=3},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =2 , OptionsID=6},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =3 , OptionsID=8},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =3 , OptionsID=9},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =4 , OptionsID=10},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =4 , OptionsID=11},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =4 , OptionsID=12},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =4 , OptionsID=13},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =4 , OptionsID=14},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =4 , OptionsID=15},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =4 , OptionsID=16},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=17},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=18},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=19},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=20},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=21},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=22},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=23},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=24},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=25},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=26},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=27},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=28},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =5 , OptionsID=29},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=17},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=18},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=19},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=20},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=21},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=22},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=23},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=24},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=25},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=26},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=27},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=28},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =6 , OptionsID=29},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =7 , OptionsID=30},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =7 , OptionsID=31},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =7 , OptionsID=32},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =7 , OptionsID=33},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =7 , OptionsID=34},
                new MultichoiceQuestion_Options {MultichoiceQuestionID =7 , OptionsID=35},
            };

            multichoiceQuestion_Options.ForEach(mqo => context.MultichoiceQuestion_Options.Add(mqo));
            context.SaveChanges();

            var multichoiceQuestion_OptionsAnswers = new List<MultichoiceQuestion_OptionsAnswer>
            {
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=1, OptionsID=1},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=1, OptionsID=1},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=1, OptionsID=2},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=1, OptionsID=4},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=2, OptionsID=5},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=2, OptionsID=6},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=4, OptionsID=10},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=4, OptionsID=10},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=4, OptionsID=13},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=4, OptionsID=13},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=4, OptionsID=14},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=4, OptionsID=16},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=4, OptionsID=16},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=5, OptionsID=23},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=5, OptionsID=23},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=5, OptionsID=25},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=5, OptionsID=27},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=5, OptionsID=27},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=5, OptionsID=27},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=6, OptionsID=23},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=6, OptionsID=23},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=6, OptionsID=23},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=6, OptionsID=25},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=6, OptionsID=27},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=6, OptionsID=27},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=6, OptionsID=27},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=7, OptionsID=30},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=7, OptionsID=30},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=7, OptionsID=31},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=7, OptionsID=33},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=7, OptionsID=33},
                new MultichoiceQuestion_OptionsAnswer {MultichoiceQuestionID=7, OptionsID=34},

            };

            multichoiceQuestion_OptionsAnswers.ForEach(mo => context.MultichoiceQuestion_OptionsAnswer.Add(mo));
            context.SaveChanges();
        }
    }
}
