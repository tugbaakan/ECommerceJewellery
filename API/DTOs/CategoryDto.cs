using System.Collections.Generic;

namespace API.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductTypeDto> ProductTypes {get; set;}
    }
}