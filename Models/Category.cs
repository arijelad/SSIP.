using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSIP.API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("CategoryRefId")]
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}

