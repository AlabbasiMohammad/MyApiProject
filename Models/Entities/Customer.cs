using MongoDB.Bson.Serialization.Attributes;

namespace MyApiProject.Models.Entities
{
    public class Customer
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("_customerName"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? CustomerName { get; set; }
                        
        [BsonElement("_email"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string? Email { get; set; }
        // public string PhoneNumber { get; set; }
        // public DateTime CreatedAt { get; set; }
        // public DateTime UpdatedAt { get; set; }

        // Navigation properties
        // public virtual ICollection<Order> Orders { get; set; }
    }
    // public class Order
    // {
    //     public int Id { get; set; }
    //     public int CustomerId { get; set; }
    //     public DateTime OrderDate { get; set; }
    //     public decimal TotalAmount { get; set; }

    //     // Navigation property
    //     public virtual Customer Customer { get; set; }
    // }
    // public class Product
    // {
    //     public int Id { get; set; }
    //     public string Name { get; set; }
    //     public decimal Price { get; set; }
    //     public int Stock { get; set; }
    //     public string Description { get; set; }
    //     public string Category { get; set; }

    //     // Navigation property
    //     public virtual ICollection<Order> Orders { get; set; }
    // }
    // public class OrderItem
    // {
    //     public int Id { get; set; }
    //     public int OrderId { get; set; }
    //     public int ProductId { get; set; }
    //     public int Quantity { get; set; }
    //     public decimal Price { get; set; }

    //     // Navigation properties
    //     public virtual Order Order { get; set; }
    //     public virtual Product Product { get; set; }
    // }
    // public class Category
    // {
    //     public int Id { get; set; }
    //     public string Name { get; set; }
    //     public string Description { get; set; }

    //     // Navigation property
    //     public virtual ICollection<Product> Products { get; set; }
    // }
    // public class Address
    // {
    //     public int Id { get; set; }
    //     public string Street { get; set; }
    //     public string City { get; set; }
    //     public string State { get; set; }
    //     public string ZipCode { get; set; }
    //     public string Country { get; set; }

    //     // Navigation property
    //     public virtual Customer Customer { get; set; }
    // }
    // public class Payment
    // {
    //     public int Id { get; set; }
    //     public int OrderId { get; set; }
    //     public decimal Amount { get; set; }
    //     public string PaymentMethod { get; set; }
    //     public DateTime PaymentDate { get; set; }

    //     // Navigation property
    //     public virtual Order Order { get; set; }
    // }
    // public class Review
    // {
    //     public int Id { get; set; }
    //     public int ProductId { get; set; }
    //     public int CustomerId { get; set; }
    //     public string Comment { get; set; }
    //     public int Rating { get; set; }
    //     public DateTime CreatedAt { get; set; }

    //     // Navigation properties
    //     public virtual Product Product { get; set; }
    //     public virtual Customer Customer { get; set; }
    // }
    // public class Cart
    // {
    //     public int Id { get; set; }
    //     public int CustomerId { get; set; }
    //     public DateTime CreatedAt { get; set; }

    //     // Navigation property
    //     public virtual Customer Customer { get; set; }
    // }
}