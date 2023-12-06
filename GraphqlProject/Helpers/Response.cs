

public class Response
{
    public List<Customer> Customers { get; set; }
}

public class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public IEnumerable<Product> Products { get; set; }
}

public class Product
{
    public string Id { get; set; }
    public int Amount { get; set; }
    public string Status { get; set; }
    public DateTime BilledDate { get; set; }
    public DateTime PaidDate { get; set; }
}
