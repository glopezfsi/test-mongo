using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMongo.Models
{
    public class GlobalModel
    {
        public ObjectId _id { get; set; }

        [BsonElement("key")]
        public string Key { get; set; }

        Paco monger

        [BsonElement("group")]
        public string Group { get; set; }

        [BsonElement("projects")]
        public List<string> Projects { get; set; }

        [BsonElement("public")]
        public bool Public { get; set; }

        [BsonElement("translations")]
        public Dictionary<string, string> Translations { get; set; }
    }
}
