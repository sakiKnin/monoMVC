using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using monoMVC.Models;
using VehicleDTO.Models;

namespace monoMVC
{
	public class VehicleProfile : Profile
	{
		public VehicleProfile()
		{
			CreateMap<VehicleMakeEntity, VehicleMakeView>();
			CreateMap<VehicleMakeView, VehicleMakeEntity>();
			CreateMap<VehicleModelEntity, VehicleModelView>();
			CreateMap<VehicleModelView, VehicleModelEntity>();
		}
	}
}
