using Dhagaa.DataBusiness;
using Dhagaa.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DhaggaEnterprise.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {
            
        }


        [HttpPost]
        public JsonResult ValidateUser(string username, string password)
        {
            ActionResultEntity result = new ActionResultEntity();

            result = UserService.checkUserExist(username, password);
            if (result != null && Convert.ToInt64(result.ReturnObject) > 0)
                System.Web.HttpContext.Current.Session["UserInfo"] = result;

            return Json(result);
        }
    }
}