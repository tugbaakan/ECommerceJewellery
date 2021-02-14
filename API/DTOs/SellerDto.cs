using System.Collections.Generic;

namespace API.DTOs
{
    public class SellerDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name {get; set;}
        public string City {get; set;}
        public ICollection<ProductDto> Products {get; set;}
    }
}