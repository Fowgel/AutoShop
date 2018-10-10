using AutoWebShopEntity.Entitys;
using AutoWebShopEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Repositorys
{
    public class AccountSystem : IAccountSystem
    {
        public IAccountRepository _accountRepository;
        public AccountSystem(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public string GetUserAccount(string userAccount)
        {
            throw new NotImplementedException();
        }

        public void RegisterAccount(AccountEntity accountRegistration)
        {

            AccountGuid(accountRegistration);
            AccountCreated(accountRegistration);
            _accountRepository.RegisterAccount(accountRegistration);
        }
        public Guid AccountGuid(AccountEntity account)
        {
            var newAccountGuid = Guid.NewGuid();
            account.AccountId = newAccountGuid;
            return newAccountGuid;
        }
        public DateTime AccountCreated(AccountEntity account)
        {
            var accountCreated = DateTime.UtcNow.AddHours(2);
            account.DayCreated = accountCreated;
            return accountCreated;
        }
    }
}
