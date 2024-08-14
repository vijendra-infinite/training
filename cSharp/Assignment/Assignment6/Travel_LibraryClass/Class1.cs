using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_LibraryClass
{

        public class TicketBooking
        {
            public const decimal TotalFare = 500m;

            public string Name { get; set; }
            public int Age { get; set; }

            public string CalculateConcession()
            {
                if (Age <= 5)
                {
                    return "Little Champs - Free Ticket";
                }
                else if (Age > 60)
                {
                    decimal concessionAmount = TotalFare * 0.3m;
                    decimal discountedFare = TotalFare - concessionAmount;
                    return $"Senior Citizen - Fare after 30% concession: {discountedFare:C}";
                }
                else
                {
                    return $"Ticket Booked - Fare: {TotalFare:C}";
                }
            }
        }
}
