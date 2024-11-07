using Logic.IServices;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class GenericService<T> : IGenericService<T> where T : class, new()
    {
        private const string DbName = "MyDatabase.db3";
        private static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);
        private SQLiteAsyncConnection _connection;

        private SQLiteAsyncConnection Database =>
            (_connection ??= new SQLiteAsyncConnection(DbPath,
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache));


        private async Task CreateTableIfNotExists<T>() where T : class, new()
        {
            await Database.CreateTableAsync<T>();
        }

        private async Task<AsyncTableQuery<T>> GetTabelAsync<T>() where T : class, new()
        {
            await CreateTableIfNotExists<T>();
            return Database.Table<T>();
        }

        public async Task<List<T>> GetAll()
        {
            // await Init();
            await Database.CreateTableAsync<T>();
            //var table = await GetTabelAsync<T>();
            return await Database.Table<T>().ToListAsync();

         }

        public async Task<bool> Delete(object id)
        {
            await CreateTableIfNotExists<T>();
            return await Database.DeleteAsync<T>(id) > 0;
        }
        public async Task<T> GetById(object id)
        {
            await CreateTableIfNotExists<T>();
            return await Database.GetAsync<T>(id);
        }

        public async Task<bool> Insert(T obj)
        {
            await CreateTableIfNotExists<T>();
            return await Database.InsertAsync(obj) > 0;
        }



        public async Task<bool> Update(T obj)
        {
            await CreateTableIfNotExists<T>();
            return await Database.UpdateAsync(obj) > 0;
        }

        public async ValueTask Dispose() => await _connection?.CloseAsync();
    }
}
