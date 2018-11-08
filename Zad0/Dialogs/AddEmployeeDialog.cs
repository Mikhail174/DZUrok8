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
            newRow["EmployeeID"] = 12;
            newRow["MName"] = "asdad";
            newRow["PriorSalary"] = 600;
            newRow["FName"] = textBox1.Text.Count() == 0 ? null : textBox1.Text;
            newRow["LName"] = textBox2.Text.Count() == 0 ? null : textBox2.Text;
            newRow["TerminationDate"] = textBox3.Text.Count() == 0 ? null : textBox3.Text;
            newRow["Salary"] = textBox4.Text.Count() == 0 ? null : textBox4.Text;
            newRow["HireDate"] = textBox5.Text.Count() == 0 ? null : textBox5.Text;
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
