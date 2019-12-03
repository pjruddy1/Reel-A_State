using MongoDB.Bson;
using MongoDB.Driver;
using Reel_A_StateData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reel_A_State.DataAccessLayer
{
    public class DataServiceMongo: IDataService
    {
        private IMongoDatabase db;

        public IEnumerable<EstateProperties> ReadAll(string table)
        {
            
            try
            {
                var collection = db.GetCollection<EstateProperties>(table);
                return collection.Find(new BsonDocument()).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void UpdateEstate<T>(string table, Guid id, T Record, EstateProperties estate)
        {
            try
            {
                var collection = db.GetCollection<T>(table);
                var filter = Builders<T>.Filter.Eq("_id", id);
                var update = Builders<T>.Update.Set("Address", estate.Address)
                                                                .Set("City", estate.City).Set("State", estate.State).Set("Zipcode", estate.Zipcode).Set("Price", estate.Price)
                                                                .Set("Bathrooms", estate.Bathrooms).Set("Bedrooms", estate.Bedrooms).Set("Pool", estate.Pool).Set("SqrFeet", estate.SqrFeet)
                                                                .Set("Comment", estate.Comment).Set("Description", estate.Description).Set("Fireplace", estate.Fireplace);
                collection.UpdateOne(filter, update);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void DeleteEstate<T>(string table, Guid id, T Record)
        {
            try
            {
                var collection = db.GetCollection<T>(table);

                var filter = Builders<T>.Filter.Eq("Id", id);

                collection.DeleteOne(filter);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void InsertEstate<EstateProperties>(string table, EstateProperties estate)
        {
            try
            {
                var collection = db.GetCollection<EstateProperties>(table);
                collection.InsertOne(estate);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataServiceMongo(string database)
        {
            var client = new MongoClient("mongodb://PJ123:Longshot1984@propertydb-shard-00-00-tmilp.mongodb.net:27017,propertydb-shard-00-01-tmilp.mongodb.net:27017,propertydb-shard-00-02-tmilp.mongodb.net:27017/test?ssl=true&replicaSet=PropertyDB-shard-0&authSource=admin&retryWrites=true&w=majority");
            db = client.GetDatabase(database);
        }
    }
}
