namespace GraphqlProject.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public Customer customer { get; set; }
        public int amount { get; set; }
        public string Status { get; set; }
        public DateTime Billed_Date { get; set; }
        public DateTime Paid_Date { get; set; }
    }
}
