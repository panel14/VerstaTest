namespace OrderTest.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string SenderCity { get; set; } = null!;
        public string SenderAddress { get; set; } = null!;
        public string RecipientCity { get; set; } = null!;
        public string RecipientAddress { get; set; } = null!;
        public double Weight { get; set; }
        public DateTime PickUpDate { get; set; }
    }
}
