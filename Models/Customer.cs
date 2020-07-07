using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSIP.API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string LicenceNumber { get; set; }
        public string Address { get; set; }
        public int RentalHistoryId { get; set; }
        public int LicenceCategoryId { get; set; }
        public int DocumentId { get; set; }

        [ForeignKey("CustomerRefId")]
        public ICollection<Reservation> Reservations { get; set; }
    }
}
