using Olympiad__project_code.Business;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    class ClubsDisplay
    {
        private ClubsBusiness clubsBusiness = new ClubsBusiness();
        public void GetAllClubs()
        {
            Console.WriteLine("Clubs:");
            List<Clubs> clubs = clubsBusiness.GetAllClubs();

            if(clubs.Count == 0)
            {
                Console.WriteLine("There are no clubs in the table!");
            }
            else
            {
                Console.WriteLine("Id  |  Name");
                Console.WriteLine(new string('-', 30));//?
                foreach (var club in clubs)
                {
                    Console.WriteLine($"{club.Id}     {club.Name}");//?
                }
            }
        }

        public void GetClubById()
        {
            Console.WriteLine("Enter Club ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Clubs club = clubsBusiness.GetClubById(id);
            if(club != null)
            {
                PrintClub(club);
            }
        }

        public void GetClubByName()
        {
            Console.WriteLine("Enter Club Name to fetch: ");
            string name = Console.ReadLine();
            Clubs club = clubsBusiness.GetClubByName(name);
            if (club != null)
            {
                PrintClub(club);
            }
        }

        private void PrintClub(Clubs club)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"ID: {club.Id}");
            Console.WriteLine($"Name: {club.Name}");
            Console.WriteLine(new string('-', 40));
        }

        public void Add()
        {
            Clubs club = new Clubs();
            Console.Write("Enter Club Name: ");//?
            club.Name = Console.ReadLine();
            clubsBusiness.AddClub(club);
        }

        public void Update()
        {
            Console.WriteLine("Enter Club ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Clubs club = clubsBusiness.GetClubById(id);
            if(club == null)
            {
                Console.WriteLine($"There is no club with ID = {id} in the table!");
            }
            else
            {
                Console.WriteLine("Enter Club Name: ");
                club.Name = Console.ReadLine();
                clubsBusiness.UpdateClub(club); 
            }
        }

        public void DeleteClubById()
        {
            Console.WriteLine("Enter Club Id to delete: ");
            int id = int.Parse(Console.ReadLine());
            clubsBusiness.DeleteClubById(id);
            if(clubsBusiness.GetClubById(id) == null)//?
            {
                Console.WriteLine($"There is no club with ID = {id} in the table!");
            }
            else
            {
                Console.WriteLine("Done!");
            }
        }
    }
}
