using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using VehicleDTO.Models;

namespace monoMVC.Services{

	public interface IVehicleModelService
	{
	
		Task<List<VehicleModelEntity>> GetVehiclesAsync();
	
		
	}
	
}
