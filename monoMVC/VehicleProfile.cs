using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VehicleDTO.Models;

namespace monoMVC
{
	public class VehicleProfile : Profile
	{
		public VehicleProfile()
		{
			CreateMap<VehicleMakeEntity, VehicleMake>();
			CreateMap<VehicleMake, VehicleMakeEntity>();
			CreateMap<VehicleModelEntity, VehicleModel>();
			CreateMap<VehicleModel, VehicleModelEntity>();
		}
	}
}
