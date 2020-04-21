using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
    class CountriesBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public List<Countries> GetAllCountries()
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                return olympicGamesDBContext.Countries.ToList();
            }
        }
        public Countries GetCountryById(int id)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                return olympicGamesDBContext.Countries.Find(id);
            }
        }
        public void Add(Countries country)
        {

            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                olympicGamesDBContext.Countries.Add(country);
                olympicGamesDBContext.SaveChanges();
            }
        }

        public void Update(Countries country)
        {
            using (olympicGamesDBContext = new OlympicGamesDBContext())
            {
                var item = olympicGamesDBContext.Countries.Find(country.Id);
                if (item != null)
                {
                    olympicGamesDBContext.Entry(item).CurrentValues.SetValues(product);
                    olympicGamesDBContext.SaveChanges();
                }
            }
        }

    }
}
