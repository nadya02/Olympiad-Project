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
    public class Getting
    {
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CompetitorsBusiness competitorsBusiness = new CompetitorsBusiness();
        private CoachesBusiness coachesBusiness = new CoachesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();
        private CountriesBusiness countriesBusiness = new CountriesBusiness();
        private ClubsBusiness clubsBusiness = new ClubsBusiness();

        [TestCase]
        public void GetsAllCompetitorsFromDatabase()
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

            var service = new CompetitorsBusiness(mockContext.Object );
            data.ToList().ForEach(p => service.AddCompetitors(p));

            var expectedCount = 3; //брой продукти в data
            var result = service.GetAllCompetitors();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Competitor1", result[0].FullName);//дали първият е Competitor1

     
        }


        [TestCase]
        public void GetCompetitorById()
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

            var product = service.GetCompetitorById(1);
            Assert.AreEqual(1, product.Id);
        }

        [TestCase]
        public void GetCompetitorByName()
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

            var product = service.GetCompetitorByName("Competitor1");
            Assert.AreEqual("Competitor1", product.FullName);
        }        [TestCase]
        public void GetsAllSportsFromDatabase()
        {


            var data = new List<Sports>()
            {
                new Sports { Id =  1,Name = "Sport1"},
                new Sports { Id = 2, Name = "Sport2"},
                new Sports { Id = 3,Name = "Sport3"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Sports>>();
            mockSet.As<IQueryable<Sports>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Sports>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Sports>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Sports>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<OlympicGamesDBContext>();
            mockContext.Setup(c => c.Sports).Returns(mockSet.Object);

            var service = new SportsBusiness(mockContext.Object );
            data.ToList().ForEach(p => mockSet.Object.Add(p));

            var expectedCount = 3; //брой продукти в data
            var result = service.GetAllSports();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Sport1", result[0].Name);//дали първият е Sport1

     
        }


        [TestCase]
        public void GetSportById()
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

            var product = service.GetTownById(1);
            Assert.AreEqual(1, product.Id);
        }

        [TestCase]
        public void GetSportByName()
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

            var product = service.GetTownByName("Town1");
            Assert.AreEqual("Town1", product.Name);
        }        [TestCase]
        public void GetsAllCoachesFromDatabase()
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

            var service = new TownsBusiness(mockContext.Object );
            data.ToList().ForEach(p => service.AddTown(p));

            var expectedCount = 3; //брой продукти в data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//дали първият е Town1

     
        }


        [TestCase]
        public void GetCoachById()
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

            var product = service.GetTownById(1);
            Assert.AreEqual(1, product.Id);
        }

        [TestCase]
        public void GetCoachByName()
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

            var product = service.GetTownByName("Town1");
            Assert.AreEqual("Town1", product.Name);
        }        [TestCase]
        public void GetsAllClubsFromDatabase()
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

            var service = new TownsBusiness(mockContext.Object );
            data.ToList().ForEach(p => service.AddTown(p));

            var expectedCount = 3; //брой продукти в data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//дали първият е Town1

     
        }


        [TestCase]
        public void GetClubById()
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

            var product = service.GetTownById(1);
            Assert.AreEqual(1, product.Id);
        }

        [TestCase]
        public void GetClubByName()
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

            var product = service.GetTownByName("Town1");
            Assert.AreEqual("Town1", product.Name);
        }  
        [TestCase]
        public void GetsAllCountriesFromDatabase()
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

            var service = new TownsBusiness(mockContext.Object );
            data.ToList().ForEach(p => service.AddTown(p));

            var expectedCount = 3; //брой продукти в data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//дали първият е Town1

     
        }


        [TestCase]
        public void GetCountryById()
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

            var product = service.GetTownById(1);
            Assert.AreEqual(1, product.Id);
        }

        [TestCase]
        public void GetCountryByName()
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

            var product = service.GetTownByName("Town1");
            Assert.AreEqual("Town1", product.Name);
        }
      [TestCase]
        public void GetsAllTownsFromDatabase()
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

            var service = new TownsBusiness(mockContext.Object );
            data.ToList().ForEach(p => service.AddTown(p));

            var expectedCount = 3; //брой продукти в data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//дали първият е Town1

     
        }


        [TestCase]
        public void GetTownById()
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

            var product = service.GetTownById(1);
            Assert.AreEqual(1, product.Id);
        }

        [TestCase]
        public void GetTownByName()
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

            var product = service.GetTownByName("Town1");
            Assert.AreEqual("Town1", product.Name);
        }
    }

}
