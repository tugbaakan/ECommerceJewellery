using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Carty
    {
        /* this class represent every item in the cart with its quantity*/
        public int Id { get; set; }
        // fully defining the relationship
        public Cart Cart {get;set;}
        public int CartId {get; set;}
        public Product Product {get;set;}
        public int ProductId {get; set;}
        public int Quantity {get; set;}
 
    }
}