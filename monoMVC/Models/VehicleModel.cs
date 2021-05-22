using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace monoMVC.Models
{
    public class VehicleModel : VehicleDTO.VehicleModel
    {
    
	 public VehicleMake VehicleMake { get; set; }

    }
}
