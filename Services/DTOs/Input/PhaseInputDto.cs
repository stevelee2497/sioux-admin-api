using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.DTOs.Input
{
    public class PhaseInputDto
    {
        public string Id { get; set; }

        [Required]
        public string BoardId { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<string> TaskOrder { get; set; }
    }
}