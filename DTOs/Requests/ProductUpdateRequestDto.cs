namespace BasicProduct.DTOs.Requests
{
    public class ProductUpdateRequestDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
