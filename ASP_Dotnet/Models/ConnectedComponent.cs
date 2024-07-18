using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleWebApp.Models
{
    public class ConnectedComponent
    {
        private const string STRCONNECTION = "Data Source=.\\SQLEXPRESS;Initial Catalog=FnfTraining;Integrated Security=True;";
        private const string STRSELECT = "SELECT StudentName FROM STUDENTTABLE";

        public List<string> GetAllStudents()
        {
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = STRSELECT;
            try
            {
                sqlCon.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<string> students = new List<string>();
                if (!dr.HasRows)
                {
                    throw new Exception("No Student data is available");
                }
                while (dr.Read())
                {
                    students.Add(dr["StudentName"].ToString());
                }
                return students;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }
    }
}