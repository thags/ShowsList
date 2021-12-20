using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shows
{
    class UserInput
    {
        public static void MainMenu()
        {
            bool userWantsExit = false;
            do
            {
                Console.Clear();
                PrintSeperationLine();
                Console.WriteLine("Welcome to Shows List!");
                Console.WriteLine("Options:");
                Console.WriteLine("A to add a show");
                Console.WriteLine("V to view shows");
                Console.WriteLine("E to edit a show");
                Console.WriteLine("D to delete a show ");
                Console.WriteLine("0 to exit");
                PrintSeperationLine();

                switch (GetUserMenuChoiceInput())
                {
                    case "A":
                        break;
                    case "V":
                        break;
                    case "E":
                        break;
                    case "D":
                        break;
                    case "0":
                        userWantsExit = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            } while (!userWantsExit);
            

        }
        private static void PrintSeperationLine() => Console.WriteLine("\n---------------------\n");
        private static string GetUserMenuChoiceInput() => Console.ReadLine().ToUpper();
    }
}
