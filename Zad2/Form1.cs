using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zad2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=WKS456\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
        string commandString = "SELECT * FROM Employees";
        DataTable employees = new DataTable("Employees");
        SqlDataAdapter adapter;

        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter(commandString, connectionString);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ConfigureCustomersAdapter(adapter);
            adapter.FillSchema(employees, SchemaType.Mapped);
            adapter.Fill(employees);
            dataGridView1.DataSource = employees;
            adapter.RowUpdated +=adapter_RowUpdated;
        }
        void adapter_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                var insertedRow = e.Row;

                try
                {
                    insertedRow.Table.Columns[0].ReadOnly = false;

                    insertedRow[0] = e.Command.Parameters["NewCustomerNo"].Value;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    insertedRow.Table.Columns[0].ReadOnly = true;
                }
            }
        }
    }
}
