using AutoWebShop.Helper;
using AutoWebShop.Models;
using AutoWebShopEntity.Repositorys;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AutoWebShop.Controllers
{
    public class AccountController : Controller
    {
        private AccountSystem _accountSystem;
        private static readonly ILog log = LogManager.GetLogger(typeof(AccountController));
        public AccountController()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _accountSystem = new AccountSystem(
                new AccountRepository(connectionString)
            );
        }
        // GET: Account
        
        //public ActionResult UserLogin(string returnUrl)
        //{
        //    ExternalLoginModel loginModel = new ExternalLoginModel();
        //    var externalUrl = loginModel.ReturnUrl = returnUrl;
        //    return View(externalUrl);
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public ActionResult UserLogin(LoginModel loginModel, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return View(loginModel);
        //    }
        //    //if(ModelState.IsValid && FormsAuthentication.Authenticate(accountModel.UserName, accountModel.Password))
        //    //{
        //    //    if (Url.IsLocalUrl(returnUrl))
        //    //    {
        //    //        return Redirect(returnUrl);
        //    //    }
        //    //    else
        //    //    {
        //    //        return RedirectToAction("UserLogin");
        //    //    }
        //    //}
        //    //return View(accountModel);
        //}
        //public ActionResult AccountRegister()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult AccountRegister(AccountModel accountModel) 
        {
            try
            {
                var tranformation = AccountHelper.EntityToModel(accountModel);
                _accountSystem.RegisterAccount(tranformation);
                return View("LogIn");
            }
            catch (Exception e)
            {
                log.Error(e.ToString());
                throw;
            }
        }
        
    }
}