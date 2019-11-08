namespace Services.DTOs.Output
{
    public class Passport
    {
        public string Token { get; set; }

        public UserOutputDto Profile { get; set; }
    }
}