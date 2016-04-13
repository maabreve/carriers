using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Carriers.Data
{
    public class RepositoryFactories
    {
        private IDictionary<Type, Func<DbContext, object>> GetCarriersFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
                {
                   
                };
        }

        public RepositoryFactories()
        {
            _repositoryFactories = GetCarriersFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {

            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new EfRepository<T>(dbContext);
        }

        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

    }
}
