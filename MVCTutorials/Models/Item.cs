using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MVCTutorials.Models
{
    public class Item
    {
        // This property is used to store the unique identifier for the item in MongoDB
        public string Id { get; set; }

        public string Name { get; set; }

        [StringLength(200, ErrorMessage ="Description cannot exceed 200 words")]
        public string Description { get; set; }

        public decimal Price { get; set; }
        // Constructor
        public Item(string id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
       
    }
}
