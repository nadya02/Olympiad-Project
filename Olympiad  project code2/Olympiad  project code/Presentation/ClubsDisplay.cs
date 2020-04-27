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
            //!!!!!!!!!!!!!!!!!!!!!!
            if(clubs.Count == 0)
            {
                Console.WriteLine("There are no clubs in the table!");
            }
            else
            {
                Console.WriteLine(new string(' ', 2) + "Id" + new string(' ', 2)
                  + new string(' ', 5) + "ClubName");
                Console.WriteLine(new string('-', 35));
                foreach (var club in clubs)
                {
                    string output = $"{club.Id}" + new string(' ', 11 - club.Id.ToString().Length)
                        + $"{club.Name}" + new string(' ', 34 - club.Name.Length);
                    Console.WriteLine(output);
                }
                Console.WriteLine(new string('-', 35));
            }
        }

        public void GetClubById()
        {
            Console.Write("Enter Club ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Clubs club = clubsBusiness.GetClubById(id);
            if(club != null)
            {
                PrintClub(club);
            }
        }

        public void GetClubByName()
        {
            Console.Write("Enter Club Name to fetch: ");
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

        public void AddClub()
        {
            Clubs club = new Clubs();
            Console.Write("Enter Club Name: ");
            club.Name = Console.ReadLine();
            clubsBusiness.AddClub(club);

            Console.WriteLine($"New club added to Clubs table!");
        }

        public void UpdateClub()
        {
            Console.Write("Enter Club ID to update: ");
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

                Console.WriteLine("Club successfully updated!");
            }
        }

        public void DeleteClubById()
        {
            Console.Write("Enter Club Id to delete: ");
            int id = int.Parse(Console.ReadLine());            
            if(clubsBusiness.GetClubById(id) == null)
            {
                Console.WriteLine($"There is no club with ID = {id} in the table!");
            }
            else
            {
                clubsBusiness.DeleteClubById(id);
                Console.WriteLine("Done!");
            }
        }
    }
}
