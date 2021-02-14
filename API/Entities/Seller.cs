using System.Collections.Generic;

namespace API.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public string Name {get; set;}
        public string City {get; set;}
        public ICollection<Product> Products {get; set;}
    }
}