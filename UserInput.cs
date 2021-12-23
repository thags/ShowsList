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
        private DbManager Database = new DbManager();
        private TableVisualisationEngine ConsoleView = new TableVisualisationEngine();
        public void MainMenu()
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
                        ConsoleView.View(Database.GetShows(5));
                        Show chosenShow = ChooseShowFromDBById(Database.GetShows(), out int showId);
                        ConsoleView.View(new List<Show> {chosenShow});
                        Database.EditShow(showId, EditShowFromDB(chosenShow));
                        break;
                    case "D":
                        Console.Clear();
                        ConsoleView.View(Database.GetShows(5));
                        Show chosenShowToDel = ChooseShowFromDBById(Database.GetShows(), out int showToDelId);
                        Database.RemoveShow(showToDelId);
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

        private void ViewMenu()
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
                        ConsoleView.View(Database.GetShows());
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
        private Show EditShowFromDB(Show showToEdit)
        {
            bool userWantsExit = false;
            do
            {
                Console.Clear();
                PrintSeperationLine();
                ConsoleView.View(new List<Show> { showToEdit });
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
        private Show ChooseShowFromDBById(List<Show> showsList, out int showId)
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
        private void CreateShow()
        {
            Console.Clear();
            string title = GetShowTitle();
            int totalEpisodes = GetTotalEpisodes();
            Database.AddShow(new Show { Title = title, TotalEpisodes = totalEpisodes });
            
        }
        private string GetShowTitle()
        {
            Console.WriteLine("What is the Title of the show?");
            return Console.ReadLine();
        }
        private int GetTotalEpisodes()
        {
            bool isANumber;
            int result;
            do
            {
                Console.WriteLine("How many episodes of the show are there?");
                isANumber = int.TryParse(Console.ReadLine(), out result);
                if (result < 0)
                {
                    isANumber = false;
                    Console.WriteLine("Episodes must not be a negative number, try again.");
                }
            } while (!isANumber);
            return result;
        }
        private void PrintSeperationLine() => Console.WriteLine("\n---------------------\n");
        private string GetUserMenuChoiceInput() => Console.ReadLine().ToUpper();
    }
}
