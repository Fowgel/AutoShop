using AutoWebShopEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoWebShopEntity.Entitys;
using Dapper;

namespace AutoWebShopEntity.Repositorys
{
    public class AccountRepository : BaseRepository<AccountEntity>, IAccountRepository
    {
        public AccountRepository(string connectionString) : base(connectionString)
        {
        }
        public string GetUserAccount(string userAccount)
        {
            throw new NotImplementedException();
        }

        public void RegisterAccount(AccountEntity accountRegistration)
        {
            using (var connection = base.Connection())
            {
                connection.Execute(SqlQuerys.RegisterAccount, 
                    new {
                        AccountId = accountRegistration.AccountId,
                        UserName = accountRegistration.UserName,
                        Email = accountRegistration.Email,
                        Password = accountRegistration.Password
                    });
            }
        }
        public static class SqlQuerys
        {
            public static string RegisterAccount =>
                @"INSERT into dbo.[tAccount] (AccountId, UserName, Email, Password) values (@AccountId, @UserName, @Email, @Password)";
            public static string GetAccount =>
                @"";
        }
    }
}
