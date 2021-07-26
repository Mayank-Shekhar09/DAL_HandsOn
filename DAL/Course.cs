using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Course
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
                Console.WriteLine("Something Happened!");
            }
            finally
            {
                sqlConObj.Close();
            }
        }

        public List<String> ReadfromDB()
        {
            List<String> lstCourses = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjConStr"].ToString());
                sqlCmdObj = new SqlCommand(@"Select CourseId, CourseTitle, NoOfHours, CourseOwner_ID from Courses", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drCourses = sqlCmdObj.ExecuteReader();
                while (drCourses.Read())
                {
                    lstCourses.Add(String.Concat(drCourses["CourseId"] + "  ", drCourses["CourseTitle"] + "  ", drCourses["NoOfHours"] + "  ", drCourses["CourseOwner_ID"]));
                }
                return lstCourses;
            }
            catch (Exception)
            {
                Console.WriteLine("Something Happened!");
                return lstCourses;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
