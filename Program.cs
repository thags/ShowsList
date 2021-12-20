using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shows.Models;

namespace Shows
{
    class Program
    {
        static void Main(string[] args)
        {
            DbManager.AddShow(new Show { Title = "testFromMethod", TotalEpisodes = 12 });
            foreach (Show show in DbManager.GetShows())
            {
                Console.WriteLine(show.Id);
                Console.WriteLine(show.Title);
                Console.WriteLine(show.TotalEpisodes);

            }

        }
    }
}
