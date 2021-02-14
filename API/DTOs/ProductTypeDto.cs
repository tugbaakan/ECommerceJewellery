using System.Collections.Generic;

namespace API.DTOs
{
    public class ProductTypeDto
    {
        public int Id { get; set; }
        public int CategoryId {get; set;}
        public string Name { get; set; }
        public ICollection<ProductDto> Products { get; set; }
    }
}