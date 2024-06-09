namespace AdminPanel.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public float Weight { get; set; }
        public DateTime ExpireDate { get; set; }
        public string TypeOfDetention { get; set; }
        public string TypeOfProduct { get; set; }
        public int ShelfId { get; set; }
    }
}
