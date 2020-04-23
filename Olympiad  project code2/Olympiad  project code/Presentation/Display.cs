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

        private static int operation = -1;
        public static void Input()
        {           
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListOnlyAvailableOpperations(operation);
                        break;
                    case 2:
                        ListOnlyAvailableOpperations(operation);
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
                        break;
                }
                Console.WriteLine("Press any key to clear the screen..."); Console.ReadKey(); Console.Clear();
            } while (operation != 7);
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
                    GetAllEntries(operation);
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

        private static void ListOnlyAvailableOpperations(int numberTable)
        {
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Show entry by Id");
            Console.WriteLine("3. Delete entry by ID");
            Console.WriteLine("0. Return");
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
            if (operation == 3)
            {
                townsDisplay.AddTown();
            }
            else if (operation == 4)
            {
                competitorsDisplay.AddCompetitor();
            }
            else if (operation == 5)
            {
                coachesDisplay.AddCoach();
            }
            else if (operation == 6)
            {
                clubsDisplay.Add();
            }
            Console.Clear();
            ShowMenu();
        }
        private static void GetEntryById()
        {
            throw new NotImplementedException();
        }

        private static void GetEntryByName()
        {
            throw new NotImplementedException();
        }

        private static void UpdateEntry()
        {
            throw new NotImplementedException();
        }

        private static void DeleteEntry()
        {
            throw new NotImplementedException();
        }
    }
}
