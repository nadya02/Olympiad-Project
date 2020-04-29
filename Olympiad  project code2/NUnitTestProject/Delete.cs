﻿//Стоянката е най великият
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
        /*
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CompetitorsBusiness competitorsBusiness = new CompetitorsBusiness();
        private CoachesBusiness coachesBusiness = new CoachesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();
        private CountriesBusiness countriesBusiness = new CountriesBusiness();
        private ClubsBusiness clubsBusiness = new ClubsBusiness();
        */

        [TestCase]
        public void DeleteTown()
        {
            var data = new List<Towns>()
            {
                new Towns { Id =  1,Name = "Town1"},
                new Towns { Id = 2, Name = "Town2"},
                new Towns { Id = 3,Name = "Town3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Towns>>();
            mockSet.As<IQueryable<Towns>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Towns>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Towns>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Towns>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<OlympicGamesDBContext>();
            mockContext.Setup(c => c.Towns).Returns(mockSet.Object);

            var service = new TownsBusiness(mockContext.Object);
            data.ToList().ForEach(p => service.AddTown(p));
            service.DeleteTownById(2);

            var expectedCount = 2; //брой продукти в data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            
            /*
            foreach(Towns t in mockContext.Object.Towns.ToList())
            {
                TestContext.WriteLine(t.Id);
            }
            TestContext.WriteLine("\n");
            */

            //не бачка, понеже както казах фреймуърка е ебан
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//дали първият е Town1


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

            var mockSet = new Mock<DbSet<Competitors>>();
            mockSet.As<IQueryable<Competitors>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Competitors>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Competitors>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Competitors>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<OlympicGamesDBContext>();
            mockContext.Setup(c => c.Competitors).Returns(mockSet.Object);

            var service = new CompetitorsBusiness(mockContext.Object);
            data.ToList().ForEach(p => service.AddCompetitors(p));
            service.DeleteCompetitorById(2);

            var expectedCount = 2; //брой продукти в data
            var result = service.GetAllCompetitors();
            var actualCount = result.Count;
            
            /*
            foreach(Competitors t in mockContext.Object.Competitors.ToList())
            {
                TestContext.WriteLine(t.Id);
            }
            TestContext.WriteLine("\n");
            */

            //не бачка, понеже както казах фреймуърка е ебан
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Competitor1", result[0].FullName);//дали първият е Competitor1


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
