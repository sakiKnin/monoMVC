using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using VehicleDTO.Models;

using monoMVC.Services;

namespace monoMVC.Controllers
{
    public class VehicleMakeController : Controller
    {

	private readonly IVehicleMakeService _service;

        public VehicleMakeController(IVehicleMakeService service)
        {
	
			_service = service;
	    
        }

        // GET: VehicleMake
        public async Task<IActionResult> Index(int pageSize, string sortOrder, string currentFilter, string searchString, int? currentPage)
        {
	
	    ViewData["CurrentSort"] = sortOrder;
	    ViewData["IdSortParam"] = String.IsNullOrEmpty(sortOrder) ? "idDesc": "";
	    ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "nameDesc": "";
	    ViewData["AbbrevationSortParam"] = String.IsNullOrEmpty(sortOrder) ? "abbrevationDesc": "";

	    if(pageSize==0)
	    {
	    
		pageSize=1;
		
	    }
	    
	    ViewData["PageSize"] = pageSize;
	    
	    if (searchString != null)
	    {
	    
		currentPage=1;
		
	    }
	    else
	    {
	    
		searchString=currentFilter;
		
	    }

	    ViewData["CurrentFilter"] = searchString;

	    int count = await _service.GetCountAsync();
	    
	    if(count==0)
	    {
	    
		return View();
		
	    }
	    else
	    {
		
		var veh = await _service.GetSortedVehiclesAsync(sortOrder, searchString, currentPage ?? 1, pageSize);
		
	        return View(await PaginatedList<VehicleMakeEntity>.CreateAsync(veh, count, currentPage ?? 1, pageSize));	
	   }

           
        }
        
        // GET: VehicleMake/Details/5
        public async Task<IActionResult> Details(int id)
        {
	
            var vehicle = await _service.GetVehicleByIdAsync(id);
            
            return vehicle==null ? NotFound() : View(vehicle);
	    
        }
        
        // GET: VehicleMake/Create
	public IActionResult Create()
        {
	
            return View();
	    
        }


        // POST: VehicleMake/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abbrevation")] VehicleMakeEntity vehicle)
        {
	
            if (ModelState.IsValid)
            {
	    
	        _service.AddVehicle<VehicleMakeEntity>(vehicle);
		await _service.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
		
            }
	    
            return View(vehicle);
        }

	// GET: VehicleMake/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
	
            var vehicleMake = await _service.GetVehicleByIdAsync(id);
            
            return vehicleMake==null ? NotFound() : View(vehicleMake);
	    
        }

        	
        // POST: VehicleMake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abbrevation")] VehicleMake vehicle)
        {
            if (id != vehicle.Id)
            {
	    
                return NotFound();
		
            }

            if (ModelState.IsValid)
            {
                try
                {
		
		    _service.UpdateVehicle<VehicleMake>(vehicle);
                    await _service.SaveChangesAsync();
		    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleMakeExists(vehicle.Id))
                    {
		    
                        return NotFound();
			
                    }
                    else
                    {
		    
                        throw;
			
                    }
                }
		
                return RedirectToAction(nameof(Index));
		
            }
	    
            return View(vehicle);
        }
        
        // GET: VehicleMake/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
	
	    var vehicleMake = await _service.GetVehicleByIdAsync(id);
           
	    return vehicleMake==null ? NotFound() : View(vehicleMake);

	 }
             
        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
	
	    var vehicle = await _service.GetVehicleByIdAsync(id);
	    _service.RemoveVehicle(vehicle);
	    await _service.SaveChangesAsync();
           
            return RedirectToAction(nameof(Index));
	    
        }
	
        private bool VehicleMakeExists(int id)
        {
	
	    var vehicle = _service.GetVehicleByIdAsync(id);

	    return vehicle==null?false:true;
	    
            //return _context.VehicleMake.Any(e => e.Id == id);
        }
    }
}

