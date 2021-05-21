using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using monoMVC.Models;
using monoMVC.Data;

namespace monoMVC.Services
{
	public class VehicleModelService : IVehicleModelService
	{
	
 		private readonly ApplicationDbContext _context;
 		
 		public VehicleModelService(ApplicationDbContext context)
 		{
 			_context = context;
 		}
 		
    		public async Task<List<VehicleModel>> getVehiclesAsync()
    		{
    			List<VehicleModel> response = new List<VehicleModel>();
	 
    			var res = await _context.VehicleModel.Include(v => v.VehicleMake).ToListAsync();
    			 
    			return (List<VehicleModel>)Convert.ChangeType(res, typeof(List<VehicleModel>));
    					 
    		}
    		
    		public async Task<VehicleModel> getVehicleByIdAsync(int id)
    		{
    			var res = await _context.VehicleModel
    					.Include(v => v.VehicleMake)
    					.FirstOrDefaultAsync(m => m.Id == id);
    			
    			return (VehicleModel)Convert.ChangeType(res, typeof(VehicleModel));
    		}
    		
    		public async Task<List<VehicleModel>> getVehiclesByNameAsync(string name)
    		{
    			 
    			var res = await _context.VehicleModel.Where(v => v.Name.Contains(name)).ToListAsync();
    			 
    			return (List<VehicleModel>)Convert.ChangeType(res, typeof(List<VehicleModel>));
    		}
    		
    		public async Task<List<VehicleModel>> getSortedVehiclesAsync(string sortOrder, int currentPage, int pageSize)
    		{
    			List<VehicleModel> response = new List<VehicleModel>();
    			
    			var res = new List<VehicleModel>();
    			
    			switch(sortOrder)
    			{
    				case "idDesc":
    					res = await _context.VehicleModel.OrderByDescending(v => v.Id).Skip((currentPage-1)*pageSize).ToListAsync();
    					break;
    				case "nameDesc":
    					res = await _context.VehicleModel.OrderByDescending(v => v.Name).Skip((currentPage-1)*pageSize).ToListAsync();
    					break;
    				case "abbrevationDesc":
    					res = await _context.VehicleModel.OrderByDescending(v => v.Abbrevation).Skip((currentPage-1)*pageSize).ToListAsync();
    					break;
    				default:
    					res = await _context.VehicleModel.OrderBy(v => v.Id).Skip((currentPage-1)*pageSize).ToListAsync();
    					break;
    				}
    				
    			response = (List<VehicleModel>)Convert.ChangeType(res, typeof(List<VehicleModel>));
    			 
    			return response;
    		
    		}
    		
    		public int getCount(){
    			
    			return _context.VehicleModel.Count();
  
    		}
    		
    		public async Task<List<T>> getVehiclesMakeWithoutVModelAsync<T>()
    		{
    			var res = await _context.VehicleMake.Where(v => v.VehicleModel.Equals(null)).ToListAsync();
    			
    			return (List<T>)Convert.ChangeType(res, typeof(List<T>));
    		} 		
    		
    		public async Task saveChangesAsync()
    		{
    			await _context.SaveChangesAsync();
    		}
    		
    		public void addVehicle<T>(T vehicle)
    		{
    			_context.Add(vehicle);
    		}
    		
    		public void updateVehicle<T>(T vehicle)
    		{
    			_context.Update(vehicle);
    		}
    		
    		public void removeVehicle(VehicleModel vehicle)
    		{
    			 _context.VehicleModel.Remove((VehicleModel)Convert.ChangeType(vehicle,typeof(VehicleModel)));
    			 
    		}
    
	}

}
