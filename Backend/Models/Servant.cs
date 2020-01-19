using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZetsubouGacha.Models
{
    public class Servant
    {
        [BsonId]
        ObjectId _id { get; }

        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("firstImage")]
        public string FirstAscensionImage { get; set; }

        [BsonElement("finalImage")]
        public string FinalAscensionImage { get; set; }

        [BsonElement("dialogue")]
        public string Dialogue { get; set; }

        [BsonElement("audio")]
        public string Audio { get; set; }
    }
}
