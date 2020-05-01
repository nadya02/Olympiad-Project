using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business
{
    /// <summary>
    /// Тhe <c>ClubsBusiness</c> class is in Business layer.
    /// It works as a bridge between the ClubsDisplay class and the database.
    /// </summary>
    /// <remarks>
    /// The results are received in row data in Data Table format.
    /// ClubsBusiness converts it into Value Objects.
    /// </remarks>
    public class ClubsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        /// <summary>
        /// Constructor for ClubsBusiness class.
        /// </summary>
        /// <param name="context"></param>
        public ClubsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        /// <summary>
        /// Gets all clubs in Clubs table.
        /// </summary>
        /// <returns>A list of all club's names and ids.</returns>
        public List<Clubs> GetAllClubs()
        {
             return olympicGamesDBContext.Clubs.ToList();
        }

        /// <summary>
        /// Finds the club with the id the user has entered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The id and the name of the club.</returns>
        public Clubs GetClubById(int? id)
        {
            return olympicGamesDBContext.Clubs.Find(id);
        }

        /// <summary>
        /// Finds the club with the name the user has entered.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The id and the name of the club.</returns>
        public Clubs GetClubByName(string name)
        {
            var club = olympicGamesDBContext.Clubs
                  .Where(c => c.Name == name)
                  .FirstOrDefault();
            return club;
        }

        /// <summary>
        /// Adds a club in the database.
        /// </summary>
        /// <param name="club">The club that is being added.</param>
        public void AddClub(Clubs club)
        {
            olympicGamesDBContext.Clubs.Add(club);
            olympicGamesDBContext.SaveChanges();
        }

        /// <summary>
        /// Updates a club in the database.
        /// </summary>
        /// <param name="club">The club that is being updated.</param>
        public void UpdateClub(Clubs club)
        {
            var item = olympicGamesDBContext.Clubs.Find(club.Id);
            if (item != null)
            {
                olympicGamesDBContext.Entry(item).CurrentValues.SetValues(club);
                olympicGamesDBContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a club from the database by given id.
        /// </summary>
        /// <param name="id">The id of the club wanted to be deleted.</param>
        public void DeleteClubById(int id)
        {
            var item = olympicGamesDBContext.Clubs.Find(id);
            if (item != null)
            {
                olympicGamesDBContext.Remove(item);
                olympicGamesDBContext.SaveChanges();
            }
        }

    }
}
