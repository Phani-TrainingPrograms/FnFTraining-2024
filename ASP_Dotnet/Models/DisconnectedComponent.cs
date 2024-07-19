using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SampleWebApp.Models
{
    public class DisconnectedComponent : IDataComponent
    {
        
        private readonly string _conString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        private const string SELECTSTATEMENT = "SELECT * FROM STUDENTTABLE";

        private SqlDataAdapter adapter;
        private DataSet ds;
        private SqlCommandBuilder sqlCommandBuilder;

        public DisconnectedComponent()
        {
            adapter = new SqlDataAdapter(SELECTSTATEMENT , _conString);
            sqlCommandBuilder = new SqlCommandBuilder(adapter);
            ds = new DataSet("myTables");
            adapter.Fill(ds, "myFirstTable");
        }
        public void AddNewStudent(Student student)
        {
            DataRow row = ds.Tables[0].NewRow();
            row[1] = student.StudentName;
            row[2] = student.StudentEmail;
            row[3] = student.StudentPhone;
            ds.Tables[0].Rows.Add(row);
            adapter.Update(ds, "myFirstTable");  
        }

        public void DeleteStudent(int studentId)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[0].ToString() == studentId.ToString())
                {
                    row.Delete();
                    adapter.Update(ds, "myFirstTable");
                    return;
                }
            }
            throw new Exception("Record not found to delete");
        }

        public List<Student> GetAllStudents()
        {
            //Create a new List object of the type Student....
            List<Student> students = new List<Student>();
            //Iterate thro the Rows of the Table in the dataset
            foreach (DataRow row in ds.Tables["myFirstTable"].Rows)
            {
                //For each row, create a Student object and fill the data into it. 
                Student student = new Student();
                student.StudentId = Convert.ToInt32(row[0]);
                student.StudentName = row[1].ToString();
                student.StudentEmail = row[2].ToString();
                student.StudentPhone = (long)row[3];
                //Add the Student to the list
                students.Add(student);
            }
            //Return the List.
            return students;
        }

        public void UpdateStudent(Student student)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row[0].ToString() == student.StudentId.ToString())
                {
                    row[1] = student.StudentName;
                    row[2] = student.StudentEmail;
                    row[3] = student.StudentPhone;
                    adapter.Update(ds, "myFirstTable");
                    return;
                }
            }
            throw new Exception("Record cannot be updated as no record is found");
        }
    }
}
