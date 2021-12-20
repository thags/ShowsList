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
        public static List<Show> GetShows()
        {
            using (var db = new ShowDbContext())
            {
                List<Show> ShowsList = new List<Show>();
                foreach(Show show in db.Shows)
                {
                    ShowsList.Add(show);
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


