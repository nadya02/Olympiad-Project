using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business
{
    class CoachesBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public CoachesBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }
        public CoachesBusiness()
        {

        }


        public List<Coaches> GetAllCoaches()
        {
           // using (olympicGamesDBContext = new OlympicGamesDBContext())
            //{
                return olympicGamesDBContext.Coaches.ToList();
           // }
        }

        public Coaches GetCoachById(int? id)
        {
          //  using (olympicGamesDBContext = new OlympicGamesDBContext())
           // {
                return olympicGamesDBContext.Coaches.Find(id);
           // }
        }
        public Coaches GetCoachByName(string name)
        {
           // using (olympicGamesDBContext = new OlympicGamesDBContext())
           // {
                var coach = olympicGamesDBContext.Coaches
                    .Where(c => c.Name == name)
                    .FirstOrDefault();
                return coach;
           // }
        }

        public void AddCoach(Coaches coach)
        {
          //  using (olympicGamesDBContext = new OlympicGamesDBContext())
           // {
                olympicGamesDBContext.Coaches.Add(coach);
                olympicGamesDBContext.SaveChanges();
           // }
        }

        public void UpdateCoach(Coaches coach)
        {
         //   using(olympicGamesDBContext = new OlympicGamesDBContext())
         //   {
                var item = olympicGamesDBContext.Coaches.Find(coach.Id);
                if (item != null)
                {
                    olympicGamesDBContext.Entry(item).CurrentValues.SetValues(coach);
                    olympicGamesDBContext.SaveChanges();
                }
        //    }
        }

        public void DeleteCoachById(int id)
        {
       //     using (olympicGamesDBContext = new OlympicGamesDBContext())
          //  {
                var item = olympicGamesDBContext.Coaches.Find(id);
                if(item != null)
                {
                    olympicGamesDBContext.Remove(item);
                    olympicGamesDBContext.SaveChanges();
                }
          //  }
        }
    }

}
