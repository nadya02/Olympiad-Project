using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
    public class TownsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public TownsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        public List<Towns> GetAllTowns()
        {
            return olympicGamesDBContext.Towns.ToList();
        }
        public Towns GetTownById(int id)
        {
            return olympicGamesDBContext.Towns.FirstOrDefault(p => p.Id == id);
        }

        public Towns GetTownByName(string name)
        {
            var town = olympicGamesDBContext.Towns
                .Where(c => c.Name == name)
                .FirstOrDefault();
            return town;
        }

        public void AddTown(Towns town)
        {
            olympicGamesDBContext.Towns.Add(town);
            olympicGamesDBContext.SaveChanges();
        }
        public void UpdateTown(Towns town)
        {
            var item = olympicGamesDBContext.Towns.Find(town.Id);
            if (item != null)
            {
                olympicGamesDBContext.Entry(item).CurrentValues.SetValues(town);
                olympicGamesDBContext.SaveChanges();
            }
        }
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
