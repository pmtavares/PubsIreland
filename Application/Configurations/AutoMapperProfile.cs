using Application.Dtos;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<Pub, PubDto>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name));

            CreateMap<Pub, PubDtoForCreation>().ReverseMap();
 


        }
        
    }
}
