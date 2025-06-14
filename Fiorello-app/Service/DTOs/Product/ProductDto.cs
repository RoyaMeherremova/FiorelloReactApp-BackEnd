﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int BasketCount { get; set; }

    }
}
