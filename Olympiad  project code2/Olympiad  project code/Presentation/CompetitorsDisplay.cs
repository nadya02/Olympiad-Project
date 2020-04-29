using Olympiad__project_code.Business;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;

namespace Olympiad__project_code.Presentation
{
    class CompetitorsDisplay
    {
        private CoachesBusiness coachesBusiness = new CoachesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();
        private ClubsBusiness clubsBusiness = new ClubsBusiness();
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CompetitorsBusiness competitorsBusiness = new CompetitorsBusiness();
        private TownsDisplay townsDisplay = new TownsDisplay();
        private ClubsDisplay clubsDisplay = new ClubsDisplay();
        private CoachesDisplay coachesDisplay = new CoachesDisplay();
        //Ъм тука имам въпорс

        public CompetitorsDisplay(OlympicGamesDBContext context)
        {
            competitorsBusiness = new CompetitorsBusiness(context);
        }


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
                Console.WriteLine(new string(' ', 2) + "Id" + new string(' ', 2)//6
                    + new string(' ', 13) + "FullName" + new string(' ', 13)//34
                    + new string(' ', 5) + "BirthDate" + new string(' ', 5)//19
                    + new string(' ', 2) + "Age" + new string(' ',2)//8
                    + new string(' ', 2) + "Gender" + new string(' ', 2)//10
                    + new string(' ', 2) + "Weight" + new string(' ', 2)//10
                    + new string(' ', 10) + "TownName" + new string(' ', 10)//28
                    + new string(' ', 18) + "ClubName" + new string(' ', 18)//44
                    + new string(' ', 10) + "CoachName" + new string(' ', 10)//29
                    + new string(' ', 6) + "SportName" + new string(' ', 6));//21
                Console.WriteLine(new string('-', 210));
                foreach (var competitor in competitors)
                {
                    var town = townsBusiness.GetTownById(competitor.TownId);
                    string clubName = GetClubAndCoachNames(competitor, "club");                   
                    string coachName = GetClubAndCoachNames(competitor, "coach");                   
                    var sport = sportsBusiness.GetSportById(competitor.SportId);
                    string output = $"{competitor.Id}" + new string(' ', 6 - competitor.Id.ToString().Length)
                        + $"{competitor.FullName}" + new string(' ', 34 - competitor.FullName.Length)
                        + $"{competitor.BirthDate}" + new string(' ', 19 - competitor.BirthDate.Length)
                        + new string(' ', 2) + $"{competitor.Age}" + new string(' ', 2)
                        + new string(' ', 3) + $"{competitor.Gender}" + new string(' ', 8 - competitor.Gender.Length)
                        + new string(' ', 3) + $"{competitor.Weight}" + new string(' ', 9 - competitor.Weight.Length)
                        + $"{town.Name}" + new string(' ', 28 - town.Name.Length)
                        + $"{clubName}" + new string(' ', 44 - clubName.Length)
                        + $"{coachName}" + new string(' ', 29 - coachName.Length)
                        + $"{sport.Name}" + new string(' ', 21 - sport.Name.Length);
                    Console.WriteLine(output); 
                }
                Console.WriteLine(new string('-', 210));
            }
        }

        public void GetCompetitorById()
        {
            Console.Write("Enter Competitor ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            var competitor = competitorsBusiness.GetCompetitorById(id);
            var town = townsBusiness.GetTownById(competitor.TownId);
            string clubName = GetClubAndCoachNames(competitor, "club");
            string coachName = GetClubAndCoachNames(competitor, "coach");
            var sport = sportsBusiness.GetSportById(competitor.SportId);
            if (competitor != null)
            {
                PrintCompetitor(competitor, town, clubName, coachName, sport);
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
            string clubName = GetClubAndCoachNames(competitor, "club");
            string coachName = GetClubAndCoachNames(competitor, "coach");
            var sport = sportsBusiness.GetSportById(competitor.SportId);
            if (competitor != null)
            {
                PrintCompetitor(competitor, town, clubName, coachName, sport);
            }
            else
            {
                Console.WriteLine($"There is no competitor with Name = {name} in the table!");
            }
        }
        public void AddCompetitor()
        {
            Competitors competitors = new Competitors();
            competitorsBusiness.AddCompetitors(CreateCompetitor(competitors));

            Console.WriteLine($"New competitor successfully added!");
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
                //competitor = ;
                competitorsBusiness.UpdateCompetitor(CreateCompetitor(competitor));

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
        private void PrintCompetitor(Competitors competitor, Towns town, string clubName, string coachName, Sports sport)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"ID: {competitor.Id}");
            Console.WriteLine($"Full Name: {competitor.FullName}");
            Console.WriteLine($"Birth Date: {competitor.BirthDate}");
            Console.WriteLine($"Age: {competitor.Age}");
            Console.WriteLine($"Gender: {competitor.Gender}");
            Console.WriteLine($"Town Name: {town.Name}");
            Console.WriteLine($"Club Name: {clubName}");
            Console.WriteLine($"Coach Name: {coachName}");
            Console.WriteLine($"Sport Name: {sport.Name}");
            Console.WriteLine(new string('-', 40));
        }
        private string GetClubAndCoachNames(Competitors competitor, string name)
        {
            if (name == "club")
            {
                string clubName = "";
                if (competitor.ClubId != null)
                {
                    clubName = clubsBusiness.GetClubById(competitor.ClubId).Name;
                }
                return clubName;
            }
            else
            {
                string coachName = "";
                if (competitor.CoachId != null)
                {
                    coachName = coachesBusiness.GetCoachById(competitor.CoachId).Name;
                }
                return coachName;
            }
        }
        private Competitors CreateCompetitor(Competitors competitor)
        {
            Console.Write("Enter Competitor Full Name: ");
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
            if (townsBusiness.GetTownByName(townName) == null)
            {
                Console.WriteLine($"There is no town with the name {townName}");
                Console.WriteLine("Do you want to create new town?");
                Console.WriteLine("1. Yes" + "\n" + "2. No");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    townsDisplay.AddTown();
                }
                else
                {
                    Console.Write("Enter existing town: ");
                    townName = Console.ReadLine();
                }
            }
            competitor.TownId = townsBusiness.GetTownByName(townName).Id;

            Console.WriteLine("Do your competitor have a club?" + "\n" + "1.Yes" + "\n" + "2.No");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.Write("Enter Competitor Club Name: ");
                string clubName = Console.ReadLine();
                if (clubsBusiness.GetClubByName(clubName) == null)
                {
                    Console.WriteLine($"There is no club with the name {clubName}");
                    Console.WriteLine("Do you want to create new club?");
                    Console.WriteLine("1. Yes" + "\n" + "2. No");
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        clubsDisplay.AddClub();
                    }
                    else
                    {
                        Console.WriteLine("Enter existing club: ");
                        clubName = Console.ReadLine();
                    }
                }
                competitor.ClubId = clubsBusiness.GetClubByName(clubName).Id;
            }
            else
            {
                competitor.ClubId = null;
            }

            Console.WriteLine("Do your competitor have a coach?" + "\n" + "1.Yes" + "\n" + "2.No");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.Write("Enter Competitor Coach Name: ");
                string coachName = Console.ReadLine();
                if (coachesBusiness.GetCoachByName(coachName) == null)
                {
                    Console.WriteLine($"There is no coach with the name {coachName}");
                    Console.WriteLine("Do you want to create new coach?");
                    Console.WriteLine("1. Yes" + "\n" + "2. No");
                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        coachesDisplay.AddCoach();
                    }
                    else
                    {

                        Console.WriteLine("Enter existing coach: ");
                        coachName = Console.ReadLine();
                    }
                }
                competitor.CoachId = coachesBusiness.GetCoachByName(coachName).Id;
            }
            else
            {
                competitor.CoachId = null;
            }

            Console.Write("Enter Competitor Sport Name: ");
            string sportName = Console.ReadLine();
            competitor.SportId = sportsBusiness.GetSportByName(sportName).Id;

            return competitor;
        }
    }
}
