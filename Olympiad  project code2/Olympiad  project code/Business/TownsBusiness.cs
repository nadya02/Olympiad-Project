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
            //using (olympicGamesDBContext = new OlympicGamesDBContext())
            //{
                return olympicGamesDBContext.Towns.ToList();
            //}
        }
        public Towns GetTownById(int id)
        {
            //using (olympicGamesDBContext = new OlympicGamesDBContext())
            //{
                return olympicGamesDBContext.Towns.FirstOrDefault(p => p.Id==id);
            //}
        }

        public Towns GetTownByName(string name)
        {
            //using (olympicGamesDBContext = new OlympicGamesDBContext())
            //{
                var town = olympicGamesDBContext.Towns
                   .Where(c => c.Name == name)
                   .FirstOrDefault();
                return town;
            //}
        }

        public void AddTown(Towns town)
        {

            //using (olympicGamesDBContext = new OlympicGamesDBContext())
            //{
                olympicGamesDBContext.Towns.Add(town);
                olympicGamesDBContext.SaveChanges();
            //}
        }
        public void UpdateTown(Towns town)
        {
            //using (olympicGamesDBContext = new OlympicGamesDBContext())
            //{
                var item = olympicGamesDBContext.Towns.Find(town.Id);
                if (item != null)
                {
                    olympicGamesDBContext.Entry(item).CurrentValues.SetValues(town);
                    olympicGamesDBContext.SaveChanges();
                }
            //}
        }
        public void DeleteTownById(int id)
        {
            //using (olympicGamesDBContext = new OlympicGamesDBContext())
            //{
                var item = olympicGamesDBContext.Towns.Find(id);
                if (item != null)
                {
                    olympicGamesDBContext.Towns.Remove(item);
                    olympicGamesDBContext.SaveChanges();
                }
            //}
        }
    }
}
