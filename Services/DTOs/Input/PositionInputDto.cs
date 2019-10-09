using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class PositionInputDto
    {
        [Required]
        public string Name { get; set; }
    }
}