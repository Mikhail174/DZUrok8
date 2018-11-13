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
            ConfigureEmployeesAdapter(adapter);
            adapter.FillSchema(employees, SchemaType.Mapped);
            adapter.Fill(employees);
            dataGridView1.DataSource = employees;
        }

        private static void ConfigureEmployeesAdapter(SqlDataAdapter employeesAdapter)
        {
            #region Configure UpdateCommand

            string commandString = "UPDATE Employees " +
                              "SET EmployeeID = @EmployeeID," +
                              "FName = @FName," +
                              "LName= @LName," +
                              "MName = @MName," +
                              "Salary = @Salary," +
                              "PriorSalary = @PriorSalary," +
                              "HireDate = @HireDate," +
                              "ManagerEmpID = @ManagerEmpID " +
                              "WHERE EmployeeID = @EmployeeID";
            employeesAdapter.UpdateCommand = new SqlCommand(commandString,employeesAdapter.SelectCommand.Connection);
            var updateParameters = employeesAdapter.UpdateCommand.Parameters;
            updateParameters.Add("EmployeeID", SqlDbType.Int, 20, "EmployeeID");
            updateParameters.Add("FName", SqlDbType.NVarChar, 20, "FName");
            updateParameters.Add("LName", SqlDbType.NVarChar, 20, "LName");
            updateParameters.Add("MName", SqlDbType.NVarChar, 20, "MName");
            updateParameters.Add("Salary", SqlDbType.Int, 20, "Salary");
            updateParameters.Add("PriorSalary", SqlDbType.Int, 20, "PriorSalary");
            updateParameters.Add("HireDate", SqlDbType.DateTime, 20, "HireDate");
            updateParameters.Add("ManagerEmpID", SqlDbType.Int, 20, "ManagerEmpID");
            #endregion
            #region Configure DeleteCommand
            employeesAdapter.DeleteCommand = new SqlCommand("DELETE Employees WHERE EmployeeID = @EmployeeID",
                                            employeesAdapter.SelectCommand.Connection);
            var deleteParameters = employeesAdapter.DeleteCommand.Parameters;
            deleteParameters.Add("@EmployeeID", SqlDbType.Int, 20, "EmployeeID");
            #endregion
            #region Configure InsertCommand
            employeesAdapter.InsertCommand = new SqlCommand("INSERT Employees " +
                           "VALUES (@EmployeeID, @FName, @LName, @MName, @Salary, @PriorSalary, @HireDate, @TerminationDate, @ManagerEmpID);", employeesAdapter.SelectCommand.Connection);
            var insertParameters = employeesAdapter.InsertCommand.Parameters;
            insertParameters.Add("EmployeeID", SqlDbType.Int, 20, "EmployeeID");
            insertParameters.Add("FName", SqlDbType.NVarChar, 20, "FName");
            insertParameters.Add("LName", SqlDbType.NVarChar, 20, "LName");
            insertParameters.Add("MName", SqlDbType.NVarChar, 20, "MName");
            insertParameters.Add("Salary", SqlDbType.Int, 20, "Salary");
            insertParameters.Add("PriorSalary", SqlDbType.Int, 20, "PriorSalary");
            insertParameters.Add("HireDate", SqlDbType.DateTime, 20, "HireDate");
            insertParameters.Add("TerminationDate", SqlDbType.DateTime, 20, "TerminationDate");
            insertParameters.Add("ManagerEmpID", SqlDbType.Int, 20, "ManagerEmpID");
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
                MessageBox.Show(ex.Message); //////
            }
        }
    }
}
