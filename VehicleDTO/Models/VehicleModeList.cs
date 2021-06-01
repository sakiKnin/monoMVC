using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using VehicleDTO.Data;

namespace VehicleDTO.Models
{
   public class VehicleModelList : IVehicleModelList
   {

	public List<VehicleModelEntity> vehicleModelList = new List<VehicleModelEntity>();

	private readonly ApplicationDbContext _context;

	public VehicleModelList(ApplicationDbContext context)
	{

	       			_context = context;

	}
        
	public async Task<List<VehicleModelEntity>> GetVehiclesAsync()
  	{

			return await _context.VehicleModelEntity.ToListAsync();
			
	}
   
      		
    }

}
