using System;
using System.Data;
using System.Windows.Forms;
//using Updates.Commands;

namespace Zad0.Dialogs
{
    public partial class EditCustomerDialog : Form
    {
        DataTable table;
        DataRow rowToEdit;
        public EditCustomerDialog(DataTable table, DataRow rowToEdit)
        {
            InitializeComponent();
            this.rowToEdit = rowToEdit;
            this.table = table;

            CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rowToEdit["FName"] = textBox1.Text;
                rowToEdit["LName"] = textBox2.Text;
                rowToEdit["Address1"] = textBox3.Text;
                rowToEdit["City"] = textBox4.Text;
                rowToEdit["Phone"] = textBox5.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();

        }

        private void EditCustomerDialog_Load(object sender, EventArgs e)
        {
            textBox1.Text = rowToEdit["FName"].ToString();
            textBox2.Text = rowToEdit["LName"].ToString();
            textBox3.Text = rowToEdit["Address1"].ToString();
            textBox4.Text = rowToEdit["City"].ToString();
            textBox5.Text = rowToEdit["Phone"].ToString();
        }
    }
}
