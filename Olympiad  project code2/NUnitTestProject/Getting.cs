using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Olympiad__project_code.Models;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Business;


namespace NUnitTestProject
{
    public class Getting
    {
        [TestCase]
        public void GetsAllCompetitorsFromDatabase()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "GetsAllCompetitorsFromDatabaseDB")
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
                .UseInMemoryDatabase(databaseName: "GetCompetitorByIdDB")
                .Options;

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CompetitorsBusiness business = new CompetitorsBusiness(context);
                business.AddCompetitors(new Competitors { Id = 1, FullName = "Competitor1" });
                business.AddCompetitors(new Competitors { Id = 2, FullName = "Competitor2" });
                business.AddCompetitors(new Competitors { Id = 3, FullName = "Competitor3" });

                Competitors c = business.GetCompetitorById(1);
                Assert.AreEqual(1, c.Id);
            }
        }

        [TestCase]
        public void GetCompetitorByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "GetCompetitorByNameDB")
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
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "GetsAllSportsFromDatabaseDB")
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
                data.ToList().ForEach(t => context.Sports.Add(t));
                context.SaveChanges();

                Assert.AreEqual(data.ToList(), business.GetAllSports());
            }
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
                context.Sports.Add(new Sports { Id = 1, Name = "Sport1" });
                context.Sports.Add(new Sports { Id = 2, Name = "Sport2" });
                context.Sports.Add(new Sports { Id = 3, Name = "Sport3" });

                Sports c = business.GetSportById(1);
                Assert.AreEqual(1, c.Id);
            }
        }

        [TestCase]
        public void GetSportByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
             .UseInMemoryDatabase(databaseName: "GetSportByNameDB")
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
                data.ToList().ForEach(t => context.Sports.Add(t));
                context.SaveChanges();

                Sports t = business.GetSportByName("Sport1");
                Assert.AreEqual("Sport1", t.Name);
            }
        }      

        [TestCase]
        public void GetsAllCoachesFromDatabase()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "GetsAllCoachesFromDatabaseDB")
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

                Assert.AreEqual(data.ToList(), business.GetAllCoaches());
            }
        }

        [TestCase]
        public void GetCoachById()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                  .UseInMemoryDatabase(databaseName: "GetCoachByIdDB")
                  .Options;

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                CoachesBusiness business = new CoachesBusiness(context);
                business.AddCoach(new Coaches { Id = 1, Name = "Coach1" });
                business.AddCoach(new Coaches { Id = 2, Name = "Coach2" });
                business.AddCoach(new Coaches { Id = 3, Name = "Coach3" });

                Coaches c = business.GetCoachById(1);
                Assert.AreEqual(1, c.Id);
            }
        }

        [TestCase]
        public void GetCoachByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                .UseInMemoryDatabase(databaseName: "GetCoachByNameDB")
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
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
               .UseInMemoryDatabase(databaseName: "GetsAllClubsFromDatabaseDB")
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

                Assert.AreEqual(data.ToList(), business.GetAllClubs());
            }
        }


        [TestCase]
        public void GetClubById()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                  .UseInMemoryDatabase(databaseName: "GetClubByIdDB")
                  .Options;

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                ClubsBusiness business = new ClubsBusiness(context);
                business.AddClub(new Clubs { Id = 1, Name = "Club1" });
                business.AddClub(new Clubs { Id = 2, Name = "Club2" });
                business.AddClub(new Clubs { Id = 3, Name = "Club3" });

                Clubs c = business.GetClubById(1);
                Assert.AreEqual(1, c.Id);
            }
        }

        [TestCase]
        public void GetClubByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                          .UseInMemoryDatabase(databaseName: "GetClubByNameDB")
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
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
               .UseInMemoryDatabase(databaseName: "GetsAllCountriesFromDatabaseDB")
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
                data.ToList().ForEach(t => context.Countries.Add(t));
                context.SaveChanges();

                Assert.AreEqual(data.ToList(), business.GetAllCountries());
            }
        }


        [TestCase]
        public void GetCountryById()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                 .UseInMemoryDatabase(databaseName: "GetCounutyByIdDB")
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
                data.ToList().ForEach(t => context.Countries.Add(t));

                Countries c = business.GetCountryById(1);
                Assert.AreEqual(1, c.Id);
            }
        }

        [TestCase]
        public void GetCountryByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
            .UseInMemoryDatabase(databaseName: "GetCountryByNameDB")
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
                data.ToList().ForEach(t => context.Countries.Add(t));
                context.SaveChanges();

                Countries t = business.GetCountryByName("Country1");
                Assert.AreEqual("Country1", t.Name);
            }
        }

        [TestCase]
        public void GetsAllTownsFromDatabase()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                 .UseInMemoryDatabase(databaseName: "GetsAllCompetitorsFromDatabaseDB")
                 .Options;

            var data = new List<Towns>()
            {
                new Towns { Id =  1,Name = "Town1"},
                new Towns { Id = 2, Name = "Town2"},
                new Towns { Id = 3, Name = "Town3"},
            }.AsQueryable();

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                TownsBusiness business = new TownsBusiness(context);
                data.ToList().ForEach(c => business.AddTown(c));

                Assert.AreEqual(data.ToList(), business.GetAllTowns());
            }

        }


        [TestCase]
        public void GetTownById()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                 .UseInMemoryDatabase(databaseName: "GetTownByIdDB")
                 .Options;

            using (OlympicGamesDBContext context = new OlympicGamesDBContext(options))
            {
                TownsBusiness business = new TownsBusiness(context);
                business.AddTown(new Towns { Id = 1, Name = "Town1" });
                business.AddTown(new Towns { Id = 2, Name = "Town2" });
                business.AddTown(new Towns { Id = 3, Name = "Town3" });

                Towns c = business.GetTownById(1);
                Assert.AreEqual(1, c.Id);
            }
        }

        [TestCase]
        public void GetTownByName()
        {
            var options = new DbContextOptionsBuilder<OlympicGamesDBContext>()
                 .UseInMemoryDatabase(databaseName: "GetTownByNameDB")
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
