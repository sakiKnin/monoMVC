using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using monoMVC.Models;

namespace monoMVC.Services{

	public interface IVehicleModelService
	{
	
		Task<List<VehicleModelView>> GetVehiclesAsync();
		Task<VehicleModelView> GetVehicleByIdAsync(int id);
		Task<List<VehicleModelView>> GetSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int pageSize);
		Task<List<VehicleMakeView>> GetVehiclesMakeWithoutVModelAsync();
		Task<int> GetCountAsync();
		Task SaveChangesAsync();
		void AddVehicle(VehicleModelView vehicle);
		void UpdateVehicle<T>(VehicleModelView vehicle);
		void RemoveVehicle<T>(VehicleModelView vehicle);

	
		
	}
	
}
