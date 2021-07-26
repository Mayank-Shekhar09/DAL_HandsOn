using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Participant
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
            List<String> lstPart = new List<string>();
            try
            {
                sqlConObj = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjConStr"].ToString());
                sqlCmdObj = new SqlCommand(@"Select ParticipantId,ParticipantName,ParticipantEmail from Participants", sqlConObj);
                sqlConObj.Open();
                SqlDataReader drPart = sqlCmdObj.ExecuteReader();
                while (drPart.Read())
                {
                    lstPart.Add(String.Concat(drPart["ParticipantId"] + "  ", drPart["ParticipantName"] + "  ", drPart["ParticipantEmail"]));
                }
                return lstPart;
            }
            catch (Exception)
            {
                Console.WriteLine("Oops!!Something Happened!");
                return lstPart;
            }
            finally
            {
                sqlConObj.Close();
            }
        }
    }
}
