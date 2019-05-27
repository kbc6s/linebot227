using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using isRock.LineBot;
using Dapper;
using linebot227.Functions;
using linebot227.Models;
using System.Web.Routing;
using System.Net.Http; 
using System.IO;
using Newtonsoft.Json;

namespace linebot227
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public string Label2 { get; private set; }
        public string Label1 { get; private set; }
        //isRock.LineBot.Bot Bot = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2 = Request.QueryString["name"];
        }
        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.MapPageRoute("products-browse", "products/{verder}", "~/product.aspx"
                    , true, new RouteValueDictionary { { "verder", "apple" } });

            }
        }
        protected void RestFul(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var uri = $"http://192.168.3.81:3000";
            HttpResponseMessage response = client.GetAsync(uri).Result;
            
        }
        //select SQL
        //protected void selectSQL(object sender, EventArgs even)
        //{
        //    var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
        //    string LineID = "'U8168367ec76c449dbdd98410d9333b8b'";
        //    var reerer = sql.GetMemberInfo(Txb2.Text);
        //    if (reerer.Count == 3)
        //    {
        //        kai.Text = "沒有權限";
        //    }
        //    else
        //    {
        //        kai.Text = "pass";
        //    }
        //}

        //insert Member info to SQL
        protected void insertSQL(object sender, EventArgs e)
        {
            //string queryString_url;
            //queryString_url = "?name=" + Label2;
            //Response.Redirect(queryString_url);     //queryString 使用完後重新導向新的網站
            //var bot = new isRock.LineBot.Bot();
            var name = Txb1.Text;
            var mail = Txb2.Text;
            if(name == "" || mail == "")
            {
                kai.Text = "不能空白喔";
                return;
            }
            //var message = Txb3.Text;
            var sql = new SQLcontroller("192.168.3.247", "mydb", "leegood", "leegood");

            var result = sql.CheckMember(Label2);
            if (result.Count == 0)
            {
                sql.InsertMemberInfo(new MemberInfo
                {
                    Email = mail,
                    Name = name,
                    LineID = Label2,
                    //Valid = "",
                    AuthTime = DateTime.Now
                });
                kai.Text = "申請成功!";
            }
            else
            {
                kai.Text = "重複的帳號";
            }
        }
    }
}