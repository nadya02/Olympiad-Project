﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    class Display
    {
        private static CountriesDisplay countriesDisplay = new CountriesDisplay();
        private static TownsDisplay countriesDisplay = new TownsDisplay();
        private static SportsDisplay countriesDisplay = new SportsDisplay();
        private static CoachesDisplay countriesDisplay = new CoachesDisplay();
        private static CompetitorsDisplay countriesDisplay = new CompetitorsDisplay();
        private static ClubsDisplay countriesDisplay = new ClubsDisplay();

        public static void Input()
        {
        }
        private void ShowMenuAndTables()
        {
            /* Console.WriteLine(new string('-', 40));
             Console.WriteLine(new string(' ', 18) + "MENU");
             Console.WriteLine(new string('-', 40));
             Console.WriteLine("1. List all entries");
             Console.WriteLine("2. Show entry by Id");
            // Console.WriteLine("3. Add new entry");
             Console.WriteLine("3. Update entry");
             Console.WriteLine("4. Delete entry by ID");
             if()
             Console.WriteLine("0. Exit entry");*/

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


    }
}
