using System.Data.SqlTypes;

namespace BasicProduct
{
    public class Product
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public SqlMoney Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
