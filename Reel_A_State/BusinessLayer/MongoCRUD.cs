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

        public ObservableCollection<EstateProperties> LoadEstates<EstateProperties>(string table)
        {
            var collection = db.GetCollection<EstateProperties>(table);
            collection.Find(new BsonDocument()).ToList();
            ObservableCollection<EstateProperties> myCollection = new ObservableCollection<EstateProperties>(collection as List<EstateProperties>);
            return myCollection;
        }

        public void UpsertEstate<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);

            var result = collection.ReplaceOne(
                new BsonDocument("_id", id),
                record,
                new UpdateOptions { IsUpsert = true });
        }

        public void DeleteEstate<T>(string table, Guid id, T Record)
        {
            var collection = db.GetCollection<T>(table);

            var deleteFilter = Builders<BsonDocument>.Filter.Eq("_id", id);

            //collection.DeleteOne(deleteFilter);
        }
    }
}
