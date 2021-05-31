using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using VehicleDTO.Models;
using VehicleDTO.Data;
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
 		
    		public async Task<List<VehicleModel>> GetVehiclesAsync()
    		{
    			
    			var res = await _context.VehicleModel.AsNoTracking().Include(v => v.VehicleMake).Select(v => v.MapVehicleModelResponse()).ToListAsync();
    			 
    			return _mapper.Map<List<VehicleModel>>(res);				 
    		}
    		
    		public async Task<VehicleModel> GetVehicleByIdAsync(int id)
    		{
    			var res = await _context.VehicleModel
			    	  	.AsNoTracking()
    					.Include(v => v.VehicleMake)
    					.FirstOrDefaultAsync(v => v.Id == id);
    			
    			return _mapper.Map<VehicleModel>(res.MapVehicleModelResponse());
    		}
    		
    		public async Task<List<VehicleModel>> GetSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int pageSize)
    		{

			var res = new List<VehicleModelResponse>();

			if(!String.IsNullOrEmpty(searchString))
			{

				res = await _context.VehicleModel.AsNoTracking().Where(v => v.Name.Contains(searchString)).Select(v => v.MapVehicleModelResponse()).ToListAsync();
    			 
				return _mapper.Map<List<VehicleModel>>(res);

			}
    			
    			switch(sortOrder)
    			{
    				case "idDesc":
    					res = await _context.VehicleModel.AsNoTracking().OrderByDescending(v => v.Id).Skip((currentPage-1)*pageSize).Select(v => v.MapVehicleModelResponse()).ToListAsync();
    					break;
    				case "nameDesc":
    					res = await _context.VehicleModel.AsNoTracking().OrderByDescending(v => v.Name).Skip((currentPage-1)*pageSize).Select(v => v.MapVehicleModelResponse()).ToListAsync();
    					break;
    				case "abbrevationDesc":
    					res = await _context.VehicleModel.AsNoTracking().OrderByDescending(v => v.Abbrevation).Skip((currentPage-1)*pageSize).Select(v => v.MapVehicleModelResponse()).ToListAsync();
    					break;
    				default:
    					res = await _context.VehicleModel.AsNoTracking().OrderBy(v => v.Id).Skip((currentPage-1)*pageSize).Select(v => v.MapVehicleModelResponse()).ToListAsync();
    					break;
    				}
    				
    			return _mapper.Map<List<VehicleModel>>(res);
    		
    		}
    		
    		public async Task<int> GetCountAsync(){
    			
    			return await _context.VehicleModel.CountAsync();
  
    		}
    		
    		public async Task<List<VehicleMake>> GetVehiclesMakeWithoutVModelAsync()
    		{
		
    			var res = await _context.VehicleMake.AsNoTracking().Where(v => v.VehicleModel.Equals(null)).Select(v => v.MapVehicleMakeResponse()).ToListAsync();
    			
    			return _mapper.Map<List<VehicleMake>>(res);
			
    		} 		
    		
    		public async Task SaveChangesAsync()
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
    		
    		public void AddVehicle<T>(T vehicle)
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
    		
    		public void UpdateVehicle<T>(T vehicle)
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
    		
    		public void RemoveVehicle(VehicleModel vehicle)
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
