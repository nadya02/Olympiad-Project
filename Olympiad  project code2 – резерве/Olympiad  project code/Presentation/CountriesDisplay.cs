using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    /// <summary>
    /// Тhe <c>CountriesDisplay</c> class in Presentation.
    /// This is the layer which is directly connected to CountriesBusiness.
    /// </summary>
    /// <remarks>
    /// This class receive information from the user.
    /// Then it is passed to CountriesBusiness.
    /// </remarks>
    class CountriesDisplay
    {
        private CountriesBusiness countriesBusiness;
        private TownsBusiness towns;

        /// <summary>
        /// Constructor for CountriesDisplay class. 
        /// </summary>
        /// <param name="context"></param>
        public CountriesDisplay(OlympicGamesDBContext context)
        {
            countriesBusiness = new CountriesBusiness(context);
            towns = new TownsBusiness(context);
        }

        /// <summary>
        /// "Calls" method "GetAllCountries" from CountriesBusiness.
        /// Then it shows all countries in table Countries.
        /// </summary>
        public void GetAllCountries()
        {
            Console.WriteLine("Countries: ");
            List<Countries> countries = countriesBusiness.GetAllCountries();

            if (countries.Count == 0)
            {
                Console.WriteLine("There are no countries in the table. ");
            }
            else
            {
                Console.WriteLine("Id" + new string(' ', 4) + "CountyName"); 
                Console.WriteLine(new string('-', 35));
                foreach (var country in countries)
                {
                    string output = $"{country.Id}" + new string(' ', 6 - country.Id.ToString().Length)
                        + $"{country.Name}" + new string(' ', 34 - country.Name.Length);
                    Console.WriteLine(output);
                }
                Console.WriteLine(new string('-', 35));
            }  
        }

        /// <summary>
        /// After the user has inputed id, the program "Calls" method "GetCountryById" from CountriesBusiness.
        /// Shows the Country who has this id. 
        /// </summary>
        public void GetCountryById()
        {
            Console.WriteLine("Enter Country Id to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Countries country = countriesBusiness.GetCountryById(id);
            if (country != null)
            {
                PrintCountry(country);
            }
            else
            {
                Console.WriteLine($"There is no country with id = {id} in the table!");
            }
        }

        /// <summary>
        /// After the user has inputed name, the program "Calls" method "GetCountryByName" from CountriesBusiness.
        /// Shows the Country who has this name. 
        /// </summary>
        public void GetCountryByName()
        {
            Console.WriteLine("Enter Country Name to fetch: ");
            string name = Console.ReadLine();
            Countries country = countriesBusiness.GetCountryByName(name);
            if (country != null)
            {
                PrintCountry(country);
            }
            else
            {
                Console.WriteLine($"There is no counrty with name = {name} in the table!");
            }
        }

        private void PrintCountry(Countries country)
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"ID: {country.Id}");
            Console.WriteLine($"Name: {country.Name}");
            Console.WriteLine(new string('-', 40));
        }
    }
}
