using System.Collections.Generic;

namespace Services.DTOs.Output
{
    public class BoardOutputDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<string> PhaseOrder { get; set; }

        public IEnumerable<BoardUserOutputDto> Users { get; set; }
    }   
}