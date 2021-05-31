using monoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VehicleDTO.Models;

namespace monoMVC.Infrastructure
{
    public static class EntityExtensions
    {
        public static VehicleMakeResponse MapVehicleMakeResponse(this VehicleMake vehicleMake) =>
            new VehicleMakeResponse
            {
                Id = vehicleMake.Id,
                Name = vehicleMake.Name,
                Abbrevation = vehicleMake.Abbrevation,
		VehicleModel = vehicleMake.VehicleModel
            };
	public static VehicleModelResponse MapVehicleModelResponse(this VehicleModel vehicleModel) =>
            new VehicleModelResponse
            {
                Id = vehicleModel.Id,
		MakeId = vehicleModel.MakeId,
                Name = vehicleModel.Name,
                Abbrevation = vehicleModel.Abbrevation,
		VehicleMake = vehicleModel.VehicleMake
            };
     }
}
