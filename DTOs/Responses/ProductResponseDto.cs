﻿namespace BasicProduct.DTOs.Responses
{
    public class ProductResponseDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
