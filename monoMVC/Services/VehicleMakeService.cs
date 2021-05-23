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
	public class VehicleMakeService : IVehicleMakeService
	{
	
 		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
 		
 		public VehicleMakeService( ApplicationDbContext context, IMapper mapper )
 		{
 			_context = context;
			_mapper = mapper;
 		}
 		
		public async Task<List<VehicleMake>> getVehiclesAsync()
    		{
    			 
    			var res = await _context.VehicleMake.AsNoTracking().Include(s => s.VehicleModel).Select(s => s.MapVehicleMakeResponse()).ToListAsync();
    			 
    			return _mapper.Map<List<VehicleMake>>(res);
    					 
    		}
    		
    		public async Task<VehicleMake> getVehicleByIdAsync(int id)
    		{
		
    			var res = await _context.VehicleMake.AsNoTracking().SingleOrDefaultAsync(v => v.Id==id);			

    			return _mapper.Map<VehicleMake>(res.MapVehicleMakeResponse());
    			
    		}
    		  		
    		public async Task<List<VehicleMake>> getSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int pageSize)
    		{
			var res = new List<VehicleDTO.VehicleMakeResponse>();

			if(!String.IsNullOrEmpty(searchString))
			{
			
				res = await _context.VehicleMake.AsNoTracking().Where(v => v.Name.Contains(searchString)).Select(v => v.MapVehicleMakeResponse()).ToListAsync();
    			 
				return _mapper.Map<List<VehicleMake>>(res);
				
			}
				
    			switch(sortOrder)
    			{
    				case "idDesc":
    					res = await _context.VehicleMake.AsNoTracking().OrderByDescending(v => v.Id).Skip((currentPage-1)*pageSize).Take(pageSize).Select(v => v.MapVehicleMakeResponse()).ToListAsync();
    					break;
    				case "nameDesc":
    					res = await _context.VehicleMake.AsNoTracking().OrderByDescending(v => v.Name).Skip((currentPage-1)*pageSize).Take(pageSize).Select(v => v.MapVehicleMakeResponse()).ToListAsync();
    					break;
    				case "abbrevationDesc":
    					res = await _context.VehicleMake.AsNoTracking().OrderByDescending(v => v.Abbrevation).Skip((currentPage-1)*pageSize).Take(pageSize).Select(v => v.MapVehicleMakeResponse()).ToListAsync();
    					break;
    				default:
    					res = await _context.VehicleMake.AsNoTracking().OrderBy(v => v.Id).Skip((currentPage-1)*pageSize).Take(pageSize).Select(v => v.MapVehicleMakeResponse()).ToListAsync();
    					break;
    				}
    			 
    			return _mapper.Map<List<VehicleMake>>(res);
    		
    		}
    		
    		public int getCount()
    		{
    			return _context.VehicleMake.Count();
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
    		
    		public void removeVehicle(VehicleMake vehicle)
    		{
			try
			{
				_context.VehicleMake.Remove(vehicle);
    			}
			catch(Exception e)
			{
				Console.WriteLine(e);	 
			}
		}
		
    
	}

}
