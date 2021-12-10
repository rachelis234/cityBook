using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Resources;
using WeatherCore.Models;

namespace WeatherAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<User, UserResource>();

            // Resource to Domain
            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
