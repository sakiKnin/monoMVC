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
	public class VehicleModelService : IVehicleModelService
	{
	
 		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
 		
 		public VehicleModelService(ApplicationDbContext context, IMapper mapper)
 		{
		
 			_context = context;
			_mapper = mapper;
			
 		}
 		
    		public async Task<List<VehicleModelView>> GetVehiclesAsync()
    		{
    			
    			var entityList = await _context.VehicleModelEntity.AsNoTracking().Include(v => v.VehicleMakeEntity).ToListAsync();
    			 
    			return _mapper.Map<List<VehicleModelView>>(entityList);				 
    		}
    		
    		public async Task<VehicleModelView> GetVehicleByIdAsync(int id)
    		{
    			var entity = await _context.VehicleModelEntity
			    	  	.AsNoTracking()
    					.Include(v => v.VehicleMakeEntity)
    					.FirstOrDefaultAsync(v => v.Id == id);
    			
    			return _mapper.Map<VehicleModelView>(entity);
    		}
    		
    		public async Task<List<VehicleModelView>> GetSortedVehiclesAsync(string sortOrder, string searchString, int currentPage, int pageSize)
    		{

			var entityList = new List<VehicleModelEntity>();

			if(!String.IsNullOrEmpty(searchString))
			{

				entityList = await _context.VehicleModelEntity.AsNoTracking().Where(v => v.Name.Contains(searchString)).ToListAsync();
    			 
				return _mapper.Map<List<VehicleModelView>>(entityList);

			}
    			
    			switch(sortOrder)
    			{
    				case "idDesc":
    					entityList = await _context.VehicleModelEntity.AsNoTracking().OrderByDescending(v => v.Id).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				case "nameDesc":
    					entityList = await _context.VehicleModelEntity.AsNoTracking().OrderByDescending(v => v.Name).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				case "abbrevationDesc":
    					entityList = await _context.VehicleModelEntity.AsNoTracking().OrderByDescending(v => v.Abbrevation).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				default:
    					entityList = await _context.VehicleModelEntity.AsNoTracking().OrderBy(v => v.Id).Skip((currentPage-1)*pageSize).Take(pageSize).ToListAsync();
    					break;
    				}
    				
    			return _mapper.Map<List<VehicleModelView>>(entityList);
    		
    		}
    		
    		public async Task<int> GetCountAsync()
		{
    			
    			return await _context.VehicleModelEntity.CountAsync();
  
    		}
    		
    		public async Task<List<VehicleMakeView>> GetVehiclesMakeWithoutVModelAsync()
    		{
		
    			var entityList = await _context.VehicleMakeEntity.AsNoTracking().Where(v => v.VehicleModelEntity.Equals(null)).ToListAsync();
    			
    			return _mapper.Map<List<VehicleMakeView>>(entityList);
			
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
    		
    		public void AddVehicle(VehicleModelView vehicle)
    		{
		
			try
			{
			
				_context.Add(_mapper.Map<VehicleModelEntity>(vehicle));
				
			}
			catch(Exception e)
			{
			
				Console.WriteLine(e);
				
			}
			
    		}
    		
    		public void UpdateVehicle<T>(VehicleModelView vehicle)
    		{
			try
			{
			
				_context.Update(_mapper.Map<VehicleModelEntity>(vehicle));
				
			}
			catch(Exception e)
			{
			
				Console.WriteLine(e);
				
			}

	
    		}
    		
    		public void RemoveVehicle<T>(VehicleModelView vehicle)
    		{
			
			try
			{
			
				_context.VehicleModelEntity.Remove(_mapper.Map<VehicleModelEntity>(vehicle));
				
    			}
			catch(Exception e)
			{
			
				Console.WriteLine(e);
				
			}

    		}
    
	}

}
