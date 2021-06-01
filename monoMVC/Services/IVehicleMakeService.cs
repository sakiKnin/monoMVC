using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using VehicleDTO.Models;

namespace monoMVC.Services{

	public interface IVehicleMakeService
	{
	
		Task<List<VehicleMakeEntity>> GetVehiclesAsync();
		Task<VehicleMakeEntity> GetVehicleByIdAsync(int id);
		Task<List<VehicleMakeEntity>> GetSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int PageSize);
		Task<int> GetCountAsync();
		Task SaveChangesAsync();
		void AddVehicle<T>(T vehicle);
		void UpdateVehicle<T>(T vehicle);
		void RemoveVehicle(VehicleMakeEntity vehicle);
		 
	}

}
