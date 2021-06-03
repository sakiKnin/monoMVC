using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using VehicleDTO.Models;
using VehicleDTO.Data;

namespace monoMVC.Services
{
	public class VehicleModelService : IVehicleModelService
	{
	
    		public async Task<List<VehicleModelEntity>> GetVehiclesAsync()
    		{

    			return VehicleModelList.GetVehicles();
			
    		}
    
	}
}
