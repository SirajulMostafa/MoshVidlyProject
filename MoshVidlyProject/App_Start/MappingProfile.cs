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
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();  
        }
       
    }
}