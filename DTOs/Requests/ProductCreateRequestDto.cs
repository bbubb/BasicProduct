namespace BasicProduct.DTOs.Requests
{
    public class ProductCreateRequestDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
