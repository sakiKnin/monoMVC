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
       	 [StringLength(200, MinimumLength=3)]
	 [Display(Name="Vehicle Name")]
         public string Name { get; set; }

	 [Required]
         [StringLength(100, MinimumLength=3)]
	 [Display(Name="Vehicle Abbrevation")]
         public string Abbrevation { get; set; }
    }
}
