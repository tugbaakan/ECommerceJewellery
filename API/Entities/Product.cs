namespace API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public ProductType ProductType {get; set;}
        public int ProductTypeId {get; set;}
        public Seller Seller {get; set;}
        public int SellerId {get; set;}
        public string Name { get; set; }
        public int Quantity {get; set;}
        
    }
}