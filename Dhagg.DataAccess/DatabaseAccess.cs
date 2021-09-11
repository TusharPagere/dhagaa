using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dhagg.DataAccess
{
    public class DatabaseAccess
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString();

        private static void closeSQLConnection(ref SqlConnection sqlcon)
        {
            if (sqlcon != null && sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
        }

        public static DataTable GetDataTable(string ProcedureName, List<SqlParameter> ProcedureParameters)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ProcedureName;
                    cmd.Connection = sqlcon;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (var parameter in ProcedureParameters)
                        cmd.Parameters.Add(parameter);

                    SqlDataAdapter objDA = new SqlDataAdapter(cmd);
                    DataSet objDS = new DataSet();

                    try
                    {
                        sqlcon.Open();
                        objDA.Fill(objDS, "Data");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                    return objDS.Tables["Data"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetDataTable(string ProcedureName, Hashtable ProcedureParameters)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ProcedureName;
                    cmd.Connection = sqlcon;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (DictionaryEntry hash in ProcedureParameters)
                    {
                        cmd.Parameters.AddWithValue(hash.Key.ToString(), hash.Value);
                    }

                    SqlDataAdapter objDA = new SqlDataAdapter(cmd);
                    DataSet objDS = new DataSet();

                    try
                    {
                        sqlcon.Open();
                        objDA.Fill(objDS, "Data");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                    return objDS.Tables["Data"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetDataset(string ProcedureName, Hashtable ProcedureParameters)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ProcedureName;
                    cmd.Connection = sqlcon;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (DictionaryEntry hash in ProcedureParameters)
                    {
                        cmd.Parameters.AddWithValue(hash.Key.ToString(), hash.Value);
                    }

                    SqlDataAdapter objDA = new SqlDataAdapter(cmd);
                    DataSet objDS = new DataSet();

                    try
                    {
                        sqlcon.Open();
                        objDA.Fill(objDS);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                    return objDS;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static bool ExecuteOutCommand(string ProcedureName, SqlCommand cmd)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    //SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ProcedureName;
                    cmd.Connection = sqlcon;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        sqlcon.Open();
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                    //return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return false;
            }
            //return false;
        }

        //public static bool Execute_Procedure(string ProcedureName, Hashtable ProcedureParameters)
        //{
        //    try
        //    {
        //        using (SqlConnection sqlcon = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandText = ProcedureName;
        //            cmd.Connection = sqlcon;
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            foreach (DictionaryEntry hash in ProcedureParameters)
        //            {
        //                cmd.Parameters.AddWithValue(hash.Key.ToString(), hash.Value);
        //            }
        //            try
        //            {
        //                sqlcon.Open();
        //                cmd.ExecuteNonQuery();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //            finally
        //            {
        //                sqlcon.Close();
        //            }
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //        return false;
        //    }
        //    return false;
        //}

        public static object ExecuteScalar(string ProcedureName, Hashtable ProcedureParameters)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ProcedureName;
                    cmd.Connection = sqlcon;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (DictionaryEntry hash in ProcedureParameters)
                    {
                        cmd.Parameters.AddWithValue(hash.Key.ToString(), hash.Value);
                    }
                    try
                    {
                        sqlcon.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return null;
        }

        public static object ExecuteScalar(string ProcedureName, List<SqlParameter> ProcedureParameters)
        {
            object retval = null;
            try
            {

                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ProcedureName;
                    cmd.Connection = sqlcon;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (var parameter in ProcedureParameters)
                        cmd.Parameters.Add(parameter);

                    try
                    {
                        sqlcon.Open();
                        retval = cmd.ExecuteScalar();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        sqlcon.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retval;
        }




    }
}