using System;
using System.Collections.Generic;
using System.Linq;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Generic repository interface, based loosely off NHibernate
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Saves an object in the repository
        /// </summary>
        /// <param name="value">Object to save</param>
        void Save(object value);

        /// <summary>
        /// Saves a set of objects in the repository
        /// </summary>
        /// <param name="value">Objects to save</param>
        void Save(IEnumerable<object> value);

        /// <summary>
        /// Deletes a previously persisted object
        /// </summary>
        /// <param name="value">Object to delete</param>
        void Delete(object value);

        /// <summary>
        /// Gets an object by an Id
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="id">Id value.  This should be a primary key</param>
        /// <returns>Persisted object</returns>
        T GetById<T>(object id);

        /// <summary>
        /// Gets an object by an Id
        /// </summary>
        /// <param name="objectType">Type of object</param>
        /// <param name="id">Id value.  This should be a primary key</param>
        /// <returns>Persisted object</returns>
        object GetById(Type objectType, object id);

        /// <summary>
        /// Returns a queryable for an object type to allow sorting, searching, etc.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <returns>Linq queryable expression</returns>
        IQueryable<T> Query<T>();

        /// <summary>
        /// Flushes all pending changes to the persistence store
        /// </summary>
        void Flush();
    }
}
