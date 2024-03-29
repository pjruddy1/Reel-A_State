﻿using MongoDB.Bson;
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
    /// <summary>
    /// A portion of this class was borrowed from:
    /// Tim Corey
    /// Intro to MongoDB with C# - Learn what NoSQL is, why it is different than SQL and how to use it in C#
    /// https://www.youtube.com/watch?v=69WBy4MHYUw
    /// </summary>
    public class MongoCRUD 
    {
        private IMongoDatabase db;

        #region Methods
        /// <summary>
        /// Insert Property into Database
        /// </summary>
        /// <typeparam name="EstateProperties"></typeparam>
        /// <param name="table"></param>
        /// <param name="estate"></param>
        public void InsertEstate<EstateProperties>(string table, EstateProperties estate)
        {
            var collection = db.GetCollection<EstateProperties>(table);
            collection.InsertOne(estate);
        }
        /// <summary>
        /// Reach Database to get list of properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<T> LoadEstates<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }
        /// <summary>
        /// Update Entry to Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <param name="Record"></param>
        /// <param name="estate"></param>
        public void UpdateEstate<T>(string table, Guid id, T Record, EstateProperties estate)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            var update = Builders<T>.Update.Set("Address", estate.Address)
                                                            .Set("City", estate.City).Set("State", estate.State).Set("Zipcode", estate.Zipcode).Set("Price", estate.Price)
                                                            .Set("Bathrooms", estate.Bathrooms).Set("Bedrooms", estate.Bedrooms).Set("Pool", estate.Pool).Set("SqrFeet", estate.SqrFeet)
                                                            .Set("Comment", estate.Comment).Set("Description", estate.Description).Set("Fireplace", estate.Fireplace);
            collection.UpdateOne(filter, update);
        }
        /// <summary>
        /// Delete Entry from database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <param name="id"></param>
        /// <param name="Record"></param>
        public void DeleteEstate<T>(string table, Guid id, T Record)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", id);

            collection.DeleteOne(filter);
        }
        #endregion
        #region Constructor
        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb://PJ123:Longshot1984@propertydb-shard-00-00-tmilp.mongodb.net:27017,propertydb-shard-00-01-tmilp.mongodb.net:27017,propertydb-shard-00-02-tmilp.mongodb.net:27017/test?ssl=true&replicaSet=PropertyDB-shard-0&authSource=admin&retryWrites=true&w=majority");
            db = client.GetDatabase(database);
        }
        #endregion
        
    }
}
