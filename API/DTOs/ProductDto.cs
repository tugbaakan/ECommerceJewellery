namespace API.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int ProductTypeId {get; set;}
        public int SellerId {get; set;}
        public string Name { get; set; }
        public int Quantity {get; set;}
    }
}