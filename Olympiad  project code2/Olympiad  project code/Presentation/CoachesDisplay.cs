﻿using Olympiad__project_code.Business;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    class CoachesDisplay
    {
        private CoachesBusiness coachesBusiness = new CoachesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();

        public void GetAllCoaches()
        {
            Console.WriteLine("Coaches: ");
            List<Coaches> coaches = coachesBusiness.GetAllCoaches();
            if(coaches.Count == 0)
            {
                Console.WriteLine("There are no coaches in the table!");
            }
            else
            {
                Console.WriteLine("Id" + new string(' ', 5) + "Name" + new string(' ', 20) + "Sport Name");
                Console.WriteLine(new string('-', 30));
                foreach (var coach in coaches)
                {
                    var sport = sportsBusiness.GetSportById(coach.SportId);
                    Console.WriteLine($"{coach.Id}" + new string(' ', 5) + $"{coach.Name}" + new string(' ', 20) + $"{sport.Name}");
                }
            }
        }

        public void GetCoachById()
        {
            Console.Write("Enter Coach ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            var coach = coachesBusiness.GetCoachById(id);
            var sport = sportsBusiness.GetSportById(coach.SportId);
            if (coach != null)
            {
                PrintCoach(coach, sport);
            }
            else
            {
                Console.WriteLine($"There is no coach with ID = {id} in the table!");
            }
        }
        public void GetCoachByName()
        {
            Console.Write("Enter Coach Name to fetch: ");
            string name = Console.ReadLine();
            var coach = coachesBusiness.GetCoachByName(name);
            var sport = sportsBusiness.GetSportById(coach.SportId);
            if (coach != null)
            {
                PrintCoach(coach, sport);
            }
        }

        private void PrintCoach(Coaches coach,  Sports sport)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"ID: {coach.Id}");
            Console.WriteLine($"Name: {coach.Name}");
            Console.WriteLine($"Sport Name: {sport.Name}");
            Console.WriteLine(new string('-', 40));
        }
        public void AddCoach()
        {
            var coach = new Coaches();
            Console.Write("Enter Coach Name: ");
            coach.Name = Console.ReadLine();
            Console.Write("Enter Sport Name: ");
            string sportName = Console.ReadLine();
            coach.SportId = sportsBusiness.GetSportByName(sportName).Id;
            coachesBusiness.AddCoach(coach);
            Console.WriteLine($"New coach added to Coaches table!");
        }

        public void UpdateCoach()
        {
            Console.Write("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Coaches coach = coachesBusiness.GetCoachById(id);
            if(coach == null)
            {
                Console.WriteLine($"There is no club with ID = {id} in the table!");
            }
            else
            {
                Console.WriteLine("Enter Coach Name: ");
                coach.Name = Console.ReadLine();
                Console.Write("Enter Sport Name: ");
                string sportName = Console.ReadLine();
                coach.SportId = sportsBusiness.GetSportByName(sportName).Id;
                coachesBusiness.UpdateCoach(coach);

                Console.WriteLine("Coach successfully updated!");
            }
        }

        public void DeleteCoachById()
        {
            Console.Write("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            if (coachesBusiness.GetCoachById(id) == null)
            {
                Console.WriteLine($"There is no club with ID = {id} in the table!");
            }
            else
            {
                coachesBusiness.DeleteCoachById(id);
                Console.WriteLine("Done!");
            }
        }
    }
}
