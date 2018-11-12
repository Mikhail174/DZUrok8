using System;
using System.Data.SqlClient;
using System.Data;

namespace Zad0_
{
    class Program
    {
         
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=МИХАИЛ-ПК\MSSQLSERVER1;Initial Catalog=ShopDB;Integrated Security=True";
            string sql = " Select * FROM Employees;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable employees = ds.Tables[0];
               // DataTable employees = ds.Tables[1];
               //// добавим новую строку
               //DataRow newRow = customers.NewRow();
               // newRow["FName"] = "x";
               // newRow["LName"] = "x";
               // newRow["Address1"] = "x";
               // newRow["City"] = "x";
               // newRow["Phone"] = "x";

               // customers.Rows.Add(newRow);



                // создаем объект SqlCommandBuilder

                //adapter.Update(ds);
                //альтернативный способ -обновление только одной таблицы
                //adapter.Update(dt);
                //заново получаем данные из бд
                //очищаем полностью DataSet
                //  ds.Clear();
                //перезагружаем данные
                //   adapter.Fill(ds);

                // добавим новую строку
                DataRow newRow1 = employees.NewRow();
                newRow1["EmployeeID"] = 102;
                newRow1["FName"] = "x";
                newRow1["LName"] = "x";
                newRow1["MName"] = "x";
                newRow1["Salary"] = 111;
                newRow1["PriorSalary"] = 111;
                newRow1["HireDate"] = "9999 / 12 / 31";
                newRow1["ManagerEmpID"] = 5;
                employees.Rows.Add(newRow1);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                ds.Clear();
                adapter.Fill(ds);
                connection.Close();


                //foreach (DataColumn column in dt.Columns)
                //    Console.Write("\t{0}", column.ColumnName);
                //Console.WriteLine();
                //// перебор всех строк таблицы
                //foreach (DataRow row in dt.Rows)
                //{
                //    // получаем все ячейки строки
                //    var cells = row.ItemArray;
                //    foreach (object cell in cells)
                //        Console.Write("\t{0}", cell);
                //    Console.WriteLine();
                //}
            }
            Console.Read();
        }
    }
}

