using System;
using System.Collections.Generic;
using System.Text;
using Olympiad__project_code.Business_layer;
using Olympiad__project_code.Models;

namespace Olympiad__project_code.Presentation
{
    class TownsDisplay
    {
        private TownsBusiness townsBusiness = new TownsBusiness();
        private CountriesBusiness countriesBusiness = new CountriesBusiness();
        private SportsBusiness sportsBusiness = new SportsBusiness();
        public void GetAllTowns()
        {
            Console.WriteLine("Towns: ");
            List<Towns> towns = townsBusiness.GetAllTowns();

            if (towns.Count == 0)
            {
                Console.WriteLine("There are no towns in the table. ");
            }
            else
            {
                Console.WriteLine("Id  |  Name   |  Country");
                //????????????????????????????????????
                Console.WriteLine(new string('-', 30));

                foreach (var item in towns)
                {
                    var country = countriesBusiness.GetCountryById(item.CountryId);
                    Console.WriteLine($"{item.Id}     {item.Name}     {country.Name}");
                }
            }

        }
        public void GetTownById()
        {
            Console.WriteLine("Enter Town Id to fetch:");
            int id = int.Parse(Console.ReadLine());
            Towns town = sportsBusiness.GetTownById(id);
            if (town != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine($"{sport.Id}     {town.Name}");
                Console.WriteLine(new string('-', 40));
            }

        }
        public void AddTown()
        {
            Towns town = new Towns();
            Console.Write("Enter name");
            town.Name = Console.ReadLine();
            townsBusiness.AddTown(town);

        }
        //Metod v country business GetCountryByName

        public void UpdateTown()
        {
            Console.Write("Enter Id:");
            int id = int.Parse(Console.ReadLine());
            Towns town = townsBusiness.GetTownById(id);

            if (town != null)
            {
                Console.Write("Enter new name:");
                town.Name = Console.ReadLine();

                townsBusiness.UpdateTown(town);
            }
            else
            {
                Console.WriteLine("Town not found");
            }
        }

        public void DeleteTownById()
        {
            Console.Write("Enter id:");
            int id = int.Parse(Console.ReadLine());
            townsBusiness.DeleteTownById(id);
        }
    }
}
