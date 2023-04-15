using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App1
{
   

    public class UserDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UserDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserInfo>().Wait();
        }

        public Task<List<UserInfo>> GetUsersAsync()
        {
            return database.Table<UserInfo>().ToListAsync();
        }

        public Task<int> SaveUserAsync(UserInfo user)
        {
            if (user.Id != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }
        public async Task<int> DeleteUserAsync(UserInfo user)
        {
            return await database.DeleteAsync(user);
        }

        internal object SearchUsersAsync(string query)
        {
            throw new NotImplementedException();
        }
    }
}
