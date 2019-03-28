using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linebot227.Functions;
using System.Data.SqlClient;
using Dapper;


namespace linebot227
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
                LoadData("select * from [dbo].[MemberInfo] where [Valid] is NULL");
            }
        }


        //public void LoadData()
        //{
        //    try
        //    {
        //        string strConnection = "server = 127.0.0.1; database = mydb; uid = sa; pwd = leegood#09477027; Connect Timeout=1;";
        //        //var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
        //        using (SqlConnection conn = new SqlConnection(strConnection))
        //        {
        //            conn.Open();
        //            using (SqlCommand command = new SqlCommand("select * from [dbo].[MemberInfo] where [Valid] is NULL", conn))
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                this.PersonData.DataSource = reader;
        //                this.PersonData.DataBind();
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public void LoadData(string method)
        {
            try
            {
                string strConnection = "server = 127.0.0.1; database = mydb; uid = sa; pwd = leegood#09477027; Connect Timeout=1;";
                //var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(method, conn))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        this.PersonData.DataSource = reader;
                        this.PersonData.DataBind();
                        //this.PersonData.
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void SearchMember(object sender, EventArgs e)
        {
            var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
            string name = "";
            name = searchNameTxb.Text;
            var result = sql.CheckMember(name);

            if (result.Count != 0)
            {
                Label2.Visible = true;
                Label3.Visible = true;
                Button1.Visible = true;
                Label2.Text = result[0].Seq.ToString();
                Label3.Text = result[0].Name + "  " + result[0].Email;
            }
            else
            {
                Label2.Visible = false;
                Label3.Visible = true;
                Button1.Visible = false;
                Label3.Text = "查無資料";
            }

            //Label2.Text = result.;
        }
        public void verify(object sender, EventArgs e)
        {
            var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
            if (sql.UpdateMemberInfo(Label2.Text))
            {
                Button1.BackColor = System.Drawing.Color.Green;
            }
            //var result = sql.UpdateMemberInfo()
        }
        
    }
}