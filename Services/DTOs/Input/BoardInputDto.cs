using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class BoardInputDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<string> PhaseOrder { get; set; }
    }
}