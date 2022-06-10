using System;
using System.Collections.Generic;
using AutoMapper;
using JokesAPP.DAO;
using JokesAPP.Dto;
using JokesAPP.Models;
using JokesAPP.Request;

namespace JokesAPP.Services
{
    public class LoginServices
    {
        public LoginModel Login(string username, string password)
        {
            LoginDAO loginDAO = new LoginDAO();
            var user = loginDAO.GetUser(username, password);
            return user;
        }

        public Int64 Create(LoginModel loginModel)
        {
            LoginDAO logindao = new LoginDAO();

            Int64 inserted = logindao.Create(loginModel);
            return inserted;
        }
        public Boolean GetByEmail(string Email)
        {
            LoginDAO logindao = new LoginDAO();

            Boolean email = logindao.GetBYEmail(Email);
            if (email == true)
            {
                return true;
            }
            else
            {
                return false;

            }

        }
    }

    
}
