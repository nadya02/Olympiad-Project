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
                Console.WriteLine("There are no sports in the table. ");
            }
            else
            {
                Console.WriteLine("Id  |  Name");
                //????????????????????????????????????
                Console.WriteLine(new string('-', 30));

                foreach (var item in sports)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                }
            }

        }
        public void GetSportById()
        {
            Console.WriteLine("Enter Sport Id to fetch:");
            int id = int.Parse(Console.ReadLine());
            Sports sport = sportsBusiness.GetSportById(id);
            if (sport != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"{sport.Id}     {sport.Name}");
                Console.WriteLine(new string('-', 40));
            }

        }
    }
}
