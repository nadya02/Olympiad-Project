using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    class Display
    {
        private static CountriesDisplay countriesDisplay = new CountriesDisplay();
        private static TownsDisplay townsDisplay = new TownsDisplay();
        private static SportsDisplay sportsDisplay = new SportsDisplay();
        private static CoachesDisplay coachesDisplay = new CoachesDisplay();
        private static CompetitorsDisplay competitorsDisplay = new CompetitorsDisplay();
        private static ClubsDisplay clubsDisplay = new ClubsDisplay();

        private static int numberTable = -1;
        public static void Input()
        {           
            do
            {
                ShowMenu();
                numberTable = int.Parse(Console.ReadLine());
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
                    case 0://???????
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key to clear the screen..."); Console.ReadKey(); Console.Clear();
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
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Show entry by Id");
            Console.WriteLine("3. Show entry by  Name");
            Console.WriteLine("4. Add new entry");
            Console.WriteLine("5. Update entry");
            Console.WriteLine("6. Delete entry by ID");
            Console.WriteLine("0. Return");

            int operation2 = int.Parse(Console.ReadLine());//?
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
                case 0://?????????
                    break;
                default:
                    break;
            }
        }

        private static void ListOnlyAvailableOpperations()
        {
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Show entry by Id");
            Console.WriteLine("3. Delete entry by ID");
            Console.WriteLine("0. Return");

            int operation = int.Parse(Console.ReadLine());//?
            switch (operation)
            {
                case 1:
                    GetAllEntries(Display.numberTable);
                    break;
                case 2:
                    GetEntryById();
                    break;
                case 3:
                    DeleteEntry();
                    break;
                case 0://??????
                    break;
                default:
                    break;
            }
        }
        private static void GetAllEntries(int numberTable)
        {
            switch (numberTable)
            {
                case 1:
                    Console.Clear();
                    sportsDisplay.GetAllSports();
                    ShowMenu();
                    break;
                case 2:
                    Console.Clear();
                    countriesDisplay.GetAllCountries();
                    ShowMenu();
                    break;
                case 3:
                    Console.Clear();
                    townsDisplay.GetAllTowns();
                    ShowMenu();
                    break;
                case 4:
                    Console.Clear();
                    competitorsDisplay.GetAllCompetitors();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    coachesDisplay.GetAllCoaches();
                    ShowMenu();
                    break;
                case 6:
                    Console.Clear();
                    clubsDisplay.GetAllClubs();
                    ShowMenu();
                    break;
                default:
                    break;
            }
        }
        private static void AddNewEntry()
        {
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
            Console.Clear();
            ShowMenu();
        }
        private static void GetEntryByName()
        {
            switch (numberTable)
            {
                case 3:
                    Console.Clear();
                    townsDisplay.GetTownByName();
                    ShowMenu();
                    break;
                case 4:
                    Console.Clear();
                    competitorsDisplay.GetCompetitorByName();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    coachesDisplay.GetCoachByName();
                    ShowMenu();
                    break;
                case 6:
                    Console.Clear();
                    clubsDisplay.GetClubByName();
                    ShowMenu();
                    break;
                case 0://??
                    break;
                default:
                    break;
            }
        }

        private static void GetEntryById()
        {
            switch (numberTable)
            {
                case 1:
                    Console.Clear();
                    sportsDisplay.GetSportById();
                    ShowMenu();
                    break;
                case 2:
                    Console.Clear();
                    countriesDisplay.GetCountryById();
                    ShowMenu();
                    break;
                case 3:
                    Console.Clear();
                    townsDisplay.GetTownById();
                    ShowMenu();
                    break;
                case 4:
                    Console.Clear();
                    competitorsDisplay.GetCompetitorById();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    coachesDisplay.GetCoachById();
                    ShowMenu();
                    break;
                case 6:
                    Console.Clear();
                    clubsDisplay.GetClubById();
                    ShowMenu();
                    break;
                case 0://??
                    break;
                default:
                    break;
            }
        }

        private static void UpdateEntry()
        {
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
            Console.Clear();
            ShowMenu();
        }

        private static void DeleteEntry()
        {
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
            Console.Clear();
            ShowMenu();
        }
    }
}
