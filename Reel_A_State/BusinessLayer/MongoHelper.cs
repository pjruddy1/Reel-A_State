using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_State.BusinessLayer
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string MongoConnection = "mongodb://PJ123:Longshot1984@propertydb-shard-00-00-tmilp.mongodb.net:27017,propertydb-shard-00-01-tmilp.mongodb.net:27017,propertydb-shard-00-02-tmilp.mongodb.net:27017/test?ssl=true&replicaSet=PropertyDB-shard-0&authSource=admin&retryWrites=true&w=majority";
        public static string MongoDatabase = "PropertyDB";

        
    }
}
