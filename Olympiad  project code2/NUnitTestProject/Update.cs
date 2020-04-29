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

            Towns t = service.GetTownById(1);
            t.Name = "NewTown";

            service.UpdateTown(t);
            Assert.AreEqual("NewTown", t.Name);
        } 
        [TestCase]
        public void TestUpdateClubs()
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

            Clubs t = service.GetClubById(1);
            t.Name = "NewClub";

            service.UpdateClub(t);
            Assert.AreEqual("NewClub", t.Name);
        }
        
        [TestCase]
        public void TestUpdateCoaches()
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


            Coaches t = service.GetCoachById(1);
            t.Name = "NewCoach";

            service.UpdateCoach(t);
            Assert.AreEqual("NewCoach", t.Name);
        }
        
        [TestCase]
        public void TestUpdateCompetitors()
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

            Competitors t = service.GetCompetitorById(1);
            t.FullName = "NewCompetitor";

            service.UpdateCompetitor(t);
            Assert.AreEqual("NewCompetitor", t.FullName);
        }

     
    }
}
