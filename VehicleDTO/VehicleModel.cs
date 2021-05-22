using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleDTO
{
    public class VehicleModel
    {
         public int Id {get; set;}

	 public int MakeId {get; set;}
	
	 [Required]
       	 [StringLength(200)]
         public string Name { get; set; }

         [StringLength(100)]
         public string Abbrevation { get; set; }
    }
}
