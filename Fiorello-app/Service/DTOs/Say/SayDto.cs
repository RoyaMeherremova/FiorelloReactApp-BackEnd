using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Say
{
    public class SayDto
    {
        public string Image { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Position { get; set; }
    }
}
