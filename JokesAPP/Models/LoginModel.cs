using System;

namespace JokesAPP.Models
{
    public class LoginModel
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
