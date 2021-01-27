using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public CartyDto CartyLast  { get; set; }
        public List<CartyDto> Carties {get; set;}
    }
}