using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using monoMVC.Models;
using VehicleDTO.Models;
using VehicleDTO.Data;

namespace monoMVC.Services
{
	public class VehicleMakeService : IVehicleMakeService
	{
	
 		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
 		
 		public VehicleMakeService(ApplicationDbContext context, IMapper mapper)
 		{
		
 			_context = context;
			_mapper = mapper;
			
 		}
 		
		public async Task<List<VehicleMakeView>> GetVehiclesAsync()
    		{
    			 
    			var entityList = await _context.VehicleMakeEntity.AsNoTracking().Include(s => s.VehicleModelEntity).ToListAsync();
    			 
    			return _mapper.Map<List<VehicleMakeView>>(entityList);
    					 
    		}
    		
    		public async Task<VehicleMakeView> GetVehicleByIdAsync(int id)
    		{
		
    			var entity = await _context.VehicleMakeEntity.AsNoTracking().SingleOrDefaultAsync(v => v.Id==id);			

    			return _mapper.Map<VehicleMakeView>(entity);
    			
    		}
    		  		
    		public async Task<List<VehicleMakeView>> GetSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int pageSize)
    		{
			var entityList = new List<VehicleMakeEntity>();

			if(!String.IsNullOrEmpty(searchString))
			{
			
				entityList = await _context.VehicleMakeEntity.AsNoTracking().Where(v => v.Name.Contains(searchString)).ToListAsync();
    			 
				return _mapper.Map<List<VehicleMakeView>>(entityList);
				
			}
				
    			switch(sortOrder)
    			{
    				case "idDesc":
    					entityList = await _context.VehicleMakeEntity.AsNoTracking().OrderByDescending(v => v.Id).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				case "nameDesc":
    					entityList = await _context.VehicleMakeEntity.AsNoTracking().OrderByDescending(v => v.Name).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				case "abbrevationDesc":
    					entityList = await _context.VehicleMakeEntity.AsNoTracking().OrderByDescending(v => v.Abbrevation).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				default:
    					entityList = await _context.VehicleMakeEntity.AsNoTracking().OrderBy(v => v.Id).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				}
    			 
    			return _mapper.Map<List<VehicleMakeView>>(entityList);
    		
    		}
    		
    		public Task<int> GetCountAsync()
    		{
		
    			return _context.VehicleMakeEntity.CountAsync();
			
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
			
				_context.Add(_mapper.Map<VehicleMakeEntity>(vehicle));
				
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
			
				_context.Update(_mapper.Map<VehicleMakeEntity>(vehicle));
				
			}
			catch(Exception e)
			{
			
				Console.WriteLine(e);
				
			}
    		}
    		
    		public void RemoveVehicle(VehicleMakeView vehicle)
    		{
			try
			{
			
				_context.VehicleMakeEntity.Remove(_mapper.Map<VehicleMakeEntity>(vehicle));
				
    			}
			catch(Exception e)
			{
			
				Console.WriteLine(e);
				
			}
		}
		
    
	}

}
