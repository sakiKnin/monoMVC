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
	
 		private readonly ApplicationDbContext _context;
		
 		public VehicleModelService(ApplicationDbContext context)
 		{
		
				_context = context;
				
 		}
 		
    		public async Task<List<VehicleModelEntity>> GetVehiclesAsync()
    		{

			var vehicles = new VehicleModelList( _context );
    			
    			return await vehicles.GetVehiclesAsync();		 
    		}
    
	}
}
