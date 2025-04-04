using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Blog : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BlogComment> BlogComments { get; set; }
        public ICollection<BlogImage> BlogImages { get; set; }
    }
}
