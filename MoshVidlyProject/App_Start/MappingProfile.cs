using AutoMapper;
using MoshVidlyProject.Dto;
using MoshVidlyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoshVidlyProject.App_Start
{
    //AutoMapper is convention base mapping tool
    public class MappingProfile: Profile 
    {
        public MappingProfile()
        {   // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MemberShipType, MembershipTypeDto>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<Genre, GenreDto>();

            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
       
    }
}