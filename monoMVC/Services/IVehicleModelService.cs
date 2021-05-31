using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using monoMVC.Models;

namespace monoMVC.Services{

	public interface IVehicleModelService
	{
	
		Task<List<VehicleModel>> GetVehiclesAsync();
		Task<VehicleModel> GetVehicleByIdAsync(int id);
		Task<List<VehicleModel>> GetSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int PageSize);
		Task<int> GetCountAsync();
		Task<List<VehicleMake>> GetVehiclesMakeWithoutVModelAsync();
		Task SaveChangesAsync();
		void AddVehicle<T>(T vehicle);
		void UpdateVehicle<T>(T vehicle);
		void RemoveVehicle(VehicleModel vehicle);
		
	}
	
}
