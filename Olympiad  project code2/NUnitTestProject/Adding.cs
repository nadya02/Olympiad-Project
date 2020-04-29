using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Olympiad__project_code.Models;
using Olympiad__project_code.Business_layer;
using Moq;
using Olympiad__project_code.Business;

namespace NUnitTestProject
{
    class Adding
    {
        [TestCase]
        public void TestAddTowns()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestAddTownsDB")
                .Options;

            var data = new List<Towns>()
                {
                    new Towns { Id =  1,Name = "Town1"},
                    new Towns { Id = 2, Name = "Town2"},
                    new Towns { Id = 3, Name = "Town3"},
                }.AsQueryable();

            using(OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                TownsBusiness business = new TownsBusiness(context);
                data.ToList().ForEach(t => business.AddTown(t));

                Assert.AreEqual(data.ToList(), business.GetAllTowns());
            }
        }   

        [TestCase]
        public void TestAddCompetitor()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                 .UseInMemoryDatabase(databaseName: "TestAddCompetitorDB")
                 .Options;

            var data = new List<Competitors>()
                {
                    new Competitors { Id =  1,FullName = "Competitor1"},
                    new Competitors { Id = 2, FullName = "Competitor2"},
                    new Competitors { Id = 3, FullName = "Competitor3"},
                }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CompetitorsBusiness business = new CompetitorsBusiness(context);
                data.ToList().ForEach(t => business.AddCompetitors(t));

                Assert.AreEqual(data.ToList(), business.GetAllCompetitors());
            }
        }   
        [TestCase]
        public void TestAddClub()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestAddClubDB")
                .Options;

            var data = new List<Clubs>()
                {
                    new Clubs { Id =  1,Name = "Club1"},
                    new Clubs { Id = 2, Name = "Club2"},
                    new Clubs { Id = 3, Name = "Club3"},
                }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                ClubsBusiness business = new ClubsBusiness(context);
                data.ToList().ForEach(t => business.AddClub(t));

                Assert.AreEqual(data.ToList(), business.GetAllClubs());
            }
        }  
        [TestCase]
        public void TestAddCoach()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
               .UseInMemoryDatabase(databaseName: "TestAddCoachDB")
               .Options;

            var data = new List<Coaches>()
                {
                    new Coaches { Id =  1,Name = "Coach1"},
                    new Coaches { Id = 2, Name = "Coach2"},
                    new Coaches { Id = 3, Name = "Coach3"},
                }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CoachesBusiness business = new CoachesBusiness(context);
                data.ToList().ForEach(t => business.AddCoach(t));

                Assert.AreEqual(data.ToList(), business.GetAllCoaches());
            }
        }   
    }
}
