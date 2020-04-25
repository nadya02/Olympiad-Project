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
                    string clubName = "";
                    if(competitor.ClubId != null)
                    {
                        clubName = clubsBusiness.GetClubById(competitor.ClubId).Name;
                    }
                    string coachName = "";
                    if (competitor.CoachId != null)
                    {
                        coachName = coachesBusiness.GetCoachById(competitor.CoachId).Name;
                    }
                    var sport = sportsBusiness.GetSportById(competitor.SportId);
                    string output = $"{competitor.Id}" + new string(' ', 5 - competitor.Id.ToString().Length)//!!!!!!!!!!
                        + $"{competitor.FullName}" + new string(' ', 30)
                        + $"{competitor.BirthDate}" + new string(' ', 30)
                        + $"{competitor.Age}" + new string(' ', 5)
                        + $"{competitor.Gender}" + new string(' ', 10)
                        + $"{competitor.Weight}" + new string(' ', 10)
                        + $"{town.Name}" + new string(' ', 20)
                        + clubName + new string(' ', 30)
                        + coachName + new string(' ', 30)
                        + $"{sport.Name}" + new string(' ', 20);
                    Console.WriteLine(output);
                }
            }
        }

        public void GetCompetitorById()
        {
            Console.Write("Enter Competitor ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            var competitor = competitorsBusiness.GetCompetitorById(id);
            var town = townsBusiness.GetTownById(competitor.TownId);
            var club = clubsBusiness.GetClubById(competitor.ClubId);
            var coach = coachesBusiness.GetCoachById(competitor.CoachId);
            var sport = sportsBusiness.GetSportById(competitor.SportId);
            if (competitor != null)
            {
                PrintCompetitor(competitor, town, club, coach, sport);
            }
            else
            {
                Console.WriteLine($"There is no competitor with ID = {id} in the table!");
            }
        }

        public void GetCompetitorByName()
        {
            Console.Write("Enter Competitor Name to fetch: ");
            string name = Console.ReadLine();
            var competitor = competitorsBusiness.GetCompetitorByName(name);
            var town = townsBusiness.GetTownById(competitor.TownId);
            var club = clubsBusiness.GetClubById(competitor.ClubId);
            var coach = coachesBusiness.GetCoachById(competitor.CoachId);
            var sport = sportsBusiness.GetSportById(competitor.SportId);
            if (competitor != null)
            {
                PrintCompetitor(competitor, town, club, coach, sport);
            }
            else
            {
                Console.WriteLine($"There is no competitor with Name = {name} in the table!");
            }
        }

        private void PrintCompetitor(Competitors competitor, Towns town, Clubs club, Coaches coach, Sports sport)
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
        public void AddCompetitor()
        {
            var competitor = new Competitors();
            Console.Write("Enter Competitor Full Name: ");
            competitor.FullName = Console.ReadLine();
            Console.Write("Enter Competitor Birth Date: ");
            competitor.BirthDate = Console.ReadLine();
            Console.Write("Enter Competitor Age: ");
            competitor.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter Competitor Gender: ");
            competitor.Gender = Console.ReadLine();
            Console.Write("Enter Competitor Town Name: ");

            competitor.TownId = int.Parse(Console.ReadLine());//проверка дали има такъв град ако няма да се създаде???
            //string townName = Console.ReadLine();
           // if(townName)
            Console.Write("Enter Competitor Club Name: ");

            competitor.ClubId = int.Parse(Console.ReadLine());
            Console.Write("Enter Competitor Coach Name: ");

            competitor.CoachId = int.Parse(Console.ReadLine());
            Console.Write("Enter Competitor Sport Name: ");

            competitor.SportId = int.Parse(Console.ReadLine());
            competitorsBusiness.AddCompetitors(competitor);

            Console.WriteLine($"New competitor added to Competitors table!");
        }

        public void UpdateCompetitor()
        {
            Console.Write("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Competitors competitor = competitorsBusiness.GetCompetitorById(id);
            if (competitor == null)
            {
                Console.WriteLine($"There is no competitor with ID = {id} in the table!");
            }
            else
            {
                Console.Write("Enter Competitor Name: ");
                competitor.FullName = Console.ReadLine();
                Console.Write("Enter Competitor Birth Date: ");
                competitor.BirthDate = Console.ReadLine();
                Console.Write("Enter Competitor Age: ");
                competitor.Age = int.Parse(Console.ReadLine());
                Console.Write("Enter Competitor Gender: ");
                competitor.Gender = Console.ReadLine();
                Console.Write("Enter Competitor Weight: ");
                competitor.Weight = Console.ReadLine();

                Console.Write("Enter Competitor Town Name: ");
                string townName = Console.ReadLine();
                var town = townsBusiness.GetTownByName(townName);
                competitor.TownId = town.Id;

                Console.Write("Enter Competitor Club Id: ");
                string clubName = Console.ReadLine();
                var club = clubsBusiness.GetClubByName(clubName);
                competitor.ClubId = club.Id;

                Console.Write("Enter Competitor Coach Id: ");
                string coachName = Console.ReadLine();
                var coach = coachesBusiness.GetCoachByName(coachName);
                competitor.CoachId = coach.Id;


                Console.Write("Enter Sport Name: ");
                string sportName = Console.ReadLine();
                var sport = sportsBusiness.GetSportByName(sportName);
                competitor.SportId = sport.Id;

                competitorsBusiness.UpdateCompetitor(competitor);

                Console.WriteLine("Competitor successfully updated!");
            }
        }

        public void DeleteCompetitorById()
        {
            Console.Write("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());           
            if (competitorsBusiness.GetCompetitorById(id) == null)
            {
                Console.WriteLine($"There is no competitor with ID = {id} in the table!");
            }
            else
            {
                competitorsBusiness.DeleteCompetitorById(id);
                Console.WriteLine("Done!");
            }
        }
    }
}
