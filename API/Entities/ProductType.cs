using System.Collections.Generic;

namespace API.Entities
{
    public class ProductType
    {
        public int Id { get; set; }
        public Category Category {get; set;}
        public int CategoryId {get; set;}
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        
    }
}