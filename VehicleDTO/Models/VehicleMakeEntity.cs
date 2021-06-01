using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;


using VehicleDTO.Data;

namespace VehicleDTO.Models
{
    public class VehicleMakeEntity : VehicleMake
    {

	public VehicleModelEntity VehicleModelEntity { get; set; }
    }
}
