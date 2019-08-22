using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZetsubouGacha.Models
{
    public class Servant
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Dialogue { get; set; }
        public string Audio { get; set; }
        public string Summary { get; set; }
    }
}