using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using monoMVC.Models;

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

	    int count = _service.getCount();
	    
	    if(count==0)
	    {
		return View();
	    }
	    else
	    {
		
		var veh = await _service.getSortedVehiclesAsync(sortOrder, currentPage ?? 1, pageSize);

		if(!String.IsNullOrEmpty(searchString))
		{
			veh = await _service.getVehiclesByNameAsync(searchString);
	    	}

	        return View(await PaginatedList<VehicleMake>.CreateAsync(veh, count, currentPage ?? 1, pageSize));	
	   }

           
        }
        
        // GET: VehicleMake/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vehicleMake = await _service.getVehicleByIdAsync(id);
            
            return vehicleMake==null ? NotFound() : View(vehicleMake);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Abbrevation")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
	        _service.addVehicle<VehicleMake>(vehicleMake);
		await _service.saveChangesAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleMake);
        }

	// GET: VehicleMake/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleMake = await _service.getVehicleByIdAsync(id);
            
            return vehicleMake==null ? NotFound() : View(vehicleMake);
        }

        	
        // POST: VehicleMake/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abbrevation")] VehicleMake vehicleMake)
        {
            if (id != vehicleMake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
		    _service.updateVehicle<VehicleMake>(vehicleMake);
                    await _service.saveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleMakeExists(vehicleMake.Id))
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
            return View(vehicleMake);
        }
        
        // GET: VehicleMake/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
	
	    var vehicleMake = await _service.getVehicleByIdAsync(id);
           
	    return vehicleMake==null ? NotFound() : View(vehicleMake);

	 }
             
        // POST: VehicleMake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
	    var vehicleMake = await _service.getVehicleByIdAsync(id);
	    _service.removeVehicle(vehicleMake);
	    await _service.saveChangesAsync();
           
            return RedirectToAction(nameof(Index));
        }
	
        private bool VehicleMakeExists(int id)
        {
	    var vehicleMake = _service.getVehicleByIdAsync(id);

	    return vehicleMake==null?false:true;
	    
            //return _context.VehicleMake.Any(e => e.Id == id);
        }
    }
}

