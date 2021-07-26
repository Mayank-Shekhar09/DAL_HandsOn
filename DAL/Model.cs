using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Model
    {
        SqlConnection sqlConObj = null;
        SqlCommand sqlCmdObj = null;
        public void ConnectToDB()
        {
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjConStr"].ToString());
                sqlConObj.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public List<String> ReadfromDB()
        {
            List<String> lstModel = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjConStr"].ToString());
                sqlCmdObj = new SqlCommand(@"Select  ModelId, ModelName from Model", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drModel = sqlCmdObj.ExecuteReader();
                while (drModel.Read())
                {
                    lstModel.Add(String.Concat(drModel["ModelId"] + "  ", drModel["ModelName"]));
                }
                return lstModel;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstModel;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
