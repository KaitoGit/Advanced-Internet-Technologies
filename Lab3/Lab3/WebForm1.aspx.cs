using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//added

namespace Lab3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataAccessLayer dal = new DataAccessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGridView();
        }
        private void refreshGridView()
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from Students";
            GridView1.DataSource = dal.selectData(sqlCommand);
            GridView1.DataBind();
        }
        private void clearTextBoxes()
        {
            TextBoxName.Text = "";
            TextBoxSurname.Text = "";
            TextBoxStudentNo.Text = "";
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int result;
            Student.setName(TextBoxName.Text);
            Student.setSurname(TextBoxSurname.Text);
            Student.setStudentNo(Convert.ToInt32(TextBoxStudentNo.Text));
            //result = Student.insertStudent();
            result = Student.insertStudentStoreProcedure();
            Student.resetStudent();
            refreshGridView();
            clearTextBoxes();
            Response.Write("result: " + result);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Student.setStudentNo(Convert.ToInt32(TextBoxStudentNo.Text));
            int result = Student.searchStudent();
            if(result == 1)
            {
                LabStudentPK.Text = Student.getStudentPK().ToString();
                TextBoxName.Text = Student.getName();
                TextBoxSurname.Text = Student.getSurname();
                btnUpdate.Enabled = true;

            }
            else if (result == 0)
            {
                Response.Write("Student with ID =" + Student.getStudentNo() + "is not found");
            }
            else
            {
                Response.Write("result =" + result + "- connection problem");
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
            LabStudentPK.Text = "";
            Student.resetStudent();
            btnUpdate.Enabled = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Student.setName(TextBoxName.Text);
            Student.setSurname(TextBoxSurname.Text);
            int result = Student.updateStudent();
            if (result == 1)
            {
                Response.Write("Student with ID = " + Student.getStudentNo() + "is updated");
                refreshGridView();
                

            }
            else if (result == 0)
            {
                Response.Write("Student with ID =" + Student.getStudentNo() + "is not updated");
            }
            else
            {
                Response.Write("result =" + result + "- connection problem");
            }
            btnClear_Click(sender, e);
        }
    }
}