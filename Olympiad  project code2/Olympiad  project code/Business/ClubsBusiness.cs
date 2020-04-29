using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business
{
    class ClubsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public ClubsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }
        public ClubsBusiness()
        {

        }

        public List<Clubs> GetAllClubs()
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                return olympicGamesDBContext.Clubs.ToList();
            }
        }

        public Clubs GetClubById(int? id)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                return olympicGamesDBContext.Clubs.Find(id);
            }
        }

        public Clubs GetClubByName(string name)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                var club = olympicGamesDBContext.Clubs
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
                return club;
            }
        }
        public void AddClub(Clubs club)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                olympicGamesDBContext.Clubs.Add(club);
                olympicGamesDBContext.SaveChanges();
            }
        }

        public void UpdateClub(Clubs club)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                var item = olympicGamesDBContext.Clubs.Find(club.Id);
                if(item != null)
                {
                    olympicGamesDBContext.Entry(item).CurrentValues.SetValues(club);
                    olympicGamesDBContext.SaveChanges();
                }
            }
        }

        public void DeleteClubById(int id)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
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
}
