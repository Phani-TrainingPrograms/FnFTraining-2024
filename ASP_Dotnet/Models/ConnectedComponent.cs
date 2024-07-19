using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleWebApp.Models
{

    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public long StudentPhone { get; set; }
    }

    public interface IDataComponent
    {
        List<Student> GetAllStudents();
        void AddNewStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
    }

    public class ConnectedComponent : IDataComponent
    {
        #region CONTANTS
        private const string STRCONNECTION = "Data Source=.\\SQLEXPRESS;Initial Catalog=FnfTraining;Integrated Security=True;";
        private const string STRSELECTNAMES = "SELECT StudentName FROM STUDENTTABLE";
        private const string STRSELECTALL = "SELECT * FROM STUDENTTABLE";
        private const string STRADD = "INSERT INTO STUDENTTABLE VALUES(@name, @email, @phone)";
        private const string STRUPDATE = "UPDATE STUDENTTABLE SET StudentName = @name, StudentEmail= @email, ContactNo = @phone WHERE StudentId = @id";

        private const string STRDELETE = "DELETE FROM STUDENTTABLE WHERE StudentId = @id";
        #endregion

        #region IDataComponent Implementations
        public void AddNewStudent(Student student)
        {
            using(var conn = new SqlConnection(STRCONNECTION))
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand(STRADD, conn);
                    cmd.CommandType = CommandType.Text;
                    //Add the parameters for the insert query
                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@email", student.StudentEmail);
                    cmd.Parameters.AddWithValue("@phone", student.StudentPhone);

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error in Adding Student", ex);
                }
                finally 
                { 
                    conn.Close(); 
                }
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var conn = new SqlConnection(STRCONNECTION))
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand(STRDELETE, conn);
                    cmd.CommandType = CommandType.Text;
                    //Add the parameters for the delete query
                    cmd.Parameters.AddWithValue("@id", studentId);
                    var rowsaffected = cmd.ExecuteNonQuery();//Used for one way communication. 
                    if (rowsaffected != 1)
                    {
                        throw new Exception($"Student with the Id {studentId} does not exist to delete");
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error in Deleting Student", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        /// <summary>
        /// This is a example for extracting data from the Database using Connected Model
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetAllStudentNames()
        {
            SqlConnection sqlCon = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = sqlCon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = STRSELECTNAMES;
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


        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();   
            using (SqlConnection sqlCon = new SqlConnection(STRCONNECTION))
            {
                SqlCommand sqlCmd = new SqlCommand(STRSELECTALL, sqlCon);
                sqlCon.Open();
                var reader = sqlCmd.ExecuteReader();
                //Read each row....
                while (reader.Read())
                {
                    //create student object for each row
                    Student student = new Student();
                    //fill the properties with the column values
                    student.StudentId = Convert.ToInt32(reader[0]);
                    student.StudentName = reader[1].ToString();
                    student.StudentEmail = reader[2].ToString();
                    student.StudentPhone = Convert.ToInt64(reader[3]);
                    //add the student to the collection
                    students.Add(student);
                }
            }
            //return the collection..
            return students;
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException("Do it URSELF");
        }

        #endregion
    }
}