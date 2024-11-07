﻿using System.Threading.Tasks;

namespace SmedaInternalMobile.ApiManagers
{
    public interface IApiManager
    {
       Task<T> GetAsync<T>(string uri);
        Task<T> GetAsync<T>(string uri, object data);
        Task<T> GetAsync<T>(string uri, T data);
        Task<T> PostAsync<T>(string uri, T data);
        Task<T> PostAsync<T>(string uri, object data);
        Task<T> PutAsync<T>(string uri, object data);
        Task<T> DeleteAsync<T>(string uri);
        Task<R> PostAsync<T, R>(string uri, T data);
        Task<R> PutAsync<T, R>(string uri, T data);
        Task<R> DeleteAsync<T, R>(string uri, T data);
    }
}