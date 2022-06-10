using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace JokesAPP.Request
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateTime { get; set; }
    }
}
