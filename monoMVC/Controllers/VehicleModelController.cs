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
    public class VehicleModelController : Controller
    {
      
	private readonly IVehicleModelService _service;

        public VehicleModelController(IVehicleModelService service)
        {
	
			_service = service;
			
        }

        // GET: VehicleModel
        public async Task<IActionResult> Index()
        {
	
	    var vehicles  = await _service.GetVehiclesAsync();
	    
            return View(vehicles);
	    
        }

        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int id)
        {
	
            var vehicle = await _service.GetVehicleByIdAsync(id);
	    
            if (vehicle == null)
            {
	    
                return NotFound();
		
            }

            return View(vehicle);
	    
        }

        // GET: VehicleModel/Create
        public async Task<IActionResult> Create()
        {
	
	    ViewData["MakeId"] = new SelectList(await _service.GetVehiclesMakeWithoutVModelAsync(), "Id", "Name");
            return View();
	    
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MakeId,Name,Abbrevation")] VehicleModelView vehicle)
        {
	
            if (ModelState.IsValid)
            {
	    
		_service.AddVehicle(vehicle);
		await _service.SaveChangesAsync();
               
                return RedirectToAction(nameof(Index));
		
            }
	   
            return View(vehicle);
	    
        }

        // GET: VehicleModel/Edit/5
        public async Task<IActionResult> Edit(int id)
        {  
            var vehicle = await _service.GetVehicleByIdAsync(id);

	    if (vehicle == null)
            {
	    
                return NotFound();
		
            }
	    
	    ViewData["MakeId"] = vehicle.MakeId;
	    
            return View(vehicle);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MakeId,Name,Abbrevation")] VehicleModelView vehicle)
        {
            if (id != vehicle.Id)
            {
	    
                return NotFound();
		
            }

            if (ModelState.IsValid)
            {
                try
                {
		
                    _service.UpdateVehicle<VehicleModelView>(vehicle);
		    await _service.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicle.Id))
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

        // GET: VehicleModel/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var vehicle = await _service.GetVehicleByIdAsync(id);
	    
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

	    var vehicle = await _service.GetVehicleByIdAsync(id);
            
            _service.RemoveVehicle<VehicleModelView>(vehicle);

	    await _service.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
	    if(_service.GetVehicleByIdAsync(id)==null)
	    {
	    
				return true;
				
	    }
	    else
	    {
	    
				return false;
				
	    }
        }
    }
}
