using Campanhabrinquedo.IoC;
using CampanhaBrinquedo.Data.MongoDb.Factories;
using CampanhaBrinquedo.Domain.Entities;
using CampanhaBrinquedo.Domain.Interfaces;
using CampanhaBriquedo.CrossCutting.Options;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Campanhabrinquedo.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        public Repository(
            IDatabaseFactory databaseFactory, 
            IOptions<MongoOptions> mongoOptions, 
            string collection
        )
        {
            _database = databaseFactory.Get(mongoOptions);
            _collectionName = collection;
        }

        private IMongoCollection<T> Collection
            => _database.GetCollection<T>(_collectionName);

        public virtual void Create(T entity) => Collection.InsertOne(entity);

        public void Delete(Guid id) => Collection.DeleteOne(_ => _.Id == id);

        public void Update(T entity) => Collection.ReplaceOne(_ => _.Id == entity.Id, entity);

        public async Task CreateAsync(T entity) => await Collection.InsertOneAsync(entity);

        public async Task<IEnumerable<T>> List() => await Collection.AsQueryable().ToListAsync();

        public async Task<IEnumerable<T>> List(Expression<Func<T, bool>> expression) => await Collection.Find(expression).ToListAsync();

        public async Task<T> FindById(Guid id) => await Collection.Find(_ => _.Id == id).FirstOrDefaultAsync();

        public async Task<T> FindByExpression(Expression<Func<T, bool>> expression) => await Collection.Find(expression).FirstOrDefaultAsync();

        public async Task UpdateAsync(T entity) => await Collection.ReplaceOneAsync(_ => _.Id == entity.Id, entity);

        public async Task DeleteAsync(Guid id) => await Collection.DeleteOneAsync(_ => _.Id == id);
    }
}
