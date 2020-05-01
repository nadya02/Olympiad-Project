using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
    /// <summary>
    /// Тhe <c>SportsBusiness</c> class is in Business layer.
    /// It works as a bridge between the SportsDisplay class and the database.
    /// </summary>
    /// <remarks>
    /// The results are received in row data in Data Table format.
    /// SportsBusiness converts it into Value Objects.
    /// </remarks>
    public class SportsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        /// <summary>
        /// Constructor for SportsBusiness class.
        /// </summary>
        /// <param name="context"></param>
        public SportsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        /// <summary>
        /// Gets all sports in Sports table.
        /// </summary>
        /// <returns>A list of all sport's names and their ids.</returns>
        public List<Sports> GetAllSports()
        {
            return olympicGamesDBContext.Sports.ToList();
        }

        /// <summary>
        /// Finds the sport with the id the user has entered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The id and the name of the sport.</returns>
        public Sports GetSportById(int id)
        {
            return olympicGamesDBContext.Sports.Find(id);
        }

        /// <summary>
        /// Finds the sport with the name the user has entered.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The id and the name of the sport.</returns>
        public Sports GetSportByName(string name)
        {
            var sport = olympicGamesDBContext.Sports
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
            return sport;
        }

    }
}
