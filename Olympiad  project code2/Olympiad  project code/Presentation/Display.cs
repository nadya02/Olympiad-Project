using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    class Display
    {
        private CountriesDisplay countriesDisplay = new CountriesDisplay();
        private TownsDisplay townsDisplay = new TownsDisplay();
        private SportsDisplay sportsDisplay = new SportsDisplay();
        private CoachesDisplay coachesDisplay = new CoachesDisplay();
        private CompetitorsDisplay competitorsDisplay = new CompetitorsDisplay();
        private ClubsDisplay clubsDisplay = new ClubsDisplay();

        public static void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
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
                        break;
                }
                Console.WriteLine("Press any key..."); Console.ReadKey(); Console.Clear();
            } while (operation != 7);
        }
        private static void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Olympic Games Rio 2016");
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
            Console.WriteLine("3. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Delete entry by ID");
            Console.WriteLine("0. Return");
        }
        private static void ListOnlyAvailableOpperations()
        {
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Show entry by Id");
            Console.WriteLine("3. Delete entry by ID");
            Console.WriteLine("0. Return");
        }
    }
}
