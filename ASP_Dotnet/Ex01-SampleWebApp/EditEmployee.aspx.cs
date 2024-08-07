﻿using SampleWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var empId =int.Parse(Request.QueryString["empId"]);
                var records = new EmployeeDB().GetAllEmployees();
                var rec = records.FirstOrDefault(emp => emp.EmpId == empId);
                if (rec == null)
                {
                    return;
                }
                txtId.Text = rec.EmpId.ToString();
                txtName.Text = rec.EmpName;
                txtAddress.Text = rec.EmpAddress;
                txtSalary.Text = rec.EmpSalary.ToString();
                txtDept.Text = rec.DeptId.ToString();
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }
    }
}