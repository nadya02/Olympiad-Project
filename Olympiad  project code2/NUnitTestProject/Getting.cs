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
        /*
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CompetitorsBusiness competitorsBusiness = new CompetitorsBusiness();
        private CoachesBusiness coachesBusiness = new CoachesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();
        private CountriesBusiness countriesBusiness = new CountriesBusiness();
        private ClubsBusiness clubsBusiness = new ClubsBusiness();
        */

        [TestCase]
        public void GetsAllCompetitorsFromDatabase()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var data = new List<Competitors>()
            {
                new Competitors { Id =  1,FullName = "Competitor1"},
                new Competitors { Id = 2, FullName = "Competitor2"},
                new Competitors { Id = 3,FullName = "Competitor3"},
            }.AsQueryable();

            using(OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CompetitorsBusiness business = new CompetitorsBusiness(context);
                data.ToList().ForEach(c => business.AddCompetitors(c));

                Assert.AreEqual(data.ToList(), business.GetAllCompetitors());
            }
        }

        [TestCase]
        public void GetCompetitorById()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CompetitorsBusiness business = new CompetitorsBusiness(context);
                business.AddCompetitors(new Competitors { Id = 1, FullName = "Yoanko" });
                business.AddCompetitors(new Competitors { Id = 2, FullName = "Nadeto" });
                business.AddCompetitors(new Competitors { Id = 3, FullName = "Gosheto" });

                Competitors c = business.GetCompetitorById(1);
                Assert.AreEqual(1, c.Id);
            }
        }

        [TestCase]
        public void GetCompetitorByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            var data = new List<Competitors>()
            {
                new Competitors { Id =  1,FullName = "Competitor1"},
                new Competitors { Id = 2, FullName = "Competitor2"},
                new Competitors { Id = 3,FullName = "Competitor3"},
            }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CompetitorsBusiness business = new CompetitorsBusiness(context);
                data.ToList().ForEach(c => business.AddCompetitors(c));

                Competitors c = business.GetCompetitorByName("Competitor1");
                Assert.AreEqual("Competitor1", c.FullName);
            }
        }
        
        [TestCase]
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

            var expectedCount = 3; //���� �������� � data
            var result = service.GetAllSports();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Sport1", result[0].Name);//���� ������� � Sport1

     
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
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

            var expectedCount = 3; //���� �������� � data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//���� ������� � Town1

     
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
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

            var expectedCount = 3; //���� �������� � data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//���� ������� � Town1

     
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
            data.ToList().ForEach(p => service.AddTown(p));

            var product = service.GetTownById(1);
            Assert.AreEqual(1, product.Id);
        }

        [TestCase]
        public void GetClubByName()
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
                data.ToList().ForEach(t => business.AddTown(t));

                Towns t = business.GetTownByName("Town1");
                Assert.AreEqual("Town1", t.Name);
            }
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

            var expectedCount = 3; //���� �������� � data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//���� ������� � Town1

     
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
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

            var expectedCount = 3; //���� �������� � data
            var result = service.GetAllTowns();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Town1", result[0].Name);//���� ������� � Town1

     
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
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

            var service = new TownsBusiness(mockContext.Object); // service = ���������
            data.ToList().ForEach(p => service.AddTown(p));

            var product = service.GetTownByName("Town1");
            Assert.AreEqual("Town1", product.Name);
        }
    }

}
