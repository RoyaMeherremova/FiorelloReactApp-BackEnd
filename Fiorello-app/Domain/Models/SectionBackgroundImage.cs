using Domain.Common;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class SectionBackgroundImage:BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
