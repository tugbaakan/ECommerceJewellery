namespace API.Entities
{
    public class Carty
    {
        /* this class represent every item in the cart with its quantity*/
        public int Id { get; set; }
        public int CartId {get; set;}
        public int ProductId {get; set;}
        public int Quantity {get; set;}
    }
}