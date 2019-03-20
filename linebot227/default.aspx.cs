using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linebot227.Models;
using linebot227.Functions;

namespace linebot227
{
    public partial class _default : System.Web.UI.Page
    {
        isRock.LineBot.Bot bot = null;
        const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U8168367ec76c449dbdd98410d9333b8b";
        //string channelAccessToken = "";
        //string AdminUserId = "";
        // public object Label2;
        public string Label2 { get; private set; }
        public string Label1 { get; private set; }
        public SQLcontroller sql = new SQLcontroller("61.216.65.239", "mydb", "sa", "leegood");

        protected void Page_Load(object sender, EventArgs e)
        { 
            Label2 = Request.QueryString["name"];
            //bot = new isRock.LineBot.Bot(this.);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
            //bot.PushMessage(AdminUserId, Label2);
            string s_url;
            s_url = "?name=" + Label2;
            Response.Redirect(s_url);     //queryString 使用完後重新導向新的網站
        }
        //test WebForm
        //protected void ChannelAccessToken(object sender, EventArgs e)
        //{

        //}
        //protected void UserIDTxb(object sender, EventArgs e)s
        //{

        //}
        //protected void MessageTxb(object sender, EventArgs e)
        //{

        //}
        //protected void SendMessageBT(object sender, EventArgs e)
        //{
        //    var bot = new Bot(this.ChannelAccessTokenTxb.Text);
        //    bot.PushMessage(AdminUserId, 1, 2);
        //}
        //test SQL
        protected void Button2_selectSQL(object sender, EventArgs e)
        {
            //var bot = new Bot(channelAccessToken);
            //bot.PushMessage(AdminUserId, 1,2);

            //var sql = new SQLcontroller("61.216.65.239", "mydb", "sa", "leegood");
            Console.WriteLine(sql.GetMemberInfo());

            //MemberInfo mi = new MemberInfo();
            //mi.Email = "leegood@gmail.com";
            //mi.Name = "leegood";
            //mi.LineID = "ouyr2345jhxcvncc";
            //mi.Valid = "not yet";
            //mi.AuthTime = DateTime.Now;
            //sql.InsertMemberInfo(mi);

        }

        protected void Button4_deleteSQL(object sender, EventArgs e)
        {
            sql.DeleteMemberInfo(9);
        }

        protected void Button5_insertSQL(object sender, EventArgs e)
        {
            var sql = new SQLcontroller("61.216.65.239", "mydb", "sa", "leegood");
            sql.InsertMemberInfo(new MemberInfo
            {
                Email = "123@gmail.com",
                Name = "kaiiak",
                LineID = "23456789qwertyuisdfghj",
                Valid = "OK",
                AuthTime = DateTime.Now
            });
            //Mail_Server.MailController.SendEmail();
        }

        protected void Button4_sendMail(object sender, EventArgs e)
        {
            //Mail_Server.MailController.SendEmail();
        }

        protected void Button_SendButtonTemplate_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.MessageAction()
            { label = "點選這邊等同用戶直接輸入某訊息", text = "/例如這樣" });
            actions.Add(new isRock.LineBot.UriAction()
            { label = "點這邊開啟網頁", uri = new Uri("http://www.google.com") });
            actions.Add(new isRock.LineBot.PostbackAction()
            { label = "點這邊發生postack", data = "abc=aaa&def=111" });

            
            //單一Button Template Message
            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            {
                altText = "替代文字(在無法顯示Button Template的時候顯示)",
                text = "Text",
                title = "Title",
                //設定圖片
                thumbnailImageUrl = new Uri("https://scontent-tpe1-1.xx.fbcdn.net/v/t31.0-8/15800635_1324407647598805_917901174271992826_o.jpg?oh=2fe14b080454b33be59cdfea8245406d&oe=591D5C94"),
                actions = actions //設定回覆動作
            };

            //發送
            bot.PushMessage(AdminUserId, ButtonTemplate);
        }
    }
}