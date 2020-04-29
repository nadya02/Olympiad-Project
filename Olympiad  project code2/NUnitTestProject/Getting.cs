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

            var expectedCount = 3; //брой продукти в data
            var result = service.GetAllSports();
            var actualCount = result.Count;
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual("Sport1", result[0].Name);//дали първият е Sport1

     
        }


        [TestCase]
        public void GetSportById()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
              .UseInMemoryDatabase(databaseName: "TestDB")
              .Options;

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                SportsBusiness business = new SportsBusiness(context);
                business.AddSport(new Sports { Id = 1, Name = "Sport1" });
                business.AddSport(new Sports { Id = 2, Name = "Sport2" });
                business.AddSport(new Sports { Id = 3, Name = "Sport3" });

                Sports c = business.GetSportById(1);
                Assert.AreEqual(1, c.Id);
            }
        }

        [TestCase]
        //Не може да се адват спортове
        public void GetSportByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
             .UseInMemoryDatabase(databaseName: "TestDB")
             .Options;

            var data = new List<Sports>()
            {
                new Sports { Id =  1,Name = "Sport1"},
                new Sports { Id = 2, Name = "Sport2"},
                new Sports { Id = 3, Name = "Sport3"},
            }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                SportsBusiness business = new SportsBusiness(context);
                data.ToList().ForEach(t => business.AddSport(t));

                Sports t = business.GetSportByName("Sport1");
                Assert.AreEqual("Sport1", t.Name);
            }
        }        
        [TestCase]
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
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
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

                Coaches c = business.GetCoachByName("Coach1");
                Assert.AreEqual("Coach1", c.Name);
            }
        }       
        [TestCase]
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
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                          .UseInMemoryDatabase(databaseName: "TestDB")
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
                data.ToList().ForEach(c => business.AddClub(c));

                Clubs c = business.GetClubByName("Club1");
                Assert.AreEqual("Club1", c.Name);
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
        //Не могат да се адват държави
        public void GetCountryByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
          .UseInMemoryDatabase(databaseName: "TestDB")
          .Options;

            var data = new List<Countries>()
            {
                new Countries { Id =  1,Name = "Country1"},
                new Countries { Id = 2, Name = "Country2"},
                new Countries { Id = 3, Name = "Country3"},
            }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CountriesBusiness business = new CountriesBusiness(context);
                data.ToList().ForEach(t => business.AddCountry(t));

                Countries t = business.GetCountryByName("Country1");
                Assert.AreEqual("Country1", t.Name);
            }
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
    }

}
