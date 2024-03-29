﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommoditySalesManagementSystem
{
    static class SqlManager
    {
        const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CSMS_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static SqlConnection Connection = new SqlConnection(ConnectionString);

        // static SqlManager() { }

        /// <summary>
        /// 执行SQL指令，返回受影响行数
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int ExecuteCommand(string command)
        {
            SqlCommand com = new SqlCommand(command, Connection);
            try { Connection.Open(); return com.ExecuteNonQuery(); } catch (Exception) { throw; } finally { Connection.Close(); }
        }
        
        public static SqlDataReader Read(string sql, bool autoClose = true)
        {
            return SqlRead(sql, autoClose);
        }

        /// <summary>
        /// 读列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static List<string> ReadColumn(string sql, string columnName)
        {
            SqlDataReader read = Read(sql, false);
            List<string> itemList = new List<string>();
            try
            {
                while (read.Read())
                    itemList.Add(read[columnName].ToString());
            }
            catch (Exception) { throw; }
            finally { Connection.Close(); }
            return itemList;
        }

        private static SqlDataReader SqlRead(string sqlString, bool autoClose = false)
        {
            SqlCommand com = new SqlCommand(sqlString, Connection);
            try
            {
                Connection.Open();
                SqlDataReader read = com.ExecuteReader();
                return read;
            }
            catch (Exception) { throw; }
            finally { if(autoClose) Connection.Close(); }
        }

        /// <summary>
        /// 执行查询，并返回由查询返回的结果集中的第一行的第一列。 其他列或行将被忽略。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            try { Connection.Open(); return command.ExecuteScalar(); /*执行查询语句,返回匹配的行数*/ }
            catch (Exception) { throw; }
            finally { Connection.Close(); }
        }
    }
}
