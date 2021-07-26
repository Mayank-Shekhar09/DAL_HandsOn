using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Batch
    {
        System.Data.SqlClient.SqlConnection sqlConObj = null;
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
            List<String> lstBatch = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjConStr"].ToString());
                sqlCmdObj = new SqlCommand(@"Select BatchId,BatchName,NoOfStudent from Batch", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drBatch = sqlCmdObj.ExecuteReader();
                while (drBatch.Read())
                {
                    lstBatch.Add(String.Concat(drBatch["BatchId"] + "  ", drBatch["BatchName"] + "  ", drBatch["BatchStrength"]));
                }
                return lstBatch;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstBatch;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
