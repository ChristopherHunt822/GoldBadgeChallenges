using KomodoOutings_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KomodoOutings_Repository.Outings;

namespace KomodoOutings_Console
{
    public class ProgramUI
    {
        private Outings_Repo _repo = new Outings_Repo();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        private void SeedContent()
        {
            Outings outing1 = new Outings(new DateTime(2020, 4, 30), EventType.GOLF, 10000m, 200, 50m);
            Outings outing2 = new Outings(new DateTime(2020, 5, 22), EventType.BOWLING, 5000m, 200, 25m);
            Outings outing3 = new Outings(new DateTime(2020, 5, 29), EventType.BOWLING, 500m, 10, 50m);
            Outings outing4 = new Outings(new DateTime(2020, 6, 21), EventType.AMUSEMENTPARK, 20000m, 400, 50m);
            Outings outing5 = new Outings(new DateTime(2020, 7, 4), EventType.CONCERT, 50000m, 500, 100m);

            _repo.AddOutingToDirectory(outing1);
            _repo.AddOutingToDirectory(outing2);
            _repo.AddOutingToDirectory(outing3);
            _repo.AddOutingToDirectory(outing4);
            _repo.AddOutingToDirectory(outing5);
        }
        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of the option you'd liek to select:\n" +
                    "1. Display all outings.\n" +
                    "2. Add new Outing.\n" +
                    "3. See Combined cost of all outings.\n" +
                    "4. See cost by Type:Golf\n" +
                    "5. See cost by Type:Bowling\n" +
                    "6. See cost by Type:AmusementPark\n" +
                    "7. See cost by Type:Concert\n" +
                    "8. Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowAllOutings();
                        break;
                    case "2":
                        AddNewOuting();
                        break;
                    case "3":
                        AddCostOfAllOutings();
                        break;
                    case "4":
                        AddCostOfAllGolfOutings();
                        break;
                    case "5":
                        AddCostOfAllBowlingOutings();
                        break;
                    case "6":
                        AddCostOfAllAmusementParkOutings();
                        break;
                    case "7":
                        AddCostOfAllConcertOutings();
                        break;
                    case "8":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllOutings()
        {
            Console.Clear();
            List<Outings> allOutings = _repo.GetOutingsList();

            foreach(Outings outing in allOutings)
            {
                DisplayOutings(outing);
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void AddNewOuting()
        {
            Console.Clear();
            Outings newOuting = new Outings();

            Console.WriteLine("Enter Date of Outing(MM/DD/YYYY):");
            newOuting.Date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Event Type:\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusement Park\n" +
                "4. Concert");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newOuting.Type = (EventType)typeAsInt;

            Console.WriteLine("Enter Event Cost(no $):");
            string costAsString = Console.ReadLine();
            decimal costAsDecimal = decimal.Parse(costAsString);
            newOuting.EventCost = costAsDecimal;

            Console.WriteLine("Enter Number in Attendance:");
            string attendanceAsString = Console.ReadLine();
            int attendanceAsInt = int.Parse(attendanceAsString);
            newOuting.Attendance = attendanceAsInt;

            newOuting.CostPerPerson = costAsDecimal / attendanceAsInt;

            bool outingAdded = _repo.AddOutingToDirectory(newOuting);
            if (outingAdded ==true)
            {
                Console.WriteLine("Outing successfully added to list");
            }
            else
            {
                Console.WriteLine("Uh oh, something went wrong. The outing was NOT added.");
            }
            Console.Read();
        }

        private void AddCostOfAllOutings()
        {
            decimal x = 0;
            List<Outings> outingsList = _repo.GetOutingsList();
            foreach (Outings outing in outingsList)
            {
                x += outing.EventCost;
            }
            Console.WriteLine("Total cost of all events is $" + x);
            Console.Read();
        }
        private void AddCostOfAllGolfOutings()
        {
            decimal x = 0;
            List<Outings> outingsList = _repo.GetOutingsList();
            foreach (Outings outing in outingsList)
            {
                if(outing.Type == EventType.GOLF)
                {
                     x += outing.EventCost;
                }
            }
            Console.WriteLine("Total cost of all golf events is $" + x);
            Console.Read();
        }
        private void AddCostOfAllBowlingOutings()
        {
            decimal x = 0;
            List<Outings> outingsList = _repo.GetOutingsList();
            foreach (Outings outing in outingsList)
            {
                if (outing.Type == EventType.BOWLING)
                {
                    x += outing.EventCost;
                }
            }
            Console.WriteLine("Total cost of all golf events is $" + x);
            Console.Read();
        }
        private void AddCostOfAllAmusementParkOutings()
        {
            decimal x = 0;
            List<Outings> outingsList = _repo.GetOutingsList();
            foreach (Outings outing in outingsList)
            {
                if (outing.Type == EventType.AMUSEMENTPARK)
                {
                    x += outing.EventCost;
                }
            }
            Console.WriteLine("Total cost of all golf events is $" + x);
            Console.Read();
        }
        private void AddCostOfAllConcertOutings()
        {
            decimal x = 0;
            List<Outings> outingsList = _repo.GetOutingsList();
            foreach (Outings outing in outingsList)
            {
                if (outing.Type == EventType.CONCERT)
                {
                    x += outing.EventCost;
                }
            }
            Console.WriteLine("Total cost of all golf events is $" + x);
            Console.Read();
        }
        private void DisplayOutings(Outings outing)
        {
            Console.WriteLine($"Date: {outing.Date.ToString("d")}");
            Console.WriteLine($"Event Type: {outing.Type}");
            Console.WriteLine($"Event Cost: ${outing.EventCost}");
            Console.WriteLine($"Attendance: {outing.Attendance}");
            Console.WriteLine($"Cost Per Person: ${outing.CostPerPerson}");
        }
    }
}
