using System;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MongoDB.Bson;

namespace Patagoniaarg
{
    public class User
    {




        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
