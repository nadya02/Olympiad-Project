using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
    class SportsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public List<Sports> GetAllSports()
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                return olympicGamesDBContext.Sports.ToList();
            }
        }
        public Sports GetSportById(int id)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                return olympicGamesDBContext.Sports.Find(id);
            }
        }

    }
}
