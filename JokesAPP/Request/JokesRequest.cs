using System;
namespace JokesAPP.Request
{
    public class JokesRequest
    {
        public int JokesID { get; set; }
        public string JokesQuestion { get; set; }
        public int JokesPosted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
