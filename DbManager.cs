using System;
using System.Data.Entity;
using Shows.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
{
    class DbManager
    {
        public static void AddShow(Show showToAdd)
        {
            using (var db = new ShowDbContext())
            {
                db.Shows.Add(showToAdd);
                db.SaveChanges();
            }
        }
        public static void RemoveShow(int IdToRemove)
        {
            using (var db = new ShowDbContext())
            {
                db.Shows.Remove(db.Shows.Find(IdToRemove));
                db.SaveChanges();
            }
        }
        public static void EditShow(int IdToEdit, Show newValues)
        {
            using (var db = new ShowDbContext())
            {
                Show show = db.Shows.Find(IdToEdit);
                show.Title = newValues.Title;
                show.TotalEpisodes = newValues.TotalEpisodes;
                db.SaveChanges();
            }
        }
        public static List<Show> GetShows(int howManyShowsToGet = -1)
        {

            using (var db = new ShowDbContext())
            {
                if (howManyShowsToGet == -1)
                {
                    howManyShowsToGet = db.Shows.Count();
                }
                List<Show> ShowsList = new List<Show>();
                int i = 0;
                foreach(Show show in db.Shows.OrderByDescending(show => show.Id))
                {
                    ShowsList.Add(show);
                    i++;
                    if (i == howManyShowsToGet)
                    {
                        return ShowsList;
                    }
                }
                return ShowsList;
            }
        }

    }   

    public class ShowDbContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
    }
}


