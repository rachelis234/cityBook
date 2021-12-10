using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Conversions
    {
        private static MapperConfiguration MapperConfiguration = new MapperConfiguration((cfg) =>
        {
            cfg.CreateMap<ActivatingsForRide, ActivatingForRideDTO>();
            cfg.CreateMap<ActivatingForRideDTO, ActivatingsForRide>();

            cfg.CreateMap<CreditDetail, CreditDetailDTO>();
            cfg.CreateMap<CreditDetailDTO, CreditDetail>();

            cfg.CreateMap<Grading, GradingDTO>();
            cfg.CreateMap<GradingDTO, Grading>();

            cfg.CreateMap<Ride, RideDTO>();
            cfg.CreateMap<RideDTO, Ride>();

            cfg.CreateMap<RideForUser, RideForUserDTO>();
            cfg.CreateMap<RideForUserDTO, RideForUser>();

            cfg.CreateMap<Trip, TripDTO>();
            cfg.CreateMap<TripDTO, Trip>();

            cfg.CreateMap<User, UserDTO>();
            cfg.CreateMap<UserDTO, User>();
        });
        private static Mapper Mapper { get; set; } = new Mapper(MapperConfiguration);
        //public static Mapper Mapper()
        //{
        //    var config = new MapperConfiguration(
        //        (cfg) =>
        //        {
        //            cfg.CreateMap<ActivatingsForRide, ActivatingForRideDTO>();
        //            cfg.CreateMap<ActivatingForRideDTO, ActivatingsForRide>();

        //            cfg.CreateMap<CreditDetail, CreditDetailDTO>();
        //            cfg.CreateMap<CreditDetailDTO, CreditDetail>();

        //            cfg.CreateMap<Grading, GradingDTO>();
        //            cfg.CreateMap<GradingDTO, Grading>();

        //            cfg.CreateMap<Ride, RideDTO>();
        //            cfg.CreateMap<RideDTO, Ride>();

        //            cfg.CreateMap<RideForUser, RideForUserDTO>();
        //            cfg.CreateMap<RideForUserDTO, RideForUser>();

        //            cfg.CreateMap<Trip, TripDTO>();
        //            cfg.CreateMap<TripDTO, Trip>();

        //            cfg.CreateMap<User, UserDTO>();
        //            cfg.CreateMap<UserDTO, User>();
        //        });
        //    Mapper mapper = new Mapper(config);
        //    return mapper;
        //}


        public static ActivatingForRideDTO Map(ActivatingsForRide entity)
        {
            var converted = Mapper.Map<ActivatingForRideDTO>(entity);
            return converted;
        }

        public static ActivatingsForRide Map(ActivatingForRideDTO entity)
        {
            var converted = Mapper.Map<ActivatingsForRide>(entity);
            return converted;
        }

        public static CreditDetailDTO Map(CreditDetail entity)
        {
            var converted = Mapper.Map<CreditDetailDTO>(entity);
            return converted;
        }

        public static CreditDetail Map(CreditDetailDTO entity)
        {
            var converted = Mapper.Map<CreditDetail>(entity);
            return converted;
        }

        public static GradingDTO Map(Grading entity)
        {
            var converted = Mapper.Map<GradingDTO>(entity);
            return converted;
        }

        public static Grading Map(GradingDTO entity)
        {
            var converted = Mapper.Map<Grading>(entity);
            return converted;
        }

        public static RideDTO Map(Ride entity)
        {
            var converted = Mapper.Map<RideDTO>(entity);
            return converted;
        }

        public static Ride Map(RideDTO entity)
        {
            var converted = Mapper.Map<Ride>(entity);
            return converted;
        }

        public static RideForUserDTO Map(RideForUser entity)
        {
            var converted = Mapper.Map<RideForUserDTO>(entity);
            return converted;
        }

        public static RideForUser Map(RideForUserDTO entity)
        {
            var converted = Mapper.Map<RideForUser>(entity);
            return converted;
        }

        public static TripDTO Map(Trip entity)
        {
            var converted = Mapper.Map<TripDTO>(entity);
            return converted;
        }

        public static Trip Map(TripDTO entity)
        {
            var converted = Mapper.Map<Trip>(entity);
            return converted;
        }

        public static UserDTO Map(User entity)
        {
            var converted = Mapper.Map<UserDTO>(entity);
            return converted;
        }

        public static User Map(UserDTO entity)
        {
            var converted = Mapper.Map<User>(entity);
            return converted;
        }
    }
}
