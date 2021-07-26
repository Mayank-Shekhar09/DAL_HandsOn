using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Grader
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
            List<String> lstGrader = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjConStr"].ToString());
                sqlCmdObj = new SqlCommand(@"Select FacultyId, ParticipantId, TotalMarks, AreaOfImprovement, AreaOfExcellence from Grader", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drGrader = sqlCmdObj.ExecuteReader();
                while (drGrader.Read())
                {
                    lstGrader.Add(String.Concat(drGrader["FacultyId"] + "  ", drGrader["ParticipantId"] + "  ", drGrader["TotalMarks"] + "  ", drGrader["AreaOfImprovement"] + "  ", drGrader["AreaOfExcellence"]));
                }
                return lstGrader;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstGrader;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
