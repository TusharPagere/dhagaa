using Dhagaa.DataEntities;
using Dhagg.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhagaa.DataBusiness
{
    public class UserService
    {
        public static ActionResultEntity checkUserExist(string username, string password)
        {
            ActionResultEntity result = new ActionResultEntity();

            try
            {
                DataTable dt = UserDataAccess.UserData(username, password);

                if (dt != null && dt.Rows.Count > 0)
                {
                    result.Status = "success";
                    result.Message = "User Found!";
                    result.ReturnObject = Convert.ToString(dt.Rows[0]["UserId"]);
                }
                else
                {
                    result.Status = "success";
                    result.Message = "User Not Found!";
                    result.ReturnObject = "0";
                }
            }
            catch (Exception ex)
            {

                result.Status = "error";
                result.Message = ex.ToString();
                result.ReturnObject = null;
            }

            return result;
        }
    }
}
