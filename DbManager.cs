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

                foreach (Show post in db.Shows)
                {
                    Console.WriteLine(post.Title);
                }
            }
        }
    }   

    public class ShowDbContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
    }
}


