using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoTest;

namespace ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select * from Students ");
            foreach (DataRow row in dt.Rows)
            {
                {
                    Console.WriteLine(row["FirstName"].ToString() + " " + row["LastName"]);

                }
            }

            Console.ReadKey();


        }
        static void Test1()
        {
            using (SqlConnection connection = new SqlConnection(DataProvider.Instance.Connect()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectStudent", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@id", 6);

                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Int32;
                command.Parameters.Add(param);
                //command.Parameters.AddWithValue("@id",6);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row[1]);
                }
                connection.Close();
            }
        }
    }
}
