using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Faculty
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
            List<String> lstFaculty = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjConStr"].ToString());
                sqlCmdObj = new SqlCommand(@"Select  PSNo, EmailId, NAME from Faculty", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drFaculty = sqlCmdObj.ExecuteReader();
                while (drFaculty.Read())
                {
                    lstFaculty.Add(String.Concat(drFaculty["PSNo"] + "  ", drFaculty["EmailID"] + "  ", drFaculty["NAME"]));
                }
                return lstFaculty;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstFaculty;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
