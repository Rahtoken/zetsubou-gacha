using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZetsubouGacha.Models
{
    public class Servant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string FirstAscensionImage { get; set; }

        public string FinalAscensionImage { get; set; }

        public string Dialogue { get; set; }

        public string Audio { get; set; }

        public string Summary { get; set; }
    }
}