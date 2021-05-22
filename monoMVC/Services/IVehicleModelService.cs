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
	
		Task<List<VehicleModel>> getVehiclesAsync();
		Task<VehicleModel> getVehicleByIdAsync(int id);
		Task<List<VehicleModel>> getVehiclesByNameAsync(string name);
		Task<List<VehicleModel>> getSortedVehiclesAsync(string sortOrder, int currentPage, int PageSize);
		int getCount();
		Task<List<VehicleMake>> getVehiclesMakeWithoutVModelAsync();
		Task saveChangesAsync();
		void addVehicle<T>(T vehicle);
		void updateVehicle<T>(T vehicle);
		void removeVehicle(VehicleModel vehicle);
		
	}
	
}
