using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Zad0.Dialogs;

namespace Zad0
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=МИХАИЛ-ПК\MSSQLSERVER1;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString1 = "SELECT * FROM Customers";
        string commandString2 = "SELECT * FROM Employees";

        SqlDataAdapter adapter1;
        SqlDataAdapter adapter2;
        SqlCommandBuilder commandBuilder;
        DataSet shopDB = new DataSet();


        DataTable customers;
        DataTable employees;

        public Form1()
        {
            InitializeComponent();
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            adapter1 = new SqlDataAdapter(commandString1, connectionString);
            adapter1.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapter1.TableMappings.Add("Table", "Customers");
            adapter1.Fill(shopDB, "Customers");
            customers = shopDB.Tables["Customers"];
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = customers;


            adapter2 = new SqlDataAdapter(commandString2, connectionString);
            adapter2.TableMappings.Add("Table", "Employees");
            
            adapter2.Fill(shopDB, "Employees");
            employees = shopDB.Tables["Employees"];

            dataGridView2.ReadOnly = true;
            dataGridView2.DataSource = employees;
        }
        

        public void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = new AddCustomerDialog(customers).ShowDialog();
            commandBuilder = new SqlCommandBuilder(adapter1);
            adapter1.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter1.Update(shopDB,"Customers");
            customers.Clear();
            adapter1.Fill(shopDB);

        }



        private void button2_Click(object sender, EventArgs e)
        {
            var editDialog = new EditCustomerDialog(customers,(dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row);
            editDialog.ShowDialog();
            commandBuilder = new SqlCommandBuilder(adapter1);
            adapter1.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter1.Update(shopDB, "Customers");
            customers.Clear();
            adapter1.Fill(shopDB);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены что хотите удалить этого клиента?", "DeleteDialog", MessageBoxButtons.OKCancel);

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                var rowToDelete = (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row;
                rowToDelete.Delete();
                commandBuilder = new SqlCommandBuilder(adapter1);
                adapter1.UpdateCommand = commandBuilder.GetUpdateCommand();
                adapter1.Update(shopDB, "Customers");
                customers.Clear();
                adapter1.Fill(shopDB);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = new AddEmployeeDialog(employees).ShowDialog();
            commandBuilder = new SqlCommandBuilder(adapter2);
          //  adapter2.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter2.Update(shopDB,"Employees");
            employees.Clear();
            adapter2.Fill(shopDB);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var editDialog = new EditEmployeeDialog(employees, (dataGridView2.CurrentRow.DataBoundItem as DataRowView).Row);
            editDialog.ShowDialog();
            commandBuilder = new SqlCommandBuilder(adapter2);
            adapter2.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter2.Update(shopDB, "Employees");
            employees.Clear();
            adapter2.Fill(shopDB);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены что хотите удалить этого клиента?", "DeleteDialog", MessageBoxButtons.OKCancel);

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                var rowToDelete = (dataGridView2.CurrentRow.DataBoundItem as DataRowView).Row;
                rowToDelete.Delete();
                commandBuilder = new SqlCommandBuilder(adapter2);
                adapter2.UpdateCommand = commandBuilder.GetUpdateCommand();
                adapter2.Update(shopDB, "Employees");
                employees.Clear();
                adapter2.Fill(shopDB);

            }
        }
    }
}
