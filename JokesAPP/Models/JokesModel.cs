using System;
namespace JokesAPP.Models
{
    public class JokesModel
    {
        public int JokesID { get; set; }
        public string JokesQuestion { get; set; }
        public string JokesAnswer { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
