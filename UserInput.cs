using System;
using Shows.Models;
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
                Console.WriteLine("A to add a show");
                Console.WriteLine("V to view shows");
                Console.WriteLine("E to edit a show");
                Console.WriteLine("D to delete a show ");
                Console.WriteLine("0 to exit");
                PrintSeperationLine();

                switch (GetUserMenuChoiceInput())
                {
                    case "A":
                        CreateShow();
                        break;
                    case "V":
                        ViewMenu();
                        break;
                    case "E":
                        Console.Clear();
                        TableVisualisationEngine.View(DbManager.GetShows(5));
                        Show chosenShow = ChooseShowFromDBById(DbManager.GetShows(), out int showId);
                        TableVisualisationEngine.View(new List<Show> {chosenShow});
                        DbManager.EditShow(showId, EditShowFromDB(chosenShow));
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

        private static void ViewMenu()
        {
            bool userWantsExit = false;
            do
            {
                Console.Clear();
                PrintSeperationLine();
                Console.WriteLine("A to view all shows");
                Console.WriteLine("0 to go back to main menu");
                PrintSeperationLine();

                switch (GetUserMenuChoiceInput())
                {
                    case "A":
                        TableVisualisationEngine.View(DbManager.GetShows());
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
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
        private static Show EditShowFromDB(Show showToEdit)
        {
            bool userWantsExit = false;
            do
            {
                Console.Clear();
                PrintSeperationLine();
                TableVisualisationEngine.View(new List<Show> { showToEdit });
                Console.WriteLine("T to edit the title");
                Console.WriteLine("E to edit the total Episodes");
                Console.WriteLine("0 to go back to main menu");
                PrintSeperationLine();

                switch (GetUserMenuChoiceInput())
                {
                    case "T":
                        showToEdit.Title = GetShowTitle();
                        break;
                    case "E":
                        showToEdit.TotalEpisodes = GetTotalEpisodes();
                        break;
                    case "0":
                        userWantsExit = true;
                        break;
                    default:
                        break;
                }
            } while (!userWantsExit);
            
            return showToEdit;
        }
        private static Show ChooseShowFromDBById(List<Show> showsList, out int showId)
        {
            bool isANumber;
            bool isRealChoice;
            Show resultShow = new Show();
            do
            {
                isRealChoice = false;
                Console.WriteLine("Input the Id of the show you want to choose");
                isANumber = int.TryParse(Console.ReadLine(), out int result);
                showId = result;
                if (isANumber)
                {
                    isRealChoice = showsList.Exists(show => show.Id == result);
                    if (isRealChoice)
                    {
                        var chosenShow = from show in showsList
                                     where show.Id == result
                                     select show;
                        resultShow = chosenShow.Single();
                    }
                }
                
            } while (!isANumber && !isRealChoice);
            return resultShow;
            

        }
        private static void CreateShow()
        {
            Console.Clear();
            string title = GetShowTitle();
            int totalEpisodes = GetTotalEpisodes();
            DbManager.AddShow(new Show { Title = title, TotalEpisodes = totalEpisodes });
            
        }
        private static string GetShowTitle()
        {
            Console.WriteLine("What is the Title of the show?");
            return Console.ReadLine();
        }
        private static int GetTotalEpisodes()
        {
            bool isANumber;
            int result;
            do
            {
                Console.WriteLine("How many episodes of the show are there?");
                isANumber = int.TryParse(Console.ReadLine(), out result);
            } while (!isANumber);
            return result;
        }
        private static void PrintSeperationLine() => Console.WriteLine("\n---------------------\n");
        private static string GetUserMenuChoiceInput() => Console.ReadLine().ToUpper();
    }
}
