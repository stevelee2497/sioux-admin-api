using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class TimeLineEventInputDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Event { get; set; }
    }
}