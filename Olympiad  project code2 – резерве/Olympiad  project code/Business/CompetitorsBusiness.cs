using Olympiad__project_code.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Olympiad__project_code.Business
{
    public class CompetitorsBusiness
    {
        private OlympicGamesDBContext olympicGamesDBContext;

        public CompetitorsBusiness(OlympicGamesDBContext context)
        {
            this.olympicGamesDBContext = context;
        }

        public List<Competitors> GetAllCompetitors()
        {
         //   using (olympicGamesDBContext = new OlympicGamesDBContext())
         //   {
                return olympicGamesDBContext.Competitors.ToList();
         //   }         
        }

        public Competitors GetCompetitorById(int id)
        {
          //  using (olympicGamesDBContext = new OlympicGamesDBContext())
          //  {
                return olympicGamesDBContext.Competitors.Find(id);
          //  }             
        }

        public Competitors GetCompetitorByName(string name)
        {
         //   using (olympicGamesDBContext = new OlympicGamesDBContext())
         //   {
                var competitor = olympicGamesDBContext.Competitors
                    .Where(c => c.FullName == name)
                    .FirstOrDefault();
                return competitor;
          //  }
        }

        public void AddCompetitors(Competitors competitors)
        {
       //     using (olympicGamesDBContext = new OlympicGamesDBContext())
       //     {
                olympicGamesDBContext.Competitors.Add(competitors);
                olympicGamesDBContext.SaveChanges();
        //    }        
        }

        public void UpdateCompetitor(Competitors competitor)
        {
      //      using (olympicGamesDBContext = new OlympicGamesDBContext())
      //      {
                var item = olympicGamesDBContext.Competitors.Find(competitor.Id);
                if (item != null)
                {
                    olympicGamesDBContext.Entry(item).CurrentValues.SetValues(competitor);
                    olympicGamesDBContext.SaveChanges();
                }
       //     }           
        }

        public void DeleteCompetitorById(int id)
        {
       //     using (olympicGamesDBContext = new OlympicGamesDBContext())
       //     {
                var item = olympicGamesDBContext.Competitors.Find(id);
                if (item != null)
                {
                    olympicGamesDBContext.Remove(item);
                    olympicGamesDBContext.SaveChanges();
                }
            }       
        //}
    }
}
