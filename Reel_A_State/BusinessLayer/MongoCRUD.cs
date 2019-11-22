using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reel_A_StateData.Models;

namespace Reel_A_State.BusinessLayer
{
    public class MongoCRUD 
    {
        private IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertEstate<T>(string table, T estate)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(estate);
        }

        public ObservableCollection<EstateProperties> LoadEstates<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            collection.Find(new BsonDocument()).ToList();
            ObservableCollection<EstateProperties> myCollection = new ObservableCollection<EstateProperties>(collection as List<EstateProperties>);
            return myCollection;
        }
    }
}
