using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business
{
    public class ClubsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public ClubsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        public List<Clubs> GetAllClubs()
        {
             return olympicGamesDBContext.Clubs.ToList();
        }

        public Clubs GetClubById(int? id)
        {
            return olympicGamesDBContext.Clubs.Find(id);
        }

        public Clubs GetClubByName(string name)
        {
            var club = olympicGamesDBContext.Clubs
                  .Where(c => c.Name == name)
                  .FirstOrDefault();
            return club;
        }
        public void AddClub(Clubs club)
        {
            olympicGamesDBContext.Clubs.Add(club);
            olympicGamesDBContext.SaveChanges();
        }

        public void UpdateClub(Clubs club)
        {
            var item = olympicGamesDBContext.Clubs.Find(club.Id);
            if (item != null)
            {
                olympicGamesDBContext.Entry(item).CurrentValues.SetValues(club);
                olympicGamesDBContext.SaveChanges();
            }
        }

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
