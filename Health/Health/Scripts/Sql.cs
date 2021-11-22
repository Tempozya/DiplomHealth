using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace SqlConn
{
    public static class Sql
    {
        public static MySqlConnection Connection()
        {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "c9113991.beget.tech";
            conn_string.Port = 3306;
            conn_string.UserID = "c9113991_health";
            conn_string.Password = "Xaker1415";
            conn_string.Database = "c9113991_health";


            MySqlConnection MyCon = new MySqlConnection(conn_string.ToString());


            return MyCon;
        }


    }
}
