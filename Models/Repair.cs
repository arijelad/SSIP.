using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSIP.API.Models
{
    public class Repair
    {
        public int RepairId { get; set; }
        public string RepairDetail { get; set; }
        public DateTime RepairDate { get; set; }

        [ForeignKey("RepairRefId")]
        public ICollection<Detail> Details { get; set; }
    }
}
