using System;


namespace SSIP.API.Models
{
    public class Reservation
    {
        public int ReservationId {get; set;}
        public DateTime PickUpDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double TotalPayment { get; set; }

        
        public int VehicleRefId { get; set; }
        public Vehicle Vehicle { get; set; }

        
        public int CustomerRefId { get; set; }
        public Customer Customer { get; set; }
    }
}



