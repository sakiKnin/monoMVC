using monoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace monoMVC.Infrastructure
{
    public static class EntityExtensions
    {
        public static VehicleDTO.VehicleMakeResponse MapVehicleMakeResponse(this VehicleMake vehicleMake) =>
            new VehicleDTO.VehicleMakeResponse
            {
                Id = vehicleMake.Id,
                Name = vehicleMake.Name,
                Abbrevation = vehicleMake.Abbrevation,
		VehicleModel = vehicleMake.VehicleModel
            };
	public static VehicleDTO.VehicleModelResponse MapVehicleModelResponse(this VehicleModel vehicleModel) =>
            new VehicleDTO.VehicleModelResponse
            {
                Id = vehicleModel.Id,
		MakeId = vehicleModel.MakeId,
                Name = vehicleModel.Name,
                Abbrevation = vehicleModel.Abbrevation,
		VehicleMake = vehicleModel.VehicleMake
            };
     }
}
