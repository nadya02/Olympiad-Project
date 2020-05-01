using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business
{
    /// <summary>
    /// Тhe <c>CoachesBusiness</c> class is in Business layer.
    /// It works as a bridge between the CoachesDisplay class and the database.
    /// </summary>
    /// <remarks>
    /// The results are received in row data in Data Table format.
    /// CoachesBusiness converts it into Value Objects.
    /// </remarks>
    public class CoachesBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        /// <summary>
        /// Constructor for CoachesBusiness class.
        /// </summary>
        /// <param name="context"></param>
        public CoachesBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        /// <summary>
        /// Gets all coaches in Coaches table.
        /// </summary>
        /// <returns>A list of all coach's names, ids and sport.</returns>
        public List<Coaches> GetAllCoaches()
        {
            return olympicGamesDBContext.Coaches.ToList();
        }

        /// <summary>
        /// Finds the coach with the id the user has entered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The id, the name of the coach and the sport they are coaching.</returns>
        public Coaches GetCoachById(int? id)
        {
            return olympicGamesDBContext.Coaches.Find(id);
        }

        /// <summary>
        /// Finds the coach with the name the user has entered.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The id, the name of the coach and the sport they are coaching.</returns>
        public Coaches GetCoachByName(string name)
        {
            var coach = olympicGamesDBContext.Coaches
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
            return coach;
        }

        /// <summary>
        /// Adds a coach in the database.
        /// </summary>
        /// <param name="coach">The coach that is being added.</param>
        public void AddCoach(Coaches coach)
        {
            olympicGamesDBContext.Coaches.Add(coach);
            olympicGamesDBContext.SaveChanges();
        }

        /// <summary>
        /// Updates a coach in the database.
        /// </summary>
        /// <param name="coach">The coach that is being updated.</param>
        public void UpdateCoach(Coaches coach)
        {
            var item = olympicGamesDBContext.Coaches.Find(coach.Id);
            if (item != null)
            {
                olympicGamesDBContext.Entry(item).CurrentValues.SetValues(coach);
                olympicGamesDBContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a coach from the database by given id.
        /// </summary>
        /// <param name="id">The id of the coach wanted to be deleted.</param>
        public void DeleteCoachById(int id)
        {
            var item = olympicGamesDBContext.Coaches.Find(id);
            if (item != null)
            {
                olympicGamesDBContext.Remove(item);
                olympicGamesDBContext.SaveChanges();
            }
        }
    }

}
