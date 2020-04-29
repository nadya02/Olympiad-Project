//Стоянката е най великият
//<3

using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Olympiad__project_code.Models;
using Olympiad__project_code.Business_layer;
using Moq;

namespace NUnitTestProject
{

    public class Delete
    {
        private TownsBusiness townsBusiness = new TownsBusiness();
        
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


        } public void DeleteCoach()
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


        }public void DeleteClub()
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
    }
}
