using System;
namespace JokesAPP.Dto
{
    public class JokesDto
    {
        public int JokesID { get; set; }
        public string JokesQuestion { get; set; }
        public string JokesAnswer { get; set; }
        public int JokesPosted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
