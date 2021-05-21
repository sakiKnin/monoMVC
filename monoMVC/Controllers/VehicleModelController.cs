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
	    var applicationDbContext = _service.getVehiclesAsync();
            return View(await applicationDbContext);
        }

        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var vehicleModel = await _service.getVehicleByIdAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public async Task<IActionResult> Create()
        {
	    ViewData["MakeId"] = new SelectList(await _service.getVehiclesMakeWithoutVModelAsync<VehicleMake>(), "Id", "Name");
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MakeId,Name,Abbrevation")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                _service.addVehicle<VehicleModel>(vehicleModel);
                await _service.saveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
	   
            return View(vehicleModel);
        }

        // GET: VehicleModel/Edit/5
        public async Task<IActionResult> Edit(int id)
        {  
            var vehicleModel = await _service.getVehicleByIdAsync(id);

	    if (vehicleModel == null)
            {
                return NotFound();
            }
	    ViewData["MakeId"] = vehicleModel.MakeId;
            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MakeId,Name,Abbrevation")] VehicleModel vehicleModel)
        {
            if (id != vehicleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _service.updateVehicle<VehicleModel>(vehicleModel);
                   await _service.saveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModel.Id))
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
	    
            return View(vehicleModel);
        }

        // GET: VehicleModel/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var vehicleModel = await _service.getVehicleByIdAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModel = await _service.getVehicleByIdAsync(id);
            _service.removeVehicle(vehicleModel);
            await _service.saveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
	    if(_service.getVehicleByIdAsync(id)==null)
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


    