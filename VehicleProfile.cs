using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using monoMVC.Models;
using VehicleDTO.Modles;

namespace monoMVC
{
	public class VehicleProfile : Profile
	{
	
		public VehicleProfile()
		{
		
			CreateMap<VehicleMakeView, VehicleMakeEntity>();
			CreateMap<VehicleModelView, VehicleModelEntity>();
			CreateMap<VehicleMakeEntity, VehicleMakeView>();
			CreateMap<VehicleModelEntity, VehicleModelView>();
			
		}
		
	}
}
