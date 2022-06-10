using System;
using AutoMapper;
using JokesAPP.Dto;
using JokesAPP.Models;
using JokesAPP.Request;

namespace JokesAPP.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() 
        {
            CreateMap<LoginDto, LoginModel>();
            CreateMap<LoginDto, LoginRequest>();
            CreateMap<LoginModel, LoginDto>();
            CreateMap<JokesModel, JokesDto>();
            CreateMap<JokesDto, JokesRequest>();
            CreateMap<JokesRequest, JokesModel>();

        }
    }
}
