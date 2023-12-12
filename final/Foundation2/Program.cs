using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Creating Orders...\n");

        Product product1 = new Product("Coral Crown Wig", "P001", 25.00, 2);
        Product product2 = new Product("Seashell Elegance Wig", "P002", 30.00, 1);

        Address address1 = new Address("Underwater Castle", "Atlantica", "Ocean", "Under the Sea");
        Address address2 = new Address("Coral Reef", "Ariel's Grotto", "Ocean", "Under the Sea");

        Customer customer1 = new Customer("King Triton", address1);
        Customer customer2 = new Customer("Ariel", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Ocean Princess Wig", "P003", 35.00, 1));

        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);

        string userInput;
        do
        {
            Console.WriteLine("\nType 'quit' to exit");
            userInput = Console.ReadLine();
        } while (!userInput.ToLower().Equals("quit"));
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.Clear();

        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"\nTotal Price: ${order.CalculateTotalPrice()}");

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double CalculateTotalPrice()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }

    public double GetPrice()
    {
        return price;
    }

    public int GetQuantity()
    {
        return quantity;
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public string GetAllFields()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }

    public string GetStreet()
    {
        return street;
    }

    public string GetCity()
    {
        return city;
    }

    public string GetState()
    {
        return state;
    }

    public string GetCountry()
    {
        return country;
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;

        foreach (Product product in products)
        {
            totalPrice += product.CalculateTotalPrice();
        }

        totalPrice += customer.IsInUSA() ? 5.0 : 35.0;

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";

        foreach (Product product in products)
        {
            packingLabel += $"{product.GetName()} - {product.GetProductId()}\n";
        }

        return packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().GetAllFields()}";
    }
}
