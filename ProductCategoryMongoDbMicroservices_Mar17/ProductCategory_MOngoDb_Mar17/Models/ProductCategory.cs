using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductCategory_MOngoDb_Mar17.Models
{
    public class ProductCategory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; } 
        public string productName { get; set; }
        public int productPrice { get; set; }
        public string productReview { get; set; }
     
        public string categoryName { get; set; } 
    }
}
