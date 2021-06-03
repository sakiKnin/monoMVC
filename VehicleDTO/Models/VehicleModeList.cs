using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using VehicleDTO.Data;

namespace VehicleDTO.Models
{
   public class VehicleModelList : List<VehicleModelEntity>
   {

	public static List<VehicleModelEntity> vehicleModelList { get; set; } = new List<VehicleModelEntity>();

	private readonly ApplicationDbContext _context;

	public VehicleModelList(ApplicationDbContext context)
	{
		
				_context = context;
				
				vehicleModelList = GetVehiclesEntity();
								
	}

	public List<VehicleModelEntity> GetVehiclesEntity()
	{

		return _context.VehicleModelEntity.AsNoTracking().ToList();

	}
        
	public static List<VehicleModelEntity> GetVehicles()
  	{

			return vehicleModelList;
					
	}
   
      		
    }

}
