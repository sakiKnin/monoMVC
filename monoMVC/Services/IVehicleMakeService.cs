using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VehicleDTO.Models;

namespace monoMVC.Services{

	public interface IVehicleMakeService
	{
	
		Task<List<VehicleMake>> GetVehiclesAsync();
		Task<VehicleMake> GetVehicleByIdAsync(int id);
		Task<List<VehicleMake>> GetSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int PageSize);
		Task<int> GetCountAsync();
		Task SaveChangesAsync();
		void AddVehicle<T>(T vehicle);
		void UpdateVehicle<T>(T vehicle);
		void RemoveVehicle(VehicleMake vehicle);
		 
	}

}
