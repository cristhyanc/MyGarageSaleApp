
using MyGarageSale.Shared.DTO;
using PCLStorage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyGarageSale.Repository
{

    public class SqlService : ISqlService
    {
        private SQLiteConnection _connection;
        private SQLiteAsyncConnection _connectionAsync;

        protected SQLiteConnection DBConnection
        {
            get
            {
                try
                {
                    if (_connection == null)
                    {
                        IFolder rootFolder = FileSystem.Current.LocalStorage;
                        _connection = new SQLiteConnection(System.IO.Path.Combine(rootFolder.Path, "GarageSale.db"));

                    }
                    return _connection;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
               

        protected SQLiteAsyncConnection DBConnectionAsync
        {
            get
            {
                try
                {
                    if (_connectionAsync == null)
                    {
                        IFolder rootFolder = FileSystem.Current.LocalStorage;
                        _connectionAsync = new SQLiteAsyncConnection(System.IO.Path.Combine(rootFolder.Path, "GarageSale.db"));

                    }
                    return _connectionAsync;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public SqlService()
        {
            try
            {
                CreateTables();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreateTables()
        {
            try
            {

                // DBConnection.DropTable<CBaseSafetyConversation>();
                //DBConnectionAsync.CreateTableAsync<CBaseSafetyConversation>();
                DBConnectionAsync.CreateTableAsync<LogErrorTO>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public virtual Boolean SaveData<T>(T data)
        {
            try
            {

                if (DBConnection.Insert(data) != 0)
                    DBConnection.Update(data);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual Boolean DeleteData<T>(T data)
        {
            try
            {

                DBConnection.Delete(data);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async virtual Task<Boolean> DeleteDataAsync<T>(T data)
        {
            try
            {

                await DBConnectionAsync.DeleteAsync(data);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async virtual Task<Boolean> SaveDataAsync<T>(T data)
        {
            try
            {

                if (await DBConnectionAsync.DeleteAsync(data) != 0)
                    await DBConnectionAsync.UpdateAsync(data);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
