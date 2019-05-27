using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
using linebot227.Models;

namespace linebot227.Functions
{
    public class SQLcontroller
    {
        //連接SQL時需要用到的欄位
        string strConnection = "";
        public SQLcontroller(string Host, string DB, string User, string Password)
        {
            strConnection = string.Format("server = {0}; database = {1}; uid = {2}; pwd = {3}; Connect Timeout=1;", Host, DB, User, Password);
        }

        //select
        //搜尋LineID + 權限
        public List<MemberInfo> CheckMember(string LineID, string Role)
        {
            //ServerInfo Info = new ServerInfo();
            List<MemberInfo> results = null;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                //string strSql = "SELECT [Seq],[Email],[Name],[LineID],[Valid],[AuthTime] FROM[mydb].[dbo].[MemberInfo]";
                string strSql = "SELECT [LineID] FROM[mydb].[dbo].[MemberInfo] where [LineID] = '" + LineID + "' and [Valid]=" + Role;
                results = conn.Query<MemberInfo>(strSql).ToList();
            }
            return results;
        }

        //搜尋LineID
        public List<MemberInfo> CheckMember(string SearchItem)
        {
            List<MemberInfo> results = null;
            if (SearchItem.Count() == 33)
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    //string strSql = "SELECT [Seq],[Email],[Name],[LineID],[Valid],[AuthTime] FROM[mydb].[dbo].[MemberInfo]";
                    string strSql = "SELECT * FROM[mydb].[dbo].[MemberInfo] where [LineID] = '" + SearchItem + "'";
                    results = conn.Query<MemberInfo>(strSql).ToList();
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    //string strSql = "SELECT [Seq],[Email],[Name],[LineID],[Valid],[AuthTime] FROM[mydb].[dbo].[MemberInfo]";
                    string strSql = "SELECT * FROM[mydb].[dbo].[MemberInfo] where [Name] = '" + SearchItem + "'";
                    results = conn.Query<MemberInfo>(strSql).ToList();
                }
            }
            
            
            return results;
        }

        //搜尋名子 + 權限
        public List<MemberInfo> CheckMember(string name,int role)
        {
            string[] memberType = new string[] { "is NULL", "'ok'" };
            //ServerInfo Info = new ServerInfo();
            List<MemberInfo> results = null;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                //string strSql = "SELECT [Seq],[Email],[Name],[LineID],[Valid],[AuthTime] FROM[mydb].[dbo].[MemberInfo]";
                string strSql = "SELECT * FROM [mydb].[dbo].[MemberInfo] where [Name] = '" + name + "' and [Valid] " + memberType[role] ;
                results = conn.Query<MemberInfo>(strSql).ToList();
            }
            return results;
        }
        //select 出一個list
        //public List<MemberInfo> LoadData()
        //{
        //    //ServerInfo Info = new ServerInfo();
        //    List<MemberInfo> results = null;
        //    using (SqlConnection conn = new SqlConnection(strConnection))
        //    {
        //        //string strSql = "SELECT [Seq],[Email],[Name],[LineID],[Valid],[AuthTime] FROM[mydb].[dbo].[MemberInfo]";
        //        string strSql = "select * [mydb].[dbo].[MemberInfo] where [role] is NULL";
        //        results = conn.Query<MemberInfo>(strSql).ToList();
        //    }
        //    return results;
        //}

        //insert
        public bool InsertMemberInfo(MemberInfo member)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string strSql = "INSERT INTO MemberInfo(Email,Name,LineID,Valid,AuthTime) VALUES (@Email,@Name,@LineID,@Valid,@AuthTime);";
                var result = conn.Execute(strSql, member);
                if (result == 1)
                    return true;
            }
            return false;
        }
        public bool InsertLogTime(LogInfo log)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string strSql = "INSERT INTO logTime(LineID,AuthTime,Event) VALUES (@LineID,@AuthTime,@Event);";
                var result = conn.Execute(strSql, log);
                if (result == 1)
                    return true;
            }
            return false;
        }
        //delete
        public bool DeleteMemberInfo(int seq)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string strSql = "DELETE MemberInfo WHERE seq = " + seq.ToString();

                var result = conn.Execute(strSql);
                if (result == 1)
                    return true;
            }
            return false;
        }
        //update
        public bool UpdateMemberInfo(string seq)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string strSql = "UPDATE MemberInfo SET Valid = 'ok' WHERE seq = " + seq.ToString();
                var result = conn.Execute(strSql);
                if (result == 1)
                    return true;
            }
            return false;
        }
        //create Table
        public bool CreateMemberInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    string strSql = @"CREATE TABLE MemberInfo
                                (
                                [Seq] [bigint] NOT NULL IDENTITY(1,1) PRIMARY KEY,
                                [Email] [nchar] (100) NULL,
                                [Name] [nchar] (100) NULL,
                                [LineID] [nchar] (100) NULL,
                                [Valid] [nchar] (10) NULL,
                                [AuthTime] [datetime] NULL
                                 )";

                    conn.Execute(strSql);

                    return true;
                }
            }
            catch { return false; }
        }
    }
}