using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using JokesAPP.Dto;
using JokesAPP.Models;
using JokesAPP.Request;
using JokesAPP.Services;


namespace JokesAPP.Controllers
{
    public class LoginController : Controller
    {
        public readonly IMapper _mapper;

        public LoginController(IMapper mapper)
        {
            _mapper = mapper;

        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/login")]
        [HttpGet]
        public LoginModel Login(string email, string password)
        {
            LoginServices loginService = new LoginServices();
            var user = loginService.Login(email, password);
            return user;
        }
        [Route("/new")]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View("./CreateUser");
        }
        [Route("/usercreate")]
        [HttpPost]
        public Int64 Post(LoginDto loginDto)
        {
            LoginServices userService = new LoginServices();
            var dto = new LoginDto
            {
                CreatedAt = DateTime.Now,
                Email = loginDto.Email,
                Password = loginDto.Password

            };
            var req = _mapper.Map<LoginModel>(dto);
            Boolean emailExist = userService.GetByEmail(loginDto.Email);
            if (emailExist == true)
            {
                return 0;
            }
            Int64 Inserted = userService.Create(req);
            return Inserted;
        }
    }
}

