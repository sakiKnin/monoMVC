using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using monoMVC.Models;
using monoMVC.Data;
using monoMVC.Infrastructure;

namespace monoMVC.Services
{
	public class VehicleModelService : IVehicleModelService
	{
	
 		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
 		
 		public VehicleModelService(ApplicationDbContext context, IMapper mapper)
 		{
 			_context = context;
			_mapper = mapper;
 		}
 		
    		public async Task<List<VehicleModel>> getVehiclesAsync()
    		{
    			
    			var res = await _context.VehicleModel.AsNoTracking().Include(v => v.VehicleMake).Select(v => v.MapVehicleModelResponse()).ToListAsync();
    			 
    			return _mapper.Map<List<VehicleModel>>(res);				 
    		}
    		
    		public async Task<VehicleModel> getVehicleByIdAsync(int id)
    		{
    			var res = await _context.VehicleModel
			    	  	.AsNoTracking()
    					.Include(v => v.VehicleMake)
    					.FirstOrDefaultAsync(v => v.Id == id);
    			
    			return _mapper.Map<VehicleModel>(res.MapVehicleModelResponse());
    		}
    		
    		public async Task<List<VehicleModel>> getVehiclesByNameAsync(string name)
    		{
    			 
    			var res = await _context.VehicleModel.AsNoTracking().Where(v => v.Name.Contains(name)).Select(v => v.MapVehicleModelResponse()).ToListAsync();
    			 
    			return _mapper.Map<List<VehicleModel>>(res);
			
    		}
    		
    		public async Task<List<VehicleModel>> getSortedVehiclesAsync(string sortOrder, int currentPage, int pageSize)
    		{

			var res = new List<VehicleModel>();
    			
    			switch(sortOrder)
    			{
    				case "idDesc":
    					res = _mapper.Map<List<VehicleModel>>(await _context.VehicleModel.AsNoTracking().OrderByDescending(v => v.Id).Skip((currentPage-1)*pageSize).Select(v => v.MapVehicleModelResponse()).ToListAsync());
    					break;
    				case "nameDesc":
    					res = _mapper.Map<List<VehicleModel>>(await _context.VehicleModel.AsNoTracking().OrderByDescending(v => v.Name).Skip((currentPage-1)*pageSize).Select(v => v.MapVehicleModelResponse()).ToListAsync());
    					break;
    				case "abbrevationDesc":
    					res = _mapper.Map<List<VehicleModel>>(await _context.VehicleModel.AsNoTracking().OrderByDescending(v => v.Abbrevation).Skip((currentPage-1)*pageSize).Select(v => v.MapVehicleModelResponse()).ToListAsync());
    					break;
    				default:
    					res = _mapper.Map<List<VehicleModel>>(await _context.VehicleModel.AsNoTracking().OrderBy(v => v.Id).Skip((currentPage-1)*pageSize).Select(v => v.MapVehicleModelResponse()).ToListAsync());
    					break;
    				}
    				
    			return res;
    		
    		}
    		
    		public int getCount(){
    			
    			return _context.VehicleModel.Count();
  
    		}
    		
    		public async Task<List<VehicleMake>> getVehiclesMakeWithoutVModelAsync()
    		{
		
    			var res = await _context.VehicleMake.AsNoTracking().Where(v => v.VehicleModel.Equals(null)).Select(v => v.MapVehicleMakeResponse()).ToListAsync();
    			
    			return _mapper.Map<List<VehicleMake>>(res);
			
    		} 		
    		
    		public async Task saveChangesAsync()
    		{
			try
			{
				await _context.SaveChangesAsync();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
    		}
    		
    		public void addVehicle<T>(T vehicle)
    		{
			try
			{
				_context.Add(vehicle);
			}
			catch(Exception e)
			{
				Console.WriteLine(e);	
			}
			
    		}
    		
    		public void updateVehicle<T>(T vehicle)
    		{
			try
			{
				_context.Update(vehicle);
			}
			catch(Exception e) 
			{
				Console.WriteLine(e);	
			}
    		}
    		
    		public void removeVehicle(VehicleModel vehicle)
    		{
			try
			{
				_context.VehicleModel.Remove(vehicle);
    			}
			catch(Exception e)
			{
				Console.WriteLine(e);	
			}
    		}
    
	}

}
