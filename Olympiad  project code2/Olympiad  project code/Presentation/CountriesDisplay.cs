using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Olympiad__project_code.Presentation
{
    class CountriesDisplay
    {
        private CountriesBusiness countriesBusiness = new CountriesBusiness();

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
                Console.WriteLine("Id  |  Name  ");
                //????????????????????????????????????
                Console.WriteLine(new string('-', 30));

                foreach (var item in countries)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Name);
                }
            }

        }
        public void GetCountryById()
        {
            Console.WriteLine("Enter Country Id to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Countries country = countriesBusiness.GetCountryById(id);
            if (country != null)
            {
                PrintCountry(country);
            }
        }

        public void GetCountryByName()
        {
            Console.WriteLine("Enter Country Name to fetch: ");
            string name = Console.ReadLine();
            Countries country = countriesBusiness.GetCountryByName(name);
            if (country != null)
            {
                PrintCountry(country);
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
