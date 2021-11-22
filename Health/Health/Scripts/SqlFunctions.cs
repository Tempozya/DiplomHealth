using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySqlConnector;
using SqlConn;

namespace SqlFunction
{
    internal class SqlF
    {
        static MySqlConnection conn = Sql.Connection();


        public static bool LoginUser(string login, string password)
        {
            bool flag = false;
            string sql = string.Format("SELECT * FROM users WHERE login = @uL AND pass = @uP;");
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = password;

            conn.Open();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                flag = true;




            conn.Close();
            return flag;
        }

        public static bool RegUser(string login, string password, string email)
        {
            bool flag = false;


            string sql = string.Format("INSERT INTO users(login,pass,email) VALUES (@uLogin, @uPass, @uEmail)");


            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@uLogin", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@uPass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@uEmail", MySqlDbType.VarChar).Value = email;

            conn.Open();

            if (command.ExecuteNonQuery() == 1)
            {
                flag = true;
            }

            conn.Close();
            return flag;
        }


    }
}
