using AutoWebShopEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoWebShopEntity.Interfaces
{
    public interface IAccountSystem
    {
        void RegisterAccount(AccountEntity accountRegistration);
        string GetUserAccount(string userAccount);
    }
}
