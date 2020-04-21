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
    }
}
