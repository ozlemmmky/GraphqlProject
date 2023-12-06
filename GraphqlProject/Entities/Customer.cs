namespace GraphqlProject.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Address { get; set; } 
        public string City { get; set; }
        public string State { get; set; }
        public string Postal_Code { get; set; }
        public int MyProperty { get; set; }
    }
}
