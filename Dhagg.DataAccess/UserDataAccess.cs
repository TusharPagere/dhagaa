using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhagg.DataAccess
{
    public class UserDataAccess
    {
        public static DataTable UserData(string username, string password)
        {
            try
            {
                List<SqlParameter> SQLParameters = new List<SqlParameter>();
                SQLParameters.Add(new SqlParameter("@UserFirstName", username));
                SQLParameters.Add(new SqlParameter("@UserPassword", password));

                return DatabaseAccess.GetDataTable("ST_User_Authenticate", SQLParameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
