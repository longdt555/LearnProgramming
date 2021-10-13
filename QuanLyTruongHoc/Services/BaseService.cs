using QuanLyTruongHoc.Helper;
using System;
using System.Data.SqlClient;
using static QuanLyTruongHoc.Helper.Helper;

namespace QuanLyTruongHoc.Services
{
    public class BaseService
    {
        public static SqlConnection CreateConnection()
        {

            var datasource = @"DESKTOP-RBNM78Q\SQLEXPRESS";//your server
            var database = "Quan_Ly_Truong_Hoc"; //your database name
            var username = "sa"; //username of server to connect
            var password = "22082003"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                //open connection
                conn.Open();
                return conn;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }

        public int ExcuteQuery(string sqlQuery)
        {
            var conn = CreateConnection();
            if (conn == null)
                return -1;
            else
            {
                try
                {
                    using SqlCommand command = new SqlCommand(sqlQuery, conn); //pass SQL query created above and connection
                    return command.ExecuteNonQuery(); //execute the Query
                }
                catch
                {
                    return 0;
                }
            }
        }

        public class Add : BaseService
        {
            public void AddValue(string table, string nameStudent, int ageStudent)
            {
                string querySqlAdd = string.Format(Queries.Insert, table, "name,age", $"{CombineQuery(nameStudent)}, {CombineQuery(ageStudent)}");
                var result = ExcuteQuery(querySqlAdd);
                if (result == 0)
                {
                    Console.WriteLine("Lỗi Query");
                }
                if (result == -1)
                {
                    Console.WriteLine("Không connect được đến server");
                }
                if (result > 0)
                {
                    Console.WriteLine("Add Successfully");
                }

            }
        }
        public class Update : BaseService
        {
            public void UpdateValue(string table, string column1, string newName, string column2, int newAge, int id)
            {
                string querySqlUpdate = $"UPDATE {table} SET {column1} = {CombineQuery(newName)}, {column2} = {newAge} WHERE id = {id}";
                var result = ExcuteQuery(querySqlUpdate);
                if (result == 0)
                {
                    Console.WriteLine("Lỗi Query");
                }
                if (result == -1)
                {
                    Console.WriteLine("Không connect được đến server");
                }
                if (result > 0)
                {
                    Console.WriteLine("Update Successfully");
                }
            }
        }
        public class Delete : BaseService
        {
            public void DeleteById(string value, int id)
            {
                string querySqlDelete = string.Format(Queries.DeleteById, value, CombineQuery(id));
                var result = ExcuteQuery(querySqlDelete);
                if (result == 0)
                {
                    Console.WriteLine("Lỗi Query");
                }
                if (result == -1)
                {
                    Console.WriteLine("Không connect được đến server");
                }
                if (result > 0)
                {
                    Console.WriteLine("Delete Successfully");
                }
            }
        }
        public class AddClass : BaseService
        {
            public void AddValue(string table, string name, string subject)
            {
                string querySqlAddClass = string.Format(Queries.Insert, table, "name,subject", $"{CombineQuery(name)}, {CombineQuery(subject)}");
                var result = ExcuteQuery(querySqlAddClass);
                if (result == 0)
                {
                    Console.WriteLine("Lỗi Query");
                }
                if (result == -1)
                {
                    Console.WriteLine("Không connect được đến server");
                }
                if (result > 0)
                {
                    Console.WriteLine("Add Successfully");
                }

            }
        }
        public class UpdateClass : BaseService
        {
            public void UpdateValue(string table, string column1, string newName, string column2, string newSubject, int id)
            {
                string querySqlUpdateClass = $"UPDATE {table} SET {column1} = {CombineQuery(newName)}, {column2} = {CombineQuery(newSubject)} WHERE id = {id}";
                var result = ExcuteQuery(querySqlUpdateClass);
                if (result == 0)
                {
                    Console.WriteLine("Lỗi Query");
                }
                if (result == -1)
                {
                    Console.WriteLine("Không connect được đến server");
                }
                if (result > 0)
                {
                    Console.WriteLine("Update Successfully");
                }
            }
        }
    }
}
