using System;
using System.Data;
using System.Windows.Forms;
//using Updates.Commands;

namespace Zad0.Dialogs
{
    public partial class EditEmployeeDialog : Form
    {
        DataTable table;
        DataRow rowToEdit;
        public EditEmployeeDialog(DataTable table, DataRow rowToEdit)
        {
            InitializeComponent();
            this.rowToEdit = rowToEdit;
            this.table = table;

            CenterToScreen();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                rowToEdit["EmployeeID"] = textBox1.Text;
                rowToEdit["Fname"] = textBox2.Text;
                rowToEdit["LName"] = textBox3.Text;
                rowToEdit["MName"] = textBox4.Text;
                rowToEdit["Salary"] = textBox5.Text;
                rowToEdit["PriorSalary"] = textBox6.Text;
                rowToEdit["HireDate"] = textBox7.Text;
                rowToEdit["ManagerEmpID"] = textBox8.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();

        }
    }
}