using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace JokesAPP.Dto
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
