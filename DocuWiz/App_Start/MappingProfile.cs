using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DocuWiz.Dtos;
using DocuWiz.Models;

namespace DocuWiz.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Header, HeaderDto>();
            Mapper.CreateMap<HeaderDto,Header>();
            Mapper.CreateMap<Header,HeaderTypeDto>();


            Mapper.CreateMap<Section, SectionDto>();
            Mapper.CreateMap<SectionDto,Section>();



        }

    }
}