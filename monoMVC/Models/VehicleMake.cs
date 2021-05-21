using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//using VehicleDTO;

namespace monoMVC.Models
{
     public class VehicleMake
     {
       public int Id { get; set; }

       [Required]
       [StringLength(200)]
       public string Name { get; set; }

       [StringLength(100)]
       public string Abbrevation { get; set; }

       public VehicleModel VehicleModel { get; set; }
 
    }
}
