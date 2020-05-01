using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
    /// <summary>
    /// Тhe <c>CountriesBusiness</c> class is in Business layer.
    /// It works as a bridge between the CountrieDisplay class and the database.
    /// </summary>
    /// <remarks>
    /// The results are received in row data in Data Table format.
    /// CountriesBusiness converts it into Value Objects.
    /// </remarks>
    public class CountriesBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        /// <summary>
        /// Constructor for CountriesBusiness class.
        /// </summary>
        /// <param name="context"></param>
        public CountriesBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        /// <summary>
        /// Gets all countries in Countries table.
        /// </summary>
        /// <returns>A list of all countries's names and their ids.</returns>
        public List<Countries> GetAllCountries()
        {
            return olympicGamesDBContext.Countries.ToList();
        }

        /// <summary>
        /// Finds the country with the id the user has entered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The id and the name of the country.</returns>
        public Countries GetCountryById(int id)
        {
            return olympicGamesDBContext.Countries.Find(id);
        }

        /// <summary>
        /// Finds the country with the name the user has entered.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The id and the name of the country.</returns>
        public Countries GetCountryByName(string name)
        {
            var country = olympicGamesDBContext.Countries
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
            return country;
        }
    }
}
