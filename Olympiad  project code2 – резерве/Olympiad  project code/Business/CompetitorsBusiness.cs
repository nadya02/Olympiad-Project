using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business
{
    /// <summary>
    /// Тhe <c>CompetitorsBusiness</c> class is in Business layer.
    /// It works as a bridge between the CompetitorsDisplay class and the database.
    /// </summary>
    /// <remarks>
    /// The results are received in row data in Data Table format.
    /// CompetitorsBusiness converts it into Value Objects.
    /// </remarks>
    public class CompetitorsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        /// <summary>
        /// Constructor for CompetitorsBusiness class.
        /// </summary>
        /// <param name="context"></param>
        public CompetitorsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        /// <summary>
        /// Gets all competitors in Competitors table.
        /// </summary>
        /// <returns>A list of all competitors and everyting about them.</returns>
        public List<Competitors> GetAllCompetitors()
        {
            return olympicGamesDBContext.Competitors.ToList();
        }

        /// <summary>
        /// Finds the competitor with the id the user has entered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The name of the competitor and everyting about them.</returns>
        public Competitors GetCompetitorById(int id)
        {
            return olympicGamesDBContext.Competitors.Find(id);
        }

        /// <summary>
        /// Finds the competitor with the name the user has entered.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The name of the competitor and everyting about them..</returns>
        public Competitors GetCompetitorByName(string name)
        {
            var competitor = olympicGamesDBContext.Competitors
                    .Where(c => c.FullName == name)
                    .FirstOrDefault();
            return competitor;
        }


        /// <summary>
        /// Adds a competitor in the database.
        /// </summary>
        /// <param name="competitors">The competitor that is being added.</param>
        public void AddCompetitors(Competitors competitors)
        {
            olympicGamesDBContext.Competitors.Add(competitors);
            olympicGamesDBContext.SaveChanges();
        }

        /// <summary>
        /// Updates a competitor in the database.
        /// </summary>
        /// <param name="competitor">The competitor that is being updated.</param>
        public void UpdateCompetitor(Competitors competitor)
        {
            var item = olympicGamesDBContext.Competitors.Find(competitor.Id);
            if (item != null)
            {
                olympicGamesDBContext.Entry(item).CurrentValues.SetValues(competitor);
                olympicGamesDBContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a competitor from the database by given id.
        /// </summary>
        /// <param name="id">The id of the competitor wanted to be deleted.</param>
        public void DeleteCompetitorById(int id)
        {
            var item = olympicGamesDBContext.Competitors.Find(id);
            if (item != null)
            {
                olympicGamesDBContext.Remove(item);
                olympicGamesDBContext.SaveChanges();
            }
        }       
    }
}
