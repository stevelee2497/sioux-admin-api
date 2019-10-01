using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class SkillInputDto
    {
        [Required]
        public string Name { get; set; }
    }
}