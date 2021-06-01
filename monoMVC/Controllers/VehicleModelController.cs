using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleDTO.Data;
using VehicleDTO.Models;
using monoMVC.Services;

namespace monoMVC.Controllers
{
    public class VehicleModelController : Controller
    {

	private readonly IVehicleModelService _service;

	public VehicleModelController(IVehicleModelService service){

	       		    _service = service;

	}

        // GET: VehicleModel
        public async Task<IActionResult> Index()
        {
	
		var vehicles = await _service.GetVehiclesAsync();

		return View(vehicles);
	    
        }

        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int id)
        {
           return View();
        }

        // GET: VehicleModel/Create
        public async Task<IActionResult> Create()
        {
	

            return View();
	    
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MakeId,Name,Abbrevation")] VehicleModel vehicle)
        {
          
            return View();
        }

        // GET: VehicleModel/Edit/5
        public async Task<IActionResult> Edit(int id)
        {  
         
            return View();
	    
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MakeId,Name,Abbrevation")] VehicleModel vehicle)
        {
            
            return View();
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          
            return RedirectToAction(nameof(Index));
        }

      
    }
}


    