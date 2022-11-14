﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_care
{
    class Function
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataAdapter sda;
        private DataTable data;
        private string connstr;

        public Function()
        {
            connstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\HP\Documents\Health care systemDB.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(connstr);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public DataTable GetData(string Query)
        {
            data = new DataTable();
            sda = new SqlDataAdapter(Query, con);
            sda.Fill(data);
            return data;
        }
        public int SetData(string Query)
        {
            int cnt = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();
            con.Close();
            return cnt;
        }
    }
}
