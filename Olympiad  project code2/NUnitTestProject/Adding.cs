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
        /*
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CompetitorsBusiness competitorsBusiness = new CompetitorsBusiness();
        private CoachesBusiness coachesBusiness = new CoachesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();
        private CountriesBusiness countriesBusiness = new CountriesBusiness();
        private ClubsBusiness clubsBusiness = new ClubsBusiness();
        */

        [TestCase]
        public void TestAddTowns()
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

            var service = new CompetitorsBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddCompetitors(p));

            Assert.AreEqual(data.ToList(), service.GetAllCompetitors());
        }   
        [TestCase]
        public void TestAddCoach()
        {
            var data = new List<Coaches>()
                {
                    new Coaches { Id =  1,Name = "Coach1"},
                    new Coaches { Id = 2, Name = "Coach2"},
                    new Coaches { Id = 3,Name = "Coach3"},
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Coaches>>();
            mockSet.As<IQueryable<Coaches>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Coaches>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Coaches>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Coaches>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<OlympicGamesDBContext>();
            mockContext.Setup(c => c.Coaches).Returns(mockSet.Object);

            var service = new CoachesBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddCoach(p));

            Assert.AreEqual(data.ToList(), service.GetAllCoaches());
        }  
        [TestCase]
        public void TestAddClub()
        {
            var data = new List<Clubs>()
                {
                    new Clubs { Id =  1,Name = "Club1"},
                    new Clubs { Id = 2, Name = "Club2"},
                    new Clubs { Id = 3,Name = "Club3"},
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Clubs>>();
            mockSet.As<IQueryable<Clubs>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Clubs>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Clubs>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Clubs>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<OlympicGamesDBContext>();
            mockContext.Setup(c => c.Clubs).Returns(mockSet.Object);

            var service = new ClubsBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddClub(p));

            Assert.AreEqual(data.ToList(), service.GetAllClubs());
        }   
    }
}
