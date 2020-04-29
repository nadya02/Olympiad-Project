using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    class Display
    {
        private static OlympicGamesDBContext context = new OlympicGamesDBContext();

        private static CountriesDisplay countriesDisplay = new CountriesDisplay();
        private static TownsDisplay townsDisplay = new TownsDisplay(context);
        private static SportsDisplay sportsDisplay = new SportsDisplay();
        private static CoachesDisplay coachesDisplay = new CoachesDisplay();
        private static CompetitorsDisplay competitorsDisplay = new CompetitorsDisplay(context);
        private static ClubsDisplay clubsDisplay = new ClubsDisplay();

        ~Display()
        {
            context.Dispose();
        }

        public static void wait(double x)
        {
            DateTime t = DateTime.Now;
            DateTime tf = DateTime.Now.AddSeconds(x);

            while (t < tf)
            {
                t = DateTime.Now;
            }
        }

        private static int numberTable = -1;
        public static void Input()
        {           
            do
            {
                ShowMenu();

                try
                {
                    numberTable = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid command");
                    Console.WriteLine("Try again");
                    
                    wait(1);//IN SECONDS
                    Console.Clear();

                    continue;
                }
                
                //must add try catch for invalid input
                switch (numberTable)
                {
                    case 1:
                        ListOnlyAvailableOpperations();
                        break;
                    case 2:
                        ListOnlyAvailableOpperations();
                        break;
                    case 3:
                        ListAllOpperations();
                        break;
                    case 4:
                        ListAllOpperations();
                        break;
                    case 5:
                        ListAllOpperations();
                        break;
                    case 6:
                        ListAllOpperations();
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        continue;
                }
            } while (numberTable != 7);
        }
        private static void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "Olympic Games Rio 2016");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1. Sports");
            Console.WriteLine("2. Countries");
            Console.WriteLine("3. Towns");
            Console.WriteLine("4. Competitors");
            Console.WriteLine("5. Coaches");
            Console.WriteLine("6. Clubs");
            Console.WriteLine("0. Exit entry");

            Console.Write("Enter the number of the choosen table: ");
        }
        private static void ListAllOpperations()
        {
            Console.Clear();
            Console.WriteLine($"Number of chosen table: {numberTable}");//проверка и да се изведе името на таблицата
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Show entry by Id");
            Console.WriteLine("3. Show entry by  Name");
            Console.WriteLine("4. Add new entry");
            Console.WriteLine("5. Update entry");
            Console.WriteLine("6. Delete entry by ID");
            Console.WriteLine("0. Return");

            Console.WriteLine();
            Console.Write("Enter the number of the operation: ");

            int operation2 = int.Parse(Console.ReadLine());
            switch (operation2)
            {
                case 1:
                    GetAllEntries(numberTable);
                    break;
                case 2:
                    GetEntryById();
                    break;
                case 3:
                    GetEntryByName();
                    break;
                case 4:
                    AddNewEntry();
                    break;
                case 5:
                    UpdateEntry();
                    break;
                case 6:
                    DeleteEntry();
                    break;
                default:
                    break;
            }
        }

        private static void ListOnlyAvailableOpperations()
        {
            Console.Clear();
            Console.WriteLine($"Number of chosen table: {numberTable}");//проверка и да се изведе името на таблицата
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Show entry by Id");
            Console.WriteLine("3. Show entry by Name");
            Console.WriteLine("0. Return");
            Console.WriteLine();
            Console.Write("Enter the number of the operation: ");

            int operation = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    GetAllEntries(Display.numberTable);
                    break;
                case 2:
                    GetEntryById();
                    break;
                case 3:
                    GetEntryByName();
                    break;
                default:
                    break;
            }
        }
        private static void GetAllEntries(int numberTable)
        {
            Console.Clear();
            switch (numberTable)
            {
                case 1:
                    sportsDisplay.GetAllSports();
                    break;
                case 2:
                    countriesDisplay.GetAllCountries();
                    break;
                case 3:
                    townsDisplay.GetAllTowns();
                    break;
                case 4:
                    competitorsDisplay.GetAllCompetitors();
                    break;
                case 5:
                    coachesDisplay.GetAllCoaches();
                    break;
                case 6:
                    clubsDisplay.GetAllClubs();
                    break;
                default:
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to clear the screen..."); Console.ReadKey(); Console.Clear();
        }
        private static void AddNewEntry()
        {
            Console.Clear();
            if (numberTable == 3)
            {
                townsDisplay.AddTown();
            }
            else if (numberTable == 4)
            {
                competitorsDisplay.AddCompetitor();
            }
            else if (numberTable == 5)
            {
                coachesDisplay.AddCoach();
            }
            else if (numberTable == 6)
            {
                clubsDisplay.AddClub();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to clear the screen..."); Console.ReadKey(); Console.Clear();
        }
        private static void GetEntryByName()
        {
            Console.Clear();
            switch (numberTable)
            {
                case 1:                   
                    sportsDisplay.GetSportByName();
                    break;
                case 2:
                    countriesDisplay.GetCountryByName();
                    break;
                case 3:
                    townsDisplay.GetTownByName();
                    break;
                case 4:
                    competitorsDisplay.GetCompetitorByName();
                    break;
                case 5:
                    coachesDisplay.GetCoachByName();
                    break;
                case 6:
                    clubsDisplay.GetClubByName();                
                    break;
                default:
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to clear the screen..."); Console.ReadKey(); Console.Clear();
        }

        private static void GetEntryById()
        {
            Console.Clear();
            switch (numberTable)
            {
                case 1:                   
                    sportsDisplay.GetSportById();
                    break;
                case 2:
                    countriesDisplay.GetCountryById();
                    break;
                case 3:
                    townsDisplay.GetTownById();
                    break;
                case 4:
                    competitorsDisplay.GetCompetitorById();
                    break;
                case 5:
                    coachesDisplay.GetCoachById();
                    break;
                case 6:
                    clubsDisplay.GetClubById();                    
                    break;
                default:
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to clear the screen..."); Console.ReadKey(); Console.Clear();
        }

        private static void UpdateEntry()
        {
            Console.Clear();
            if (numberTable == 3)
            {
                townsDisplay.UpdateTown();
            }
            else if (numberTable == 4)
            {
                competitorsDisplay.UpdateCompetitor();
            }
            else if (numberTable == 5)
            {
                coachesDisplay.UpdateCoach();
            }
            else if (numberTable == 6)
            {
                clubsDisplay.UpdateClub();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to clear the screen..."); Console.ReadKey(); Console.Clear();
        }

        private static void DeleteEntry()
        {
            Console.Clear();
            if (numberTable == 3)
            {
                townsDisplay.DeleteTownById();
            }
            else if (numberTable == 4)
            {
                competitorsDisplay.DeleteCompetitorById();
            }
            else if (numberTable == 5)
            {
                coachesDisplay.DeleteCoachById();
            }
            else if (numberTable == 6)
            {
                clubsDisplay.DeleteClubById();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to clear the screen..."); Console.ReadKey(); Console.Clear();
        }
    }
}
