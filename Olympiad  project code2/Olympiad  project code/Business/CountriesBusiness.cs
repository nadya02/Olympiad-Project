using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business_layer
{
    public class CountriesBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public CountriesBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }
        public CountriesBusiness()
        {

        }

        public List<Countries> GetAllCountries()
        {
           // using (olympicGamesDBContext = new OlympicGamesDBContext())
            //{
                return olympicGamesDBContext.Countries.ToList();
           // }
        }
        public Countries GetCountryById(int id)
        {
        //    using (olympicGamesDBContext = new OlympicGamesDBContext())
          //  {
                return olympicGamesDBContext.Countries.Find(id);
          //  }
        }
        public Countries GetCountryByName(string name)
        {
         //   using (olympicGamesDBContext = new OlympicGamesDBContext())
          //  {
                var country = olympicGamesDBContext.Countries
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
                return country;
          //  }
        }
    }
}
