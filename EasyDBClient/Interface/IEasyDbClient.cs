using EasyDBDriver.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyDBDriver.Interface
{
    public interface IEasyDbClient<T> where T : EasyDbElement
    {
        /// <summary>
        /// Return whole collection based on query
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetCollectionAsync(IOperator op);

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
        Task<string> AddAsync(T element);

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

        /// <summary>
        /// Return file content
        /// </summary>
        /// <param name="fileModel"></param>
        /// <returns></returns>
        Task<byte[]> GetFileAsync(FileModel fileModel);

        /// <summary>
        /// return filecontent
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<byte[]> GetFileAsync(string url);
    }
}