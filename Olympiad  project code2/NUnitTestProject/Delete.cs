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
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CompetitorsBusiness competitorsBusiness = new CompetitorsBusiness();
        private CoachesBusiness coachesBusiness = new TownsBusiness();
        private SportsBusiness sportsBusiness = new TownsBusiness();
        private CountriesBusiness countriesBusiness = new TownsBusiness();
        private ClubsBusiness clubsBusiness = new TownsBusiness();
        
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


        } public void DeleteCompetitor()
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


        } public void DeleteCoach()
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

            var service = new CoachesBusiness(mockContext.Object);
            data.ToList().ForEach(p => service.AddCoaches(p));
            service.DeleteCoachById(2);

            var expectedCount = 2; //брой продукти в data
            var result = service.GetAllCoaches();
            var actualCount = result.Count;
            
            /*
            foreach(Coaches t in mockContext.Object.Coaches.ToList())
            {
                TestContext.WriteLine(t.Id);
            }
            TestContext.WriteLine("\n");
            */

            //не бачка, понеже както казах фреймуърка е ебан
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Coach1", result[0].Name);//дали първият е Club1


        }public void DeleteClub()
        {
            var data = new List<Clubs>()
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
    }
}
