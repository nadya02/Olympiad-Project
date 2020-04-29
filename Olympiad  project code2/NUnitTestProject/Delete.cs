//Стоянката е най великият
//<3

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

    public class Delete
    {
        [TestCase]
        public void DeleteTown()
        {
               var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
               .UseInMemoryDatabase(databaseName: "TestDB")
               .Options;

              var data = new List<Towns>()
            {
                new Towns { Id =  1,Name = "Town1"},
                new Towns { Id = 2, Name = "Town2"},
                new Towns { Id = 3,Name = "Town3"},
            }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                TownsBusiness business = new TownsBusiness(context);
                data.ToList().ForEach(town => business.AddTown(town));

                business.DeleteTownById(2);

                Assert.AreEqual(2, business.GetAllTowns().Count);
            }



        }
        [TestCase]
        public void DeleteCompetitor()
        {
            var data = new List<Competitors>()
            {
                new Competitors { Id =  1,FullName = "Competitor1"},
                new Competitors { Id = 2, FullName = "Competitor2"},
                new Competitors { Id = 3,FullName = "Competitor3"},
            }.AsQueryable();
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                         .UseInMemoryDatabase(databaseName: "TestDB")
                         .Options;

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CompetitorsBusiness business = new CompetitorsBusiness(context);
                data.ToList().ForEach(competitor => business.AddCompetitors(competitor));

                business.DeleteCompetitorById(2);

                Assert.AreEqual(2, business.GetAllCompetitors().Count);
            }


        }

        [TestCase]
        public void DeleteCoach()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var data = new List<Coaches>()
            {
                new Coaches { Id =  1,Name = "Coach1"},
                new Coaches { Id = 2, Name = "Coach2"},
                new Coaches { Id = 3,Name = "Coach3"},
            }.AsQueryable();

            //да не забравяш options
            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CoachesBusiness business = new CoachesBusiness(context);
                data.ToList().ForEach(c => business.AddCoach(c));

                business.DeleteCoachById(2);
                Assert.AreEqual(2, business.GetAllCoaches().Count);
            }
        }
        [TestCase]
        public void DeleteClub()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            IQueryable<Clubs> data = new List<Clubs>()
            {
                new Clubs { Id = 1 ,Name = "Club1"},
                new Clubs { Id = 2, Name = "Club2"},
                new Clubs { Id = 3, Name = "Club3"},
                new Clubs { Id = 22, Name = "SektantiVegani"},
            }.AsQueryable();

            using(OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                ClubsBusiness business = new ClubsBusiness(context);
                data.ToList().ForEach(club1 => business.AddClub(club1));

                business.DeleteClubById(22);

                Assert.AreEqual(3, business.GetAllClubs().Count);
            }


        }
    }
}
