using System;
using System.Collections.Generic;
using System.Text;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;

namespace Olympiad__project_code.Presentation
{
    /// <summary>
    /// Тhe <c>SportsDisplay</c> class in Presentation.
    /// This is the layer which is directly connected to SportsBusiness.
    /// </summary>
    /// <remarks>
    /// This class receive information from the user.
    /// Then it is passed to SportsBusiness.
    /// </remarks>
    class SportsDisplay
    {
        private SportsBusiness sportsBusiness;

        /// <summary>
        /// Makes the connection between Sports's display and business layer. 
        /// </summary>
        /// <param name="context"></param>
        public SportsDisplay(OlympicGamesDBContext context)
        {
            sportsBusiness = new SportsBusiness(context);
        }

        /// <summary>
        /// "Calls" method "GetAllSports" from SportsBusiness.
        /// Then it shows all sports in table Sports.
        /// </summary>
        public void GetAllSports()
        {
            Console.WriteLine("Sports: ");
            List<Sports> sports = sportsBusiness.GetAllSports();

            if (sports.Count == 0)
            {
                Console.WriteLine("There are no sports in the table!");
            }
            else
            {
                Console.WriteLine("Id" + new string(' ', 6) + "Name");               
                Console.WriteLine(new string('-', 27));

                foreach (var sport in sports)
                {
                    string output = $"{sport.Id}" + new string(' ', 6 - sport.Id.ToString().Length)
                        + $"{sport.Name}" + new string(' ', 21 - sport.Name.Length);
                    Console.WriteLine(output);
                }

                Console.WriteLine(new string('-', 27));
            }

        }

        /// <summary>
        /// After the user has inputed id, the program "Calls" method "GetSportById" from SportsBusiness.
        /// Shows the Sport who has this id. 
        /// </summary>
        public void GetSportById()
        {
            Console.Write("Enter Sport Id to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Sports sport = sportsBusiness.GetSportById(id);
            if (sport != null)
            {
                PrintSport(sport);
            }
            else
            {
                Console.WriteLine($"There is no sport with id = {id} in the table!");
            }
        }

        /// <summary>
        /// After the user has inputed name, the program "Calls" method "GetSportByName" from SportsBusiness.
        /// Shows the Sport who has this name. 
        /// </summary>
        public void GetSportByName()
        {
            Console.Write("Enter Sport Name to fetch: ");
            string name = Console.ReadLine();
            Sports sport = sportsBusiness.GetSportByName(name);
            if (sport != null)
            {
                PrintSport(sport);
            }
            else
            {
                Console.WriteLine($"There is no sport with name = {name} in the table!");
            }
        }

        private void PrintSport(Sports sport)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"ID: {sport.Id}");
            Console.WriteLine($"Name: {sport.Name}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
