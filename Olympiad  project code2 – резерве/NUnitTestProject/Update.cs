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
    
    class Update
    {
        [TestCase]
        public void TestUpdateTowns()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                            .UseInMemoryDatabase(databaseName: "TestUpdateTownsDB")
                            .Options;

            var data = new List<Towns>()
                {
                    new Towns { Id =  1,Name = "Town1"},
                    new Towns { Id = 2, Name = "Town2"},
                    new Towns { Id = 3, Name = "Town3"},
                }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                TownsBusiness business = new TownsBusiness(context);
                data.ToList().ForEach(c => business.AddTown(c));

                Towns c = business.GetTownById(2); c.Name = "Town22";
                business.UpdateTown(c);

                Assert.AreEqual("Town22", business.GetTownById(2).Name);
            }
        }
        [TestCase]
        public void TestUpdateClubs()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestUpdateClubsDB")
                .Options;

            var data = new List<Clubs>()
                {
                    new Clubs { Id =  1,Name = "Club1"},
                    new Clubs { Id = 2, Name = "Club2"},
                    new Clubs { Id = 3,Name = "Club3"},
                }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                ClubsBusiness business = new ClubsBusiness(context);
                data.ToList().ForEach(c => business.AddClub(c));

                Clubs c = business.GetClubById(2); c.Name = "Club22";
                business.UpdateClub(c);

                Assert.AreEqual("Club22", business.GetClubById(2).Name);
            }
        }

        [TestCase]
        public void TestUpdateCoaches()
        {
           
                var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                    .UseInMemoryDatabase(databaseName: "TestUpdateCoachesDB")
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
                    data.ToList().ForEach(c => business.AddCoach(c));

                    Coaches c = business.GetCoachById(2); c.Name = "Coach22";
                    business.UpdateCoach(c);

                    Assert.AreEqual("Coach22", business.GetCoachById(2).Name);
                }
           
        }


        [TestCase]
        public void TestUpdateCompetitors()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                   .UseInMemoryDatabase(databaseName: "TestUpdateCompetitorsDB")
                   .Options;

            var data = new List<Competitors>()
                {
                    new Competitors { Id =  1, FullName = "Competitor1"},
                    new Competitors { Id = 2, FullName = "Competitor2"},
                    new Competitors { Id = 3, FullName = "Competitor3"},
                }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CompetitorsBusiness business = new CompetitorsBusiness(context);
                data.ToList().ForEach(c => business.AddCompetitors(c));

                Competitors c = business.GetCompetitorById(2); c.FullName = "Competitor22";
                business.UpdateCompetitor(c);

                Assert.AreEqual("Competitor22", business.GetCompetitorById(2).FullName);
            }
        }


    }
}
