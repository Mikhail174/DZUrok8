using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Zad2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=МИХАИЛ-ПК\MSSQLSERVER1;Initial Catalog=ShopDB;Integrated Security=True";
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
            ConfigureEmployeesAdapter(adapter);
            adapter.FillSchema(employees, SchemaType.Mapped);
            adapter.Fill(employees);
            dataGridView1.DataSource = employees;
            adapter.RowUpdated += adapter_RowUpdated;
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
                    insertedRow.Table.Columns[0].ReadOnly = true; //
                }
            }
        }
        private static void ConfigureEmployeesAdapter(SqlDataAdapter employeesAdapter)
        {
            #region Configure UpdateCommand

            string commandString = "UPDATE Employees " +
                              "SET EmployeeID = @EmployeeID," +
                              "FName = @FName," +
                              "LName= @Lname," +
                              "MName = @MName," +
                              "Salary = @Salary," +
                              "PriorSalary = @PriorSalary," +
                              "HireDate = @HireDate," +
                              "ManagerEmpID = @ManagerEmpID " +
                              "WHERE EmployeeID = @EmployeeID";

            employeesAdapter.UpdateCommand = new SqlCommand(commandString,
                                                            employeesAdapter.SelectCommand.Connection);

            var updateParameters = employeesAdapter.UpdateCommand.Parameters;
            updateParameters.Add("EmployeeID", SqlDbType.Int, 0, "EmployeeID");
            updateParameters.Add("FName", SqlDbType.NVarChar, 20, "FName");
            updateParameters.Add("LName", SqlDbType.NVarChar, 20, "Lname");
            updateParameters.Add("MName", SqlDbType.NVarChar, 20, "MName");
            updateParameters.Add("Salary", SqlDbType.Int, 20, "Salary");
            updateParameters.Add("PriorSalary", SqlDbType.Int, 20, "PriorSalary");
            updateParameters.Add("HireDate", SqlDbType.DateTime, 20, "HireDate");
            updateParameters.Add("ManagerEmpID", SqlDbType.Int, 20, "ManagerEmpID");
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.Update(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
