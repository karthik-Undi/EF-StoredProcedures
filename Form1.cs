using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace linqsql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void showallbutton_Click(object sender, EventArgs e)
        {
            //create DataContext object
            using (EmployeeDataContext EmpDBContext = new EmployeeDataContext()){

                var EmployeeList = from Employee in EmpDBContext.GetTable<EmployeeDetail>() select Employee;
                dataGridView1.DataSource = EmployeeList;
            }
            idbox.Clear(); namebox.Clear(); salarybox.Clear();
        }

        private void insertbutton_Click(object sender, EventArgs e)
        {
            using(EmployeeDataContext EmpDBContext =new EmployeeDataContext())
            {
                EmpDBContext.InsertEmployee(Convert.ToInt32(idbox.Text), namebox.Text, Convert.ToInt32(salarybox.Text));
                showallbutton_Click(sender, e);
            }
            idbox.Clear(); namebox.Clear(); salarybox.Clear();
        }

        private void updatebutton_Click(object sender, EventArgs e)
        {
            using (EmployeeDataContext EmpDBContext = new EmployeeDataContext())
            {
                EmpDBContext.UpdateEmployee(Convert.ToInt32(idbox.Text), namebox.Text, Convert.ToInt32(salarybox.Text));
                showallbutton_Click(sender, e);
            }
            idbox.Clear(); namebox.Clear(); salarybox.Clear();

        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            using (EmployeeDataContext EmpDBContext = new EmployeeDataContext())
            {
                EmpDBContext.DeleteEmployee(Convert.ToInt32(idbox.Text));
                showallbutton_Click(sender, e);
                MessageBox.Show("deleted");
            }
            idbox.Clear(); namebox.Clear(); salarybox.Clear();

        }

        private void getdetailsbutton_Click(object sender, EventArgs e)
        {
            using (EmployeeDataContext EmpDBContext = new EmployeeDataContext())
            {
                var res = EmpDBContext.GETDETAILS(Convert.ToInt32(idbox.Text));
                dataGridView1.DataSource = res;
            }
            idbox.Clear();namebox.Clear();salarybox.Clear();
        }
    }
}