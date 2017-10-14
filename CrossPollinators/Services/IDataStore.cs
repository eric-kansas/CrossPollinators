using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace playground
{
    public interface IDataStore<T>
    {
        //Task<bool> AddItemAsync(T item);
        //Task<bool> UpdateItemAsync(T item);
        //Task<bool> DeleteItemAsync(string id);
        //Task<IEnumerable<ProjectModel>> Query(string query);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<String> Login(String email, String password);
        Task<String> Register(String email, String password);
    }
}
