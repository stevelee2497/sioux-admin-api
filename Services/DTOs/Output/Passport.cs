using DAL.Models;

namespace Services.DTOs.Output
{
    public class Passport
    {
        public string Token { get; set; }

        public ProfileDto Profile { get; set; }
    }
}