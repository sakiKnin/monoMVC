using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using monoMVC.Models;

namespace monoMVC.Services{

	public interface IVehicleMakeService
	{
	
		Task<List<VehicleMake>> getVehiclesAsync();
		Task<VehicleMake> getVehicleByIdAsync(int id);
		Task<List<VehicleMake>> getVehiclesByNameAsync(string name);
		Task<List<VehicleMake>> getSortedVehiclesAsync(string sortOrder, int currentPage, int PageSize);
		int getCount();
		Task saveChangesAsync();
		void addVehicle<T>(T vehicle);
		void updateVehicle<T>(T vehicle);
		void removeVehicle(VehicleMake vehicle);
		 
	}

}
