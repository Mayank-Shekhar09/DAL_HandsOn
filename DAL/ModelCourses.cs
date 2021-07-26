using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ModelCourses
    {
        public List<string> Getdata()
        {
            SqlConnection sqlConObj = null;
            SqlCommand sqlCmdObj;
            List<string> lst = new List<string>();
            try
            {
                // Creating Connection  
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjConStr"].ToString());
                // writing sql query  
                sqlCmdObj = new SqlCommand("SELECT ModelId,CourseId FROM dbo.ModelCourses", sqlConObj);
                // Opening Connection  
                sqlConObj.Open();

                // Executing the SQL query  
                SqlDataReader sdr = sqlCmdObj.ExecuteReader();
                while (sdr.Read())
                {
                    lst.Add(String.Concat(sdr["ModelId"], sdr["CourseId"]));
                }
                return lst;
            }
            catch (Exception e)
            {
                //Console.WriteLine("OOPs, something went wrong." + e);
                lst.Add(e.ToString());
                return lst;

            }
            // Closing the connection  
            finally
            {
                sqlConObj.Close();
            }

        }
    }
}
