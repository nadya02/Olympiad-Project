using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
    class TownsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;
        public List<Towns> GetAllTowns()
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                return olympicGamesDBContext.Towns.ToList();
            }
        }
        public Towns GetTownById(int id)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                return olympicGamesDBContext.Towns.Find(id);
            }
        }

        public void AddTown(Towns town)
        {

            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                olympicGamesDBContext.Towns.Add(town);
                olympicGamesDBContext.SaveChanges();
            }
        }
        public void UpdateTown(Towns town)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                var item = olympicGamesDBContext.Towns.Find(town.Id);
                if (item != null)
                {
                    olympicGamesDBContext.Entry(item).CurrentValues.SetValues(town);
                    olympicGamesDBContext.SaveChanges();
                }
            }
        }
        public void DeleteTownById(int id)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
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
}
