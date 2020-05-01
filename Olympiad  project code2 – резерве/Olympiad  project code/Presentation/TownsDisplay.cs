using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;

namespace Olympiad__project_code.Presentation
{
    /// <summary>
    /// Тhe <c>TownsDisplay</c> class in Presentation.
    /// This is the layer which is directly connected to TownsBusiness.
    /// </summary>
    /// <remarks>
    /// This class receive information from the user.
    /// Then it is passed to TownsBusiness.
    /// </remarks>
    public class TownsDisplay
    {
        private TownsBusiness townsBusiness;
        private CountriesBusiness countriesBusiness;

        /// <summary>
        /// Constructor for TownsDisplay class.
        /// </summary>
        /// <param name="context"></param>
        public TownsDisplay(OlympicGamesDBContext context)
        {
            townsBusiness = new TownsBusiness(context);
            countriesBusiness = new CountriesBusiness(context);
        }

        /// <summary>
        /// "Calls" method "GetAllTowns" from TownsBusiness.
        /// Then it shows all towns in table Towns.
        /// </summary>
        public void GetAllTowns()
        {
            Console.WriteLine("Towns: ");
            List<Towns> towns = townsBusiness.GetAllTowns();

            if (towns.Count == 0)
            {
                Console.WriteLine("There are no towns in the table!");
            }
            else
            {
                Console.WriteLine("Id" + new string(' ', 4)
                    + "Name" + new string(' ', 28) + "Country");
                Console.WriteLine(new string('-', 68));

                foreach (var town in towns)
                {
                    var country = countriesBusiness.GetCountryById(town.CountryId);
                    string output = $"{town.Id}" + new string(' ', 6 - town.Id.ToString().Length)
                        + $"{town.Name}" + new string(' ', 28 - town.Name.Length)
                        + $"{country.Name}" + new string(' ', 34 - country.Name.Length);
                    Console.WriteLine(output);
                }
                Console.WriteLine(new string('-', 68));
            }
        }

        /// <summary>
        /// After the user has inputed id, the program "Calls" method "GetTownById" from TownsBusiness.
        /// Shows the Town who has this id. 
        /// </summary>
        public void GetTownById()
        {
            Console.WriteLine("Enter Town Id to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Towns town = townsBusiness.GetTownById(id);
            if (town != null)
            {
                PrintTown(town);
            }
            else
            {
                Console.WriteLine($"There is no town with id = {id} in the table!");
            }
        }

        /// <summary>
        /// After the user has inputed name, the program "Calls" method "GetTownByName" from TownsBusiness.
        /// Shows the Town who has this name. 
        /// </summary>
        public void GetTownByName()
        {
            Console.WriteLine("Enter Town Name to fetch: ");
            string name = Console.ReadLine();
            Towns town = townsBusiness.GetTownByName(name);
            if (town != null)
            {
                PrintTown(town);
            }
            else
            {
                Console.WriteLine($"There is no town with Name = {name} in the table!");
            }
        }

        private void PrintTown(Towns town)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"ID: {town.Id}");
            Console.WriteLine($"Name: {town.Name}");
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Makes the user to input data about the town.
        /// Passes the information to TownsBusiness, using the method "AddTown"
        /// </summary>
        public void AddTown()
        {
            Towns town = new Towns();
            Console.Write("Enter name: ");
            town.Name = Console.ReadLine();
            Console.Write("Enter Country Name: ");
            string countryName = Console.ReadLine();
            town.CountryId = countriesBusiness.GetCountryByName(countryName).Id;
            townsBusiness.AddTown(town);

            Console.WriteLine($"New town successfully added!");
        }

        /// <summary>
        /// Finds the town wished to be updated.
        /// Makes the user to enter the new information.
        /// Then passes it to TownsBusiness, using the method "UpdateTown".
        /// </summary>
        public void UpdateTown()
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            Towns town = townsBusiness.GetTownById(id);

            if (town != null)
            {
                Console.Write("Enter new name: ");
                town.Name = Console.ReadLine();
                Console.Write("Enter country name: ");
                town.CountryId = countriesBusiness.GetCountryByName(Console.ReadLine()).Id;

                townsBusiness.UpdateTown(town);
            }
            else
            {
                Console.WriteLine("Town not found!");
            }

            Console.WriteLine("Town successfully updated!");
        }

        /// <summary>
        /// Finds the town wished to be deleted.
        /// Passes the information to TownsBusiness, using the method "DeleteTownById".
        /// </summary>
        public void DeleteTownById()
        {
            Console.Write("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            if (townsBusiness.GetTownById(id) == null)
            {
                Console.WriteLine($"There is no town with ID = {id} in the table!");
            }
            else
            {
                townsBusiness.DeleteTownById(id);
                Console.WriteLine("Done!");
            }
        }
    }
}
