using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
   public class SportsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public SportsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        public List<Sports> GetAllSports()
        {
            return olympicGamesDBContext.Sports.ToList();
        }
        public Sports GetSportById(int id)
        {
            return olympicGamesDBContext.Sports.Find(id);
        }

        public Sports GetSportByName(string name)
        {
            var sport = olympicGamesDBContext.Sports
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
            return sport;
        }

    }
}
