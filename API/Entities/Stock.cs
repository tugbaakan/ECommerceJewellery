namespace API.Entities
{
    public class Stock
    {
        public int Id {get;set;}
        public Product Product {get; set;}
        public int ProductId {get; set;}
        public int StockQuantity {get; set;}

    }
}