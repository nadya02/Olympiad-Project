using Olympiad__project_code.Business;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    /// <summary>
    /// Тhe <c>CoachesDisplay</c> class in Presentation.
    /// This is the layer which is directly connected to CoachesBusiness.
    /// </summary>
    /// <remarks>
    /// This class receive information from the user.
    /// Then it is passed to CoachesBusiness.
    /// </remarks>
    class CoachesDisplay
    {
        private CoachesBusiness coachesBusiness;
        private SportsBusiness sportsBusiness ;

        /// <summary>
        /// Makes the connection between Coaches's display and business layer. 
        /// </summary>
        /// <param name="context"></param>
        public CoachesDisplay(OlympicGamesDBContext context)
        {
            coachesBusiness = new CoachesBusiness(context);
            sportsBusiness = new SportsBusiness(context);
        }

        /// <summary>
        /// "Calls" method "GetAllCoaches" from CoachesBusiness.
        /// Then it shows all coaches in table Coaches.
        /// </summary>
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
                Console.WriteLine("Id" + new string(' ', 4) + "Name" + new string(' ', 25) + "Sport Name");
                Console.WriteLine(new string('-', 56));
                foreach (var coach in coaches)
                {
                    var sport = sportsBusiness.GetSportById(coach.SportId);
                    string output = $"{coach.Id}" + new string(' ', 6 - coach.Id.ToString().Length)
                        + $"{coach.Name}" + new string(' ', 29 - coach.Name.Length)
                        + $"{sport.Name}" +  new string(' ', 21 - sport.Name.Length);
                    Console.WriteLine(output);
                }
                Console.WriteLine(new string('-', 56));
            }
        }

        /// <summary>
        /// After the user has inputed id, the program "Calls" method "GetCoachById" from CoachesBusiness.
        /// Shows the Coach who has this id. 
        /// </summary>
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

        /// <summary>
        /// After the user has inputed name, the program "Calls" method "GetCoachById" from CoachesBusiness.
        /// Shows the Coach who has this name. 
        /// </summary>
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
            else
            {
                Console.WriteLine($"There is no coach with name = {name} in the table!");
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

        /// <summary>
        /// Makes the user to input data about the coach.
        /// Passes the information to CoachesBusinessiness, using the method "AddCoach"
        /// </summary>
        public void AddCoach()
        {
            var coach = new Coaches();
            Console.Write("Enter Coach Name: ");
            coach.Name = Console.ReadLine();
            Console.Write("Enter Sport Name: ");
            string sportName = Console.ReadLine();
            coach.SportId = sportsBusiness.GetSportByName(sportName).Id;
            coachesBusiness.AddCoach(coach);

            Console.WriteLine($"New coach successfully added!");
        }

        /// <summary>
        /// Finds the coach wished to be updated.
        /// Makes the user to enter the new information.
        /// Then passes it to CoachesBusinessiness, using the method "UpdateCoach".
        /// </summary>
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
                Console.Write("Enter Coach Name: ");
                coach.Name = Console.ReadLine();
                Console.Write("Enter Sport Name: ");
                string sportName = Console.ReadLine();
                coach.SportId = sportsBusiness.GetSportByName(sportName).Id;
                coachesBusiness.UpdateCoach(coach);

                Console.WriteLine("Coach successfully updated!");
            }
        }

        /// <summary>
        /// Finds the town wished to be deleted.
        /// Passes the information to CoachesBusinessiness, using the method "DeleteCoachById".
        /// </summary>
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
