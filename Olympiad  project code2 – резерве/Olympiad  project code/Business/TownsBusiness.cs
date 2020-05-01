using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
    /// <summary>
    /// Тhe <c>TownsBusiness</c> class is in Business layer.
    /// It works as a bridge between the TownsDisplay class and the database.
    /// </summary>
    /// <remarks>
    /// The results are received in row data in Data Table format.
    /// TownsBusiness converts it into Value Objects.
    /// </remarks>
    public class TownsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        /// <summary>
        /// Constructor for TownsBusiness class.
        /// </summary>
        /// <param name="context"></param>
        public TownsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        /// <summary>
        /// Gets all towns in Towns table.
        /// </summary>
        /// <returns>A list of all town's names, ids and countries.</returns>
        public List<Towns> GetAllTowns()
        {
            return olympicGamesDBContext.Towns.ToList();
        }

        /// <summary>
        /// Finds the town with the id the user has entered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The id, the name of the town and the country it is in.</returns>
        public Towns GetTownById(int id)
        {
            return olympicGamesDBContext.Towns.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Finds the town with the name the user has entered.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The id, the name of the town and the country it is in.</returns>
        public Towns GetTownByName(string name)
        {
            var town = olympicGamesDBContext.Towns
                .Where(c => c.Name == name)
                .FirstOrDefault();
            return town;
        }

        /// <summary>
        /// Adds a town in the database.
        /// </summary>
        /// <param name="town">The town that is being added.</param>
        public void AddTown(Towns town)
        {
            olympicGamesDBContext.Towns.Add(town);
            olympicGamesDBContext.SaveChanges();
        }

        /// <summary>
        /// Updates a town in the database.
        /// </summary>
        /// <param name="town">The town that is being updated.</param>
        public void UpdateTown(Towns town)
        {
            var item = olympicGamesDBContext.Towns.Find(town.Id);
            if (item != null)
            {
                olympicGamesDBContext.Entry(item).CurrentValues.SetValues(town);
                olympicGamesDBContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a town from the database by given id.
        /// </summary>
        /// <param name="id">The id of the town wanted to be deleted.</param>
        public void DeleteTownById(int id)
        {
            var item = olympicGamesDBContext.Towns.Find(id);
            if (item != null)
            {
                olympicGamesDBContext.Towns.Remove(item);
                olympicGamesDBContext.SaveChanges();
            }
        }
    }
}
