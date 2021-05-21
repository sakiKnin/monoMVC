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
	public class VehicleMakeService : IVehicleMakeService
	{
	
 		private readonly ApplicationDbContext _context;
 		
 		public VehicleMakeService(ApplicationDbContext context)
 		{
 			_context = context;
 		}
 		
		public async Task<List<VehicleMake>> getVehiclesAsync()
    		{
    			List<VehicleMake> response = new List<VehicleMake>();
    			 
    			var res = await _context.VehicleMake.AsNoTracking().ToListAsync();
    			response = (List<VehicleMake>)Convert.ChangeType(res, typeof(List<VehicleMake>));	 
    
    			return response;
    					 
    		}
    		
    		public async Task<VehicleMake> getVehicleByIdAsync(int id)
    		{
    			var res = await _context.VehicleMake.FindAsync(id);
    			
    			return (VehicleMake)Convert.ChangeType(res, typeof(VehicleMake));
    			
    		}
    		 
    		public async Task<List<VehicleMake>> getVehiclesByNameAsync(string name)
    		{
    			 
    			var res = await _context.VehicleMake.Where(v => v.Name.Contains(name)).ToListAsync();
    			 
    			return (List<VehicleMake>)Convert.ChangeType(res, typeof(List<VehicleMake>));
    		}
    		
    		public async Task<List<VehicleMake>> getSortedVehiclesAsync(string sortOrder, int currentPage, int pageSize)
    		{
    			List<VehicleMake> response = new List<VehicleMake>();
    			
    			var res = new List<VehicleMake>();
    				
    			switch(sortOrder)
    			{
    				case "idDesc":
    					res = await _context.VehicleMake.OrderByDescending(v => v.Id).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				case "nameDesc":
    					res = await _context.VehicleMake.OrderByDescending(v => v.Name).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				case "abbrevationDesc":
    					res = await _context.VehicleMake.OrderByDescending(v => v.Abbrevation).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				default:
    					res = await _context.VehicleMake.OrderBy(v => v.Id).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				}
    				
    			response = (List<VehicleMake>)Convert.ChangeType(res, typeof(List<VehicleMake>));
    			 
    			return response;
    		
    		}
    		
    		public int getCount()
    		{
    			return _context.VehicleMake.Count();
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
    		
    		public void removeVehicle(VehicleMake vehicle)
    		{
    			 _context.VehicleMake.Remove((VehicleMake)Convert.ChangeType(vehicle,typeof(VehicleMake)));	 
    		}    		 
    
	}

}
