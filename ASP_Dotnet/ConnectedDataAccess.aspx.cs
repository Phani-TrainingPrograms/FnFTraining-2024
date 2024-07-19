using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SampleWebApp.Models;
using System.Data;
//ADO.NET is the oldest framwork for data connectivity. It has 2 ways of interacting with the database: Connected(Desktop Centric) and Disconnected Models(Web Centric). 
//The App will have const connectivity with the database while its reading the records. 
//In connected model, we need 3 classes to interact with the database:
//xxxConnection: Used to connect to the database. It has properties like ConnectionString and methods like Open and Close.
//xxxCommand: Represents the SQL Statement that U want to execute on the connection. Every SQL Command object has an object of the Connection in it. It has 3 methods to perform the SQL Statement execution: ExecuteNonQuery(Insert, Delete, Update), ExecuteScalar(Returning Single value), ExecuteReader that is used to extract the data(SELECT).
//xxxDataReader: ExecuteReader method of the Command object returns a Reader object that is used to read the data extracted from the Command. This object reads the records in a forward only and read only manner. 

namespace SampleWebApp
{
    public partial class ConnectedDataAccess : System.Web.UI.Page
    {
        static IDataComponent component = new ConnectedComponent();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = string.Empty;
                var students = component.GetAllStudents();
                lstStudents.DataSource = students;
                lstStudents.DataTextField = "StudentName";
                lstStudents.DataValueField = "StudentId";
                lstStudents.DataBind();
            }
        }

        protected void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = int.Parse(lstStudents.SelectedItem.Value);
            var records = component.GetAllStudents();
            var selectedStudent = records.FirstOrDefault(s => s.StudentId == selected);
            if (selectedStudent != null) 
            {
                txtId.Text = selectedStudent.StudentId.ToString();
                txtName.Text = selectedStudent.StudentName;
                txtEmail.Text = selectedStudent.StudentEmail;
                txtPhone.Text = selectedStudent.StudentPhone.ToString();
            }
            else
            {
                lblError.Text = "Student details not found!!!";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //create the student object with inputs from the user 
            var student = new Student();
            student.StudentName = txtName.Text;
            student.StudentEmail = txtEmail.Text;
            student.StudentPhone = Convert.ToInt64(txtPhone.Text);
            //Call the API to insert the record

            try
            {
                component.AddNewStudent(student);
                lblError.Text = "Student added successfully to the database";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}