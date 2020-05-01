using Olympiad__project_code.Business;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    /// <summary>
    /// Тhe <c>ClubsDisplay</c> class in Presentation.
    /// This is the layer which is directly connected to ClubsBusiness.
    /// </summary>
    /// <remarks>
    /// This class receive information from the user.
    /// Then it is passed to ClubsBusiness.
    /// </remarks>
    class ClubsDisplay
    {
        private ClubsBusiness clubsBusiness;

        /// <summary>
        /// Constructor for ClubsDisplay class.
        /// </summary>
        /// <param name="context"></param>
        public ClubsDisplay(OlympicGamesDBContext context)
        {
            clubsBusiness = new ClubsBusiness(context);
        }

        /// <summary>
        /// "Calls" method "GetAllTowns" from ClubsBusiness.
        /// Then it shows all clubs in table Clubs.
        /// </summary>

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
                Console.WriteLine("Id" + new string(' ', 4)//6
                  + "ClubName" + new string(' ', 36));
                Console.WriteLine(new string('-', 50));
                foreach (var club in clubs)
                {
                    string output = $"{club.Id}" + new string(' ', 6 - club.Id.ToString().Length)
                        + $"{club.Name}" + new string(' ', 44 - club.Name.Length);
                    Console.WriteLine(output);
                }
                Console.WriteLine(new string('-', 50));
            }
        }

        /// <summary>
        /// After the user has inputed id, the program "Calls" method "GetClubById" from ClubsBusiness.
        /// Shows the Club who has this id. 
        /// </summary>
        public void GetClubById()
        {
            Console.Write("Enter Club ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Clubs club = clubsBusiness.GetClubById(id);
            if(club != null)
            {
                PrintClub(club);
            }
            else
            {
                Console.WriteLine($"There is no club with ID = {id} in the table!");
            }
        }

        /// <summary>
        /// After the user has inputed idname the program "Calls" method "GetClubById" from ClubsBusiness.
        /// Shows the Club who has this name. 
        /// </summary>
        public void GetClubByName()
        {
            Console.Write("Enter Club Name to fetch: ");
            string name = Console.ReadLine();
            Clubs club = clubsBusiness.GetClubByName(name);
            if (club != null)
            {
                PrintClub(club);
            }
            else
            {
                Console.WriteLine($"There is no club with name = {name} in the table!");
            }
        }

        private void PrintClub(Clubs club)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"ID: {club.Id}");
            Console.WriteLine($"Name: {club.Name}");
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Makes the user to input data about the club.
        /// Passes the information to ClubsBusiness, using the method "AddClub"
        /// </summary>
        public void AddClub()
        {
            Clubs club = new Clubs();
            Console.Write("Enter Club Name: ");
            club.Name = Console.ReadLine();
            clubsBusiness.AddClub(club);

            Console.WriteLine($"New club successfully added!");
        }

        /// <summary>
        /// Finds the club wished to be updated.
        /// Makes the user to enter the new information.
        /// Then passes it to ClubsBusiness, using the method "UpdateClub".
        /// </summary>
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

        /// <summary>
        /// Finds the club wished to be deleted.
        /// Passes the information to ClubsBusiness, using the method "DeleteClubById".
        /// </summary>
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
