using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public List<Carty> Carties {get; set;}
    }
}