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
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CompetitorsBusiness competitorsBusiness = new CompetitorsBusiness();
        private CoachesBusiness coachesBusiness = new CoachesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();
        private CountriesBusiness countriesBusiness = new CountriesBusiness();
        private ClubsBusiness clubsBusiness = new ClubsBusiness();

        [TestCase]
        public void TestUpdateTowns()
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

            var service = new TownsBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddTown(p));

            Assert.AreEqual(data.ToList(), service.GetAllTowns());
        }   [TestCase]
        public void TestUpdateTowns()
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

            var service = new TownsBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddTown(p));

            Assert.AreEqual(data.ToList(), service.GetAllTowns());
        }   [TestCase]
        public void TestUpdateTowns()
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

            var service = new TownsBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddTown(p));

            Assert.AreEqual(data.ToList(), service.GetAllTowns());
        }   [TestCase]
        public void TestUpdateTowns()
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

            var service = new TownsBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddTown(p));

            Assert.AreEqual(data.ToList(), service.GetAllTowns());
        }   [TestCase]
        public void TestUpdateTowns()
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

            var service = new TownsBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddTown(p));

            Assert.AreEqual(data.ToList(), service.GetAllTowns());
        }   [TestCase]
        public void TestUpdateTowns()
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

            var service = new TownsBusiness(mockContext.Object); // service = контролер
            data.ToList().ForEach(p => service.AddTown(p));

            Assert.AreEqual(data.ToList(), service.GetAllTowns());
        }



    }
}
