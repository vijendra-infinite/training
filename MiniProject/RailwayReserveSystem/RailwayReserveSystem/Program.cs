using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReserveSystem
{
    public class Program
    {
        static MiniProject_RailwayEntities db = new MiniProject_RailwayEntities();
        static train Trains = new train();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Train Booking Project ");
            Console.WriteLine("\n1. Press 1 to Login as admin");
            Console.WriteLine("\n2. Press 2 to Login as user");
            Console.WriteLine("\n3. Press 3 to Exit");

            Console.Write("\nEnter your choice: ");
            string LoginType = Console.ReadLine();


            switch (LoginType)
            {
                case "1":
                     admin();
                    AdminLogin();
                   
                    break;
                case "2":
                     User();
                     userLogin();
                    //UserControl();
                    break;
                case "3":
                    Console.WriteLine("\nExiting From the train ticket booking app...");
                    break;
                default:
                    Console.WriteLine(" \nPlease enter a valid option.");
                    break;
            }
            Console.ReadKey();
        }
         public static void admin()
         {
            Console.WriteLine("\n1. Press 1 to Sign In");
            Console.WriteLine("\n2. Press 2 to Create Account as Admin");
            Console.Write("\nEnter your choice: ");
            string LoginType = Console.ReadLine();


            switch (LoginType)
            {
                case "1":

                    AdminLogin();
                    break;
                case "2":
                    CreateAdmin();
                    break;
                default:
                    Console.WriteLine(" \nPlease enter a valid option.");
                    break;
            }
            Console.ReadKey();
         }


        public static void AdminLogin()
        {
            Console.WriteLine(" login using credential");
            Console.WriteLine("\nYou have Selected Admin Login Please enter valid  credential"); //for user username=admin,pass=1234

            Console.Write("\nEnter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
                Console.Write("*");
            }


            var CheckUser = db.Admins.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (CheckUser != null)
            {
                Console.WriteLine("\nYou have Login successfully");
                // method to display  the admin controls 
                 AdminControlMenu();
            }
            else
            {
                Console.WriteLine("\nAdmin login failed: try again...");
            }
        }
        
    
        public static void CreateAdmin()

        { 
             Console.WriteLine("enter AdminId");
             int AdminId =Convert.ToInt32( Console.ReadLine());
             Console.WriteLine("enter username");
             string Username = Console.ReadLine();
             Console.WriteLine("Enter your phone number:");
             int phoneNumber;
            while (!int.TryParse(Console.ReadLine(), out phoneNumber))
            {
                Console.WriteLine("Invalid phone number. Please enter a numeric value:");
            }

            Console.Write("Enter your password: ");
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
                Console.Write("*");
            }
            Console.Write("Enter your password: ");
            string confirmpassword = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                confirmpassword += key.KeyChar;
                Console.Write("*");
            }
            if (password == confirmpassword)
            {
                Console.WriteLine("Passwords match. Proceeding with admin creation...");

                db.InsertAdmin(AdminId, Username, phoneNumber, password);
                Console.WriteLine("Admin created sucessfully");

                AdminLogin();
            }
            else
            {
                Console.WriteLine("Passwords do not match. Please try again.");
            }
           

        }
        public static void AdminControlMenu()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-----------------------------------------");
                    Console.WriteLine("\nAdmin Menu:");
                    Console.WriteLine("\nEnter 1. Add Train");
                    Console.WriteLine("\nEnter 2. Modify Train");
                    Console.WriteLine("\nEnter 3. Soft Delete Train");
                    Console.WriteLine("\nEnter 4. Toggle between Train Status");
                    Console.WriteLine("\nEnter 5. View All train");
                    Console.WriteLine("\nEnter 6. All Booking details");
                    Console.WriteLine("\nEnter 7. All Canceled Ticked  details");
                    Console.WriteLine("\nEnter 8. Exit");

                    Console.Write("\nEnter your choice: ");

                    string AdminInput = Console.ReadLine();
                    switch (AdminInput)
                    {
                        case "1":
                         AddTrain();
                           break;
                        case "2":
                            ModifyTrain();
                            break;
                        case "3":
                            SoftDeleteTrain();
                            break;
                        case "4":
                            ChangeTrainStatusActiveInactive();
                            break;
                        case "5":
                            ShowAlltrain();
                            break;
                        case "6":
                            ShowALLBooking();
                            break;
                        case "7":
                            ShowAllCancel();
                            break;
                        case "8":
                            Console.WriteLine("Exiting...");
                            return; // Exit the method and stop the while loop
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }


        public static void AddTrain()
        {

            try
            {
                // Generate a random train ID
                Random random = new Random();
                int newTrainID;
                // Ensure the generated ID is unique
                do
                {
                    newTrainID = random.Next(10000, 99999); // Generates a random number between 10000 and 99999
                } while (db.trains.Any(t => t.trainID == newTrainID));
                Trains.trainID = newTrainID;


                Console.Write("\nEnter Train Name: ");
                Trains.trainName = Console.ReadLine();

                Console.Write("\nEnter Source: ");
                Trains.Source = Console.ReadLine();

                Console.Write("\nEnter Destination: ");
                Trains.Destination = Console.ReadLine();
                Trains.Status = "1";

                // Call the stored procedure to add a new train
                db.trains.Add(Trains);
                db.SaveChanges();

                Console.WriteLine("Train added successfully.");
                // AddTrainBerthInfo();

                //Define berth classes and their seats
                var Classes = new List<string> { "1AC", "3AC", "Sleepar" };

                foreach (var Class in Classes)
                {
                    Console.WriteLine($"\nEnter Total Seats for {Class} for :{Trains.trainID} , {Trains.trainName} ");
                    int totalSeats = int.Parse(Console.ReadLine());

                    // Set availableSeats equal to totalSeats
                    int AvailableSeats = totalSeats;


                    Console.WriteLine($"\nEnter Price for {Class} for :{Trains.trainID}  , {Trains.trainName} ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    // call the stored procedure to add train class information
                    db.AddTrainClassInfo(Trains.trainID, Class, totalSeats, price);
                    db.SaveChanges();

                }
                Console.WriteLine("Train  added successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: { ex.Message}");
            }
            ShowAlltrain();
        }

        public static void ModifyTrain()
        {
            try
            {
                Console.Write("Enter Train ID to update: ");
                int trainID = int.Parse(Console.ReadLine());

                Console.Write("Enter updated Train Name: ");
                string trainName = Console.ReadLine();

                Console.Write("Enter updated Source: ");
                string Source = Console.ReadLine();

                Console.Write("Enter updated Destination: ");
                string Destination = Console.ReadLine();

                // Call the stored procedure to update an existing train
                db.ModifyTrain(trainID, trainName, Source, Destination);
                Console.WriteLine("Train Updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: { ex.Message}");
            }
            ShowAlltrain();
        }

        public static void SoftDeleteTrain()
        {

            Console.Write("Enter Train ID to soft delete: ");
            int trainID = int.Parse(Console.ReadLine());

            // Call the stored procedure  to delete train to make its status inactive

            //soft delete train mark the status of that train is inactive
            db.SoftDeleteTrain(trainID);
            db.SaveChanges();

            Console.WriteLine("Train soft deleted successfully.");

        }


        public static void ChangeTrainStatusActiveInactive()
        {
            Console.WriteLine("\n if status is 1(active)/0(Inactive) it will make it Inactive(0)/Active(1)");
            Console.Write("\nEnter Train ID to change  status: ");
            int trainID = int.Parse(Console.ReadLine());

            // Call the stored procedure to toggle train status between active and inactive
            db.ChangeTrainStatus(trainID);


            db.ViewTrainStatus(trainID);
            db.SaveChanges();

            Console.WriteLine("Train status changed  successfully.");

        }
        public static void ShowAlltrain()
        {
            var trains = db.ShowAllTrain().ToList();
            Console.WriteLine("\nTrains:");
            foreach (var train in trains)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"TrainID: {train.trainID}, TrainName: {train.trainName},||   Source: {train.Source} to Destination: {train.Destination}  || Status: {(train.Status == "n" ? "Inactive" : "Active")}");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.ReadLine();
            }
        }



        public static void User()
        {
            Console.WriteLine("\n1. Press 1 to Sign In");
            Console.WriteLine("\n2. Press 2 to Create Account as User");
            Console.Write("\nEnter your choice: ");
            string LoginType = Console.ReadLine();


            switch (LoginType)
            {
                case "1":

                    userLogin();
                    break;
                case "2":
                    Createuser();
                    break;
                default:
                    Console.WriteLine(" \nPlease enter a valid option.");
                    break;
            }
            Console.ReadKey();
        }


        public static void userLogin()
        {
            Console.WriteLine(" login using credential");
            Console.WriteLine("\nYou have Selected user Login Please enter valid  credential"); //for user username=admin,pass=1234

            Console.Write("\nEnter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
                Console.Write("*");
            }


            var CheckUser = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (CheckUser != null)
            {
                Console.WriteLine("\nYou have Login successfully");
                // method to display  the user controls 
                UserControlMenu();
            }
            else
            {
                Console.WriteLine("\nUser login failed: try again...");

                User();
            }
        }


        public static void Createuser()

        {
            Console.WriteLine("enter UserId");
            int UserID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter username");
            string Username = Console.ReadLine();
            Console.WriteLine("Enter your phone number:");
            int phoneNumber;
            while (!int.TryParse(Console.ReadLine(), out phoneNumber))
            {
                Console.WriteLine("Invalid phone number. Please enter a numeric value:");
            }
            Console.Write("Enter your password: ");
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
                Console.Write("*");
            }
            Console.Write("Confirm your password: ");
            string confirmpassword = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                confirmpassword += key.KeyChar;
                Console.Write("*");
            }
            if (password == confirmpassword)
            {
                Console.WriteLine("Passwords match. Proceeding with User creation...");

                db.InsertUsers(UserID, Username, phoneNumber, password);
                Console.WriteLine("User created sucessfully");

                userLogin();
            }
            else
            {
                Console.WriteLine("Passwords do not match. Please try again.");
            }


        }
        public static void UserControlMenu()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n\n-----------------------------------------");

                    Console.WriteLine("\nUser  Menu:");
                    Console.WriteLine("\nEnter 1. Show All Trains");
                    Console.WriteLine("\nEnter 2. BookTickit");
                    Console.WriteLine("\nEnter 3. Print Ticket Information");
                    Console.WriteLine("\nEnter 4. Cancel Ticket");
                    Console.WriteLine("\nEnter 6. Exit");

                    Console.Write("\nEnter your choice: ");

                    string UserInput = Console.ReadLine();
                    switch (UserInput)
                    {
                        case "1":
                            ShowAlltrain();
                            break;
                        case "2":
                            BookTicket();
                            break;
                        case "3":
                            PrintTicket();
                            break;
                        case "4":
                            Cancelticket();
                            break;
                        case "5":
                            Console.WriteLine("Exiting...");
                            return; // Exit the method and stop the while loop
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        //public static void ActiveTrainInfo()
        //{
        //    try
        //    {
        //        var activeTrains = db.GetActiveTrains().ToList();
        //        foreach (var train in activeTrains)
        //        {
        //            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
        //            Console.WriteLine($"TrainID: {train.trainID}, TrainName: {train.trainName}, Source: {train.Source}, Destination: {train.Destination}, Status: Active Running Trains ");
        //            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }
        //}
        //public static void BirthInformation()
        //{
        //    Console.Write("\nEnter Train ID to see Birth details for You want to book ticket : ");
        //    int trainID = int.Parse(Console.ReadLine());
        //    var trainStatus = db.ViewTrainStatus(trainID).FirstOrDefault()?.Status;

        //    if (trainStatus == "N")
        //    {
        //        Console.WriteLine("Sorry, the train is inactive. Cannot book a ticket.");
        //        return;
        //    }
        //    var TrainbirthInfos = db.GetBirthDetal(trainID).ToList();

        //    if (TrainbirthInfos.Count > 0)
        //    {
        //        foreach (var train in TrainbirthInfos)
        //        {
        //            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        //            Console.WriteLine($"Train : {train.TrainID} / Birth Class  : {train.Class} / Available Seats : {train.AvailableSeats} / Total Seats :{train.TotalSeats}");
        //            Console.WriteLine($"Price  :{train.price}");
        //            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        //        Console.WriteLine("Error: Data is not available for the specified Train ID.");
        //        Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        //        Environment.Exit(0);
        //    }

        //}

        public static void BookTicket()
        {
           // ActiveTrainInfo();
           // BirthInformation();

            try
            {

                Console.WriteLine("\nEnter details to Book TICKET");
                // Step 1: Get Source and Destination
                Console.WriteLine("\nEnter Source Station:");
                string source = Console.ReadLine();
                Console.WriteLine("\nEnter Destination Station:");
                string destination = Console.ReadLine();
                // Step 2: Call the GetTrainsByRoute procedure
                var availableTrains =db.GetTrainsByRoute(source,destination).ToList();
                if (availableTrains == null || !availableTrains.Any())
                {
                    Console.WriteLine("No trains available for the selected route.");
                    return;

                }
                else
                {
                    Console.WriteLine("Available trains for the selected route:");
                    foreach (var train in availableTrains)
                    {
                        Console.WriteLine($"Train ID: {train.trainID}, Train Name: {train.trainName}");
                    }
                }
                Console.WriteLine("\nEnter Train Number :");
                int trainID = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter Your Name :");
                string userName = Console.ReadLine();
               
                int trainStatus =Convert.ToInt32( db.ViewTrainStatus(trainID).FirstOrDefault()?.Status);

                if (trainStatus ==0)
                {
                    Console.WriteLine("Sorry, the train is inactive. Cannot book a ticket.");
                    return;
                }
                Console.WriteLine("\nEnter  Class in which you want to travel:");
                string Class = Console.ReadLine();

                Console.WriteLine("\nHow Many Tickets You Want TO book:");
                int totalTickets =Convert.ToInt32(Console.ReadLine());
                if(totalTickets>5)
                {
                    Console.WriteLine("cannot book more than 5 tickets using single login id");
                }
                else
                {


                    db.BookTrainTicket(userName, trainID, Class, totalTickets);


                    var lastBookingID = db.GetLastBookingID().FirstOrDefault();//gives me last booking id because it sets as identity(1,1) so it will give me always max(booking id created last time)


                    Console.WriteLine("||-------------------------------------------------------------------------------------------------------||");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");

                    Console.WriteLine($"Your ticket Booked Successfully, your booking ID is: {lastBookingID.Value}");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("----------------------------------------------------note always remember your booking id----------------");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void PrintTicket()
        {
            Console.WriteLine("Enter Your Booking ID");
            int bookingId = int.Parse(Console.ReadLine());
            var ticket = db.Printticket(bookingId).FirstOrDefault();
            if (ticket != null)
            {

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("            TICKET DETAILS           ");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Booking ID: {ticket.BookingID}");
                Console.WriteLine($"Train ID: {ticket.TrainID}");
                Console.WriteLine($"User Name: {ticket.UserName}");
                Console.WriteLine($"Berth Class: {ticket.ClassType}");
                Console.WriteLine($"Total Tickets: {ticket.Totaltickets}");
                Console.WriteLine($"Booking Status: {(ticket.BookingStatus == "Y" ? "Active" : "Inactive")}");
                Console.WriteLine($"Payment Amount: ₹{ticket.payment_amount}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("               Thnaks                ");
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }

        }

        public static void Cancelticket()
        {
            Console.WriteLine("Enter Your Booking ID");
            int bookingId = int.Parse(Console.ReadLine());
            db.CancelTicketData(bookingId);
            var RefundAmount = db.CancelTickets.FirstOrDefault(ct => ct.BookingID == bookingId)?.RefundAmount;
            Console.WriteLine("Ticket cancelled successfully. you wil be refunded 60% of paid amount  ");
            Console.WriteLine($"RefundAmount for BookingID {bookingId}: {RefundAmount}");
            var CancelID = db.CancelTickets.FirstOrDefault(ct => ct.BookingID == bookingId)?.CancelTicketID;
            Console.WriteLine($"\n YourCancellation Id is : {CancelID}");
        }

        public static void ShowALLBooking()
        {

            var bookings = db.Bookings.ToList();
            foreach (var booking in bookings)
            {
                Console.WriteLine($"BookingID: {booking.BookingID} || TrainID: { booking.TrainID}");

                Console.WriteLine($"UserName: {booking.UserName}|| BerthType: { booking.ClassType}");

                Console.WriteLine($"TotalTickets: {booking.Totaltickets}  ||  BookingStatus: {(booking.BookingStatus == "Y" ? "Active" : "Inactive")}");


                Console.WriteLine($"PaymentAmount: {booking.payment_amount}");
                Console.WriteLine("---------------------------------------------------------------------------------");
            }



        }
        public static void ShowAllCancel()
        {
            var CanceTic = db.CancelTickets.ToList();
            foreach (var cancel in CanceTic)
            {
                Console.WriteLine($"CancelTicketID: {cancel.CancelTicketID} ||  BookingID: {cancel.BookingID}");


                Console.WriteLine($"RefundAmount: {cancel.RefundAmount}     || CancelDate: {cancel.CancelDate}");

                Console.WriteLine("----------------------------------------");
            }
        }

    }

}
