using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using monoMVC.Models;

namespace monoMVC
{
	public class VehicleProfile : Profile
	{
		public VehicleProfile()
		{
			CreateMap<VehicleDTO.Models.VehicleMakeResponse, VehicleDTO.Models.VehicleMake>();
			CreateMap<VehicleDTO.Models.VehicleModelResponse, VehicleDTO.Models.VehicleModel>();
		}
	}
}
