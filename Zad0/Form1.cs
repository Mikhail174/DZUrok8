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
        string connectionString = @"Data Source=WKS456\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Customers; SELECT * FROM Orders; SELECT * FROM OrderDetails;SELECT * FROM Products; SELECT * FROM Employees;";
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;



        DataSet shopDB = new DataSet("ShopDB");
        DataTable customers;
        DataTable orders;
        DataTable orderDetails;
        DataTable products;
        DataTable employees;

        public Form1()
        {
            InitializeComponent();
        }


        public void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();

                adapter = new SqlDataAdapter(commandString, connectionString);
                 adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                  adapter.Fill(shopDB);
                customers = shopDB.Tables[0];
                orders = shopDB.Tables[1];
                orderDetails = shopDB.Tables[2];
                products = shopDB.Tables[3];
                employees = shopDB.Tables[4];
                dataGridView1.ReadOnly = true;
                dataGridView2.ReadOnly = true;
                dataGridView1.DataSource = customers;
                dataGridView2.DataSource = employees;

        }
        

        public void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = new AddCustomerDialog(customers).ShowDialog();
            commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(customers);
            customers.Clear();
            adapter.Fill(shopDB);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult result = new AddEmployeeDialog(employees).ShowDialog();
            commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(employees);
            employees.Clear();
            adapter.Fill(shopDB); 


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var editDialog = new EditCustomerDialog(customers, (dataGridView1.CurrentRow.DataBoundItem as DataRowView).Row);
            editDialog.ShowDialog();
            adapter.Update(customers);

        }

        private void button5_Click(object sender, EventArgs e)
        {
           // var editDialog = new EditEmployeeDialog(employees, (dataGridView2.CurrentRow.DataBoundItem as DataRowView).Row);
            //editDialog.ShowDialog();
            //adapter.Update(employees);

        }
    }
}
