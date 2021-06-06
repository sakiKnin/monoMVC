using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using monoMVC.Models;
using VehicleDTO.Models;

namespace monoMVC.Services{

	public interface IVehicleMakeService
	{
	
		Task<List<VehicleMakeView>> GetVehiclesAsync();
		Task<VehicleMakeView> GetVehicleByIdAsync(int id);
		Task<List<VehicleMakeView>> GetSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int PageSize);
		Task<int> GetCountAsync();
		Task SaveChangesAsync();
		void AddVehicle<T>(T vehicle);
		void UpdateVehicle<T>(T vehicle);
		void RemoveVehicle(VehicleMakeView vehicle);
		 
	}

}
