using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSIP.API.Models
{
    public class Detail
    {
        public int DetailId { get; set; }
        public DateTime LastService { get; set; }
        public DateTime LastBigService { get; set; }
        public int YearOfManufacture { get; set; }
        public DateTime regExpiration { get; set; }

        
        public int RepairRefId { get; set; }
        public Repair Repair { get; set; }


        [ForeignKey("DetailRefId")]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}





