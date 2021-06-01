using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

//using monoMVC.Services;
using VehicleDTO.Data;

namespace VehicleDTO.Models
{
    public class VehicleModelEntity : VehicleModel
    {

        public VehicleMakeEntity VehicleMakeEntity { get; set; }

    }
}
