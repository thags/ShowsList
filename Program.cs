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
            //DbManager.AddShow(new Show { Title = "testFromMethod", TotalEpisodes = 12 });
            UserInput.MainMenu();
        }
    }
}
