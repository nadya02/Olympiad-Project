using System;
using System.Collections.Generic;
using System.Text;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;

namespace Olympiad__project_code.Presentation
{
    class SportsDisplay
    {
        private SportsBusiness sportsBusiness = new SportsBusiness();

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
                Console.WriteLine("Id  |  Name");
                //????????????????????????????????????
                Console.WriteLine(new string('-', 30));

                foreach (var sport in sports)
                {
                    Console.WriteLine($"{sport.Id}     {sport.Name}");
                }
            }

        }
        public void GetSportById()
        {
            Console.Write("Enter Sport Id to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Sports sport = sportsBusiness.GetSportById(id);
            if (sport != null)
            {
                PrintSport(sport);
            }
        }
        public void GetSportByName()
        {
            Console.Write("Enter Sport Name to fetch: ");
            string name = Console.ReadLine();
            Sports sport = sportsBusiness.GetSportByName(name);
            if (sport != null)
            {
                PrintSport(sport);
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
