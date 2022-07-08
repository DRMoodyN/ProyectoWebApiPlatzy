using System;
using Repository.DTO;
using AutoMapper;
using Models.Entities;

namespace Repository
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Business, BusinessDTO>().ReverseMap();
            CreateMap<CtgAccount, CtgAccountDTO>().ReverseMap();
        }
    }
}
