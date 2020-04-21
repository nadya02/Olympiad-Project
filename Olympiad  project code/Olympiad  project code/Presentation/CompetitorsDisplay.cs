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
            Console.WriteLine("Enter Competitor Name: ");
            competitor.FullName = Console.ReadLine();
            Console.WriteLine("Enter SportID: ");//направи метод в SportBusiness -> GetSportByName
            competitor.SportId = int.Parse(Console.ReadLine());
            coachesBusiness.AddCoach(coach);
        }

        public void UpdateCoach()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Coaches coach = coachesBusiness.GetCoachById(id);
            if (coach == null)
            {
                Console.WriteLine($"There is no club with ID = {id} in the table!");
            }
            else
            {
                Console.WriteLine("Enter Coach Name: ");
                coach.Name = Console.ReadLine();
                Console.WriteLine("Enter SportID: ");//направи метод в SportBusiness -> GetSportByName
                coach.SportId = int.Parse(Console.ReadLine());
                coachesBusiness.UpdateCoach(coach);
            }
        }

        public void DeleteClubById()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Coaches coach = coachesBusiness.GetCoachById(id);
            if (coachesBusiness.GetCoachById(id) == null)
            {
                Console.WriteLine($"There is no club with ID = {id} in the table!");
            }
            else
            {
                coachesBusiness.DeleteCoachById(id);
            }
        }
    }
}
