using System.Collections.Generic;

namespace API.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Carty> Carties {get; set;}
    }
}