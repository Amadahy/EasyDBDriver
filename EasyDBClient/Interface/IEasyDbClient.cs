using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyDBConnector.Interface
{
    public interface IEasyDbClient<T> where T : EasyDbElement
    {
        /// <summary>
        /// Return whole collection based on query
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetCollectionAsync(string query);

        /// <summary>
        /// Return whole collection
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetCollectionAsync();

        /// <summary>
        /// Return one row from collection by id:string
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(string id);

        /// <summary>
        /// create row with random id string and return id
        /// </summary>
        /// <returns></returns>
        Task<T> AddAsync(T element);

        /// <summary>
        /// update row (shallow merge) from collection by id
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// remove whole row from collection by id
        /// </summary>
        Task DeleteAsync(T entity);

        /// <summary>
        /// remove whole row from collection by id
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAsync(string id);
    }
}