using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSIP.API.Models
{
    public class Vehicle
    {

        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string LicencePlate { get; set; }
        public int Year { get; set; }
        public int PassangerNumber { get; set; }
        public double Price { get; set; }
        public double Odometar { get; set; }
        public string AdditionalInformation { get; set; }
        public bool Availability { get; set; }

        
        public int CategoryRefId { get; set; }
        public Category Category { get; set; }

        
        public int DetailRefId { get; set; }
        public Detail Detail { get; set; }



        [ForeignKey("VehicleRefId")]
        public ICollection<Reservation> Reservations { get; set; }
    }
}



