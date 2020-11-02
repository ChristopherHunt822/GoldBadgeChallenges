using KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Claim = KomodoClaims_Repository.Claim;

namespace KomodoClaims_Console
{
    public class ProgramUI
    {
        private ClaimsQueueRepository _repo = new ClaimsQueueRepository();
        // private Queue<Claim> _myrepo = new Queue<Claim>();
        
        public void Run()
        {
            SeedContent();
            Menu();
        }
        private void SeedContent()
        {
            
            Claim claim1 = new Claim(1, ClaimType.Car, "Car accident on 465",
                400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen",
                4000.00m, new DateTime(2018, 4, 11), new DateTime(2018, 4, 18), true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.",
                4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1), false);
            _repo.CreateClaim(claim1);
            _repo.CreateClaim(claim2);
            _repo.CreateClaim(claim3);
        }

        public void Menu()
        {

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the Number of the option you'd like to select:\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim.\n" +
                    "3. Enter a new claim.\n" +
                    "4. Exit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option(1-4)");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> queueList = _repo.ShowListOfClaims();
            foreach (Claim claim in queueList)
            {
                AllClaims(claim);
                //DisplayContent(claim);
                Console.WriteLine();
                
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void TakeNextClaim()
        {
            Console.Clear();
            Queue<Claim> queueList = _repo.ShowListOfClaims();
            
            Claim peekClaim = _repo.ViewNextClaim();
                Console.Clear();
                DisplayContent(peekClaim);
            // Console.WriteLine(peekClaim);
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string response = Console.ReadLine().ToLower();

            if (response == "y")
            {
                _repo.RemoveClaimFromQueue();
                Console.WriteLine("Claim Successfully removed from Queue");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Press any key to return to main menu.");
                Console.Read();
            }

        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("Enter ClaimID Number: ");
            string iDAsString = Console.ReadLine();
            int idAsInt = Int32.Parse(iDAsString);
            newClaim.ClaimID = idAsInt;

            Console.WriteLine("Enter Claim Type:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string typeinput = Console.ReadLine();
            int typeAsInt = int.Parse(typeinput);
            newClaim.ClaimType = (ClaimType)typeAsInt;

            Console.WriteLine("Enter Claim Description: ");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter Amount of Claim(no $ sign)");
            newClaim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());


            Console.WriteLine("Enter Date of Incident(MM/DD/YYYY): ");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date of Claim(MM/DD/YYYY): ");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            double checkValidity = CalculateIsValid(newClaim.DateOfClaim, newClaim.DateOfIncident);
            if (checkValidity <= 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            bool claimCreated = _repo.CreateClaim(newClaim);
            if (claimCreated == true)
            {
                Console.WriteLine("Claim successfully added to queue");
            }
            else
            {
                Console.WriteLine("Oops something went wrong. Claim not added.");
            }
            Console.Read();

    }
        private void AllClaims(Claim claims)
        {
            Console.Clear();
            Console.WriteLine("{0, -5}{1, 8}{2, 23}{3, 10}{4, 25}{5, 25}{6, 15}", 
                "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            // Console.WriteLine("ClaimId     Type    Description         Amount      DateOfAccident              DateOfClaim        IsValid");
            Queue<Claim> queueList = _repo.ShowListOfClaims();
            foreach (Claim claim in queueList)
            {
                DisplayContent2(claim);
                Console.WriteLine();
            }
        }
        private void DisplayContent(Claim claim)
        {
            Console.WriteLine($"CLaimID: {claim.ClaimID}");
            Console.WriteLine($"Type: {claim.ClaimType}");
            Console.WriteLine($"Description: {claim.Description}");
            Console.WriteLine($"Amount: {claim.ClaimAmount}");
            Console.WriteLine($"DateOfIncident: {claim.DateOfIncident}");
            Console.WriteLine($"DateOfClaim: {claim.DateOfClaim}");
            Console.WriteLine($"IsValid {claim.IsValid}");
        }
        private void DisplayContent2(Claim claim)
        {
            Console.WriteLine("{0, 0}{1, 12}{2, 25}{3, 10}{4, 25}{5, 25}{6, 15}", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount, claim.DateOfIncident, claim.DateOfClaim, claim.IsValid);
            //Console.WriteLine($"   {claim.ClaimID}        {claim.ClaimType}    {claim.Description}    {claim.ClaimAmount}" +
              //  $"    {claim.DateOfIncident}    {claim.DateOfClaim}    {claim.IsValid}");
        }

        private double CalculateIsValid(DateTime datetime2, DateTime datetime)
        {
            
            TimeSpan daySpan = datetime2 - datetime;
            double days = daySpan.TotalDays;
            return days;
        }


        }
    }

