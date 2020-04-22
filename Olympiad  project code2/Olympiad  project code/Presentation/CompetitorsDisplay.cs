using Olympiad__project_code.Business;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    class CompetitorsDisplay
    {
        private CoachesBusiness coachesBusiness = new CoachesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();
        private ClubsBusiness clubsBusiness = new ClubsBusiness();
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CompetitorsBusiness competitorsBusiness = new CompetitorsBusiness();

        public void GetAllCompetitors()
        {
            Console.WriteLine("Competitors: ");
            List<Competitors> competitors = competitorsBusiness.GetAllCompetitors();
            if (competitors.Count == 0)
            {
                Console.WriteLine("There are no competitors in the table!");
            }
            else
            {
                Console.WriteLine("Id" + new string(' ', 5)
                    + "FullName" + new string(' ', 30)
                    + "Birth Date" + new string(' ', 30)
                    + "Age" + new string(' ', 5)
                    + "Gender" + new string(' ', 10)
                    + "Weight" + new string(' ', 10)
                    + "Town Name" + new string(' ', 20)
                    + "Club Name" + new string(' ', 30)
                    + "CoachId" + new string(' ', 30)
                    + "SportId" + new string(' ', 20));
                Console.WriteLine(new string('-', 100));
                foreach (var competitor in competitors)
                {
                    var town = townsBusiness.GetTownById(competitor.TownId);
                    var club = clubsBusiness.GetClubById(competitor.ClubId);
                    var coach = coachesBusiness.GetCoachById(competitor.CoachId);
                    var sport = sportsBusiness.GetSportById(competitor.SportId);
                    Console.WriteLine($"{competitor.Id}" + new string(' ', 5)
                        + $"{competitor.FullName}" + new string(' ', 30)
                        + $"{competitor.BirthDate}" + new string(' ', 30)
                        + $"{competitor.Age}" + new string(' ', 5)
                        + $"{competitor.Gender}" + new string(' ', 10)
                        + $"{competitor.Weight}" + new string(' ', 10)
                        + $"{town.Name}" + new string(' ', 20)
                        + $"{club.Name}" + new string(' ', 30)
                        + $"{coach.Name}" + new string(' ', 30)
                        + $"{sport.Name}" + new string(' ', 20));
                }
            }
        }

        public void GetCompetitorById()
        {
            Console.WriteLine("Enter Competitor ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            var competitor = competitorsBusiness.GetCompetitorById(id);
            var town = townsBusiness.GetTownById(competitor.TownId);
            var club = clubsBusiness.GetClubById(competitor.ClubId);
            var coach = coachesBusiness.GetCoachById(competitor.CoachId);
            var sport = sportsBusiness.GetSportById(competitor.SportId);
            if (competitor == null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"ID: {competitor.Id}");
                Console.WriteLine($"Full Name: {competitor.FullName}");
                Console.WriteLine($"Birth Date: {competitor.BirthDate}");
                Console.WriteLine($"Age: {competitor.Age}");
                Console.WriteLine($"Gender: {competitor.Gender}");
                Console.WriteLine($"Town Name: {town.Name}");
                Console.WriteLine($"Club Name: {club.Name}");
                Console.WriteLine($"Coach Name: {coach.Name}");
                Console.WriteLine($"Sport Name: {sport.Name}");
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine($"There is no competitor with ID = {id} in the table!");
            }
        }

        public void AddCompetitor()
        {
            var competitor = new Competitors();
            Console.WriteLine("Enter Competitor Full Name: ");
            competitor.FullName = Console.ReadLine();
            Console.WriteLine("Enter Competitor Birth Date: ");
            competitor.BirthDate = Console.ReadLine();
            Console.WriteLine("Enter Competitor Age: ");
            competitor.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Competitor Gender: ");
            competitor.Gender = Console.ReadLine();
            Console.WriteLine("Enter Competitor Town Name: ");

            competitor.TownId = int.Parse(Console.ReadLine());//проверка дали има такъв град ако няма да се създаде???
            Console.WriteLine("Enter Competitor Club Name: ");

            competitor.ClubId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Competitor Coach Name: ");

            competitor.CoachId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Competitor Sport Name: ");

            competitor.SportId = int.Parse(Console.ReadLine());
            competitorsBusiness.AddCompetitors(competitor); 
        }

        public void UpdateCompetitor()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Competitors competitor = competitorsBusiness.GetCompetitorById(id);
            if (competitor == null)
            {
                Console.WriteLine($"There is no competitor with ID = {id} in the table!");
            }
            else
            {
                Console.WriteLine("Enter Competitor Name: ");
                competitor.FullName = Console.ReadLine();
                Console.WriteLine("Enter Competitor Birth Date: ");
                competitor.BirthDate = Console.ReadLine();
                Console.WriteLine("Enter Competitor Age: ");
                competitor.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Competitor Gender: ");
                competitor.Gender = Console.ReadLine();
                Console.WriteLine("Enter Competitor Weight: ");
                competitor.Weight = Console.ReadLine();

                Console.WriteLine("Enter Competitor Town Name: ");
                string townName = Console.ReadLine();
                var town = townsBusiness.GetTownByName(townName);
                competitor.TownId = town.Id;

                Console.WriteLine("Enter Competitor Club Id: ");
                string clubName = Console.ReadLine();
                var club = clubsBusiness.GetClubByName(clubName);
                competitor.ClubId = club.Id;

                Console.WriteLine("Enter Competitor Coach Id: ");
                string coachName = Console.ReadLine();
                var coach = coachesBusiness.GetCoachByName(coachName);
                competitor.CoachId = coach.Id;


                Console.WriteLine("Enter Sport Name: ");
                string sportName = Console.ReadLine();
                var sport = sportsBusiness.GetSportByName(sportName);
                competitor.SportId = sport.Id;

                competitorsBusiness.UpdateCompetitor(competitor);
            }
        }

        public void DeleteCompetitorById()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Competitors competitor = competitorsBusiness.GetCompetitorById(id);
            if (competitorsBusiness.GetCompetitorById(id) == null)
            {
                Console.WriteLine($"There is no competitor with ID = {id} in the table!");
            }
            else
            {
                competitorsBusiness.DeleteCompetitorById(id);
            }
        }
    }
}
