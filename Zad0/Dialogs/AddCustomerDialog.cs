using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Zad0.Dialogs
{
    public partial class AddCustomerDialog : Form
    {
        DataTable table;
        public AddCustomerDialog(DataTable table)
        {
            this.table = table;
            InitializeComponent();
        }
        private void AddCustomerDialog_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataRow newRow = table.NewRow();
            newRow["FName"] = textBox1.Text.Count() == 0 ? null : textBox1.Text;
            newRow["LName"] = textBox2.Text.Count() == 0 ? null : textBox2.Text;
            newRow["Address1"] = textBox3.Text.Count() == 0 ? null : textBox3.Text;
            newRow["City"] = textBox4.Text.Count() == 0 ? null : textBox4.Text;
            newRow["Phone"] = textBox5.Text.Count() == 0 ? null : textBox5.Text;
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
