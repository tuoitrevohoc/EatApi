using System;
using System.Collections.Generic;
using EatApi.Models;
using MongoDB.Driver;

namespace EatApi.Repositories.Mongo
{

    /// <summary>
    /// Mongo repository.
    /// </summary>
    public class MongoRepository<TEntity>: IRepository<TEntity>
        where TEntity: Entity
    {
        /// <summary>
        /// mongodb collection
        /// </summary>
        private IMongoCollection<TEntity> collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EatApi.Repositories.Mongo.MongoRepository`1"/> class.
        /// </summary>
        /// <param name="collection">Collection.</param>
        public MongoRepository(IMongoCollection<TEntity> collection)
        {
            this.collection = collection;
        }

        /// <summary>
        /// Delete the record
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="data">Data.</param>
        public bool Delete(TEntity data)
        {
            return Delete(data.Id);
        }

        /// <summary>
        /// Delete with id
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="id">Identifier.</param>
        public bool Delete(string id) 
        {
            return collection.DeleteOne(item => id == item.Id).DeletedCount == 1;
        }

        /// <summary>
        /// Get the specified id.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="id">Identifier.</param>
        public TEntity Get(string id)
        {
            return collection.Find(item => item.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns>The all.</returns>
        public IList<TEntity> GetAll()
        {
            return collection.Find(item => true).ToList();
        }

        /// <summary>
        /// Save an item
        /// </summary>
        /// <returns>The save.</returns>
        /// <param name="data">Data.</param>
        public bool Save(TEntity data)
        {
            if (string.IsNullOrEmpty(data.Id))
            {
                data.Id = Guid.NewGuid().ToString();
                collection.InsertOne(data);    
            }
            else
            {
                collection.FindOneAndReplace(item => item.Id == data.Id, data);
            }

            return true;
        }
    }
}
