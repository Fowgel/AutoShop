using AutoWebShop.Models;
using AutoWebShopEntity.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoWebShop.Helper
{
    public class AccountHelper
    {
        public static AccountModel ModelToEntity(AccountEntity accountEntity)
        {
            var model = new AccountModel();
            model.AccountId = accountEntity.AccountId;
            model.UserName = accountEntity.UserName;
            model.Email = accountEntity.Email;
            model.Password = accountEntity.Password;
            return model;
        }
        public static AccountEntity EntityToModel(AccountModel accountEntity)
        {
            var model = new AccountEntity();
            model.AccountId = accountEntity.AccountId;
            model.UserName = accountEntity.UserName;
            model.Email = accountEntity.Email;
            model.Password = accountEntity.Password;
            return model;
        }
    }
}