using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Zad0.Dialogs
{
    public partial class AddEmployeeDialog : Form
    {
        DataTable table;
        public AddEmployeeDialog(DataTable table)
        {
            this.table = table;
            InitializeComponent();
        }

        private void AddEmployeeDialog_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow newRow = table.NewRow();
            newRow["EmployeeID"] = textBox1.Text.Count() == 0 ? null : textBox1.Text;
            newRow["FName"] = textBox2.Text.Count() == 0 ? null : textBox2.Text;
            newRow["LName"] = textBox3.Text.Count() == 0 ? null : textBox3.Text;
            newRow["MName"] = textBox4.Text.Count() == 0 ? null : textBox4.Text;
            newRow["Salary"] = textBox5.Text.Count() == 0 ? null : textBox5.Text;
            newRow["PriorSalary"] = textBox6.Text.Count() == 0 ? null : textBox6.Text;
            newRow["HireDate"] = textBox7.Text.Count() == 0 ? null : textBox7.Text;
            newRow["ManagerEmpID"] = textBox8.Text.Count() == 0 ? null : textBox8.Text;

            try
            {
                table.Rows.Add(newRow);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }


    }
}
