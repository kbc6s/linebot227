using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace linebot227
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U8168367ec76c449dbdd98410d9333b8b";
        const string SendTo = "U8168367ec76c449dbdd98410d9333b8b";
       // public object Label2;
        public string Label2 { get; private set; }
        public string Label1 { get; private set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            Label2 = Request.QueryString["name"];
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
            //bot.PushMessage(AdminUserId, Label2);
            string s_url;
            s_url = "?name=" + Label2;
            Response.Redirect(s_url);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }

        protected void Button4_sendMail(object sender, EventArgs e)
        {
            Mail_Server.MailController.SendEmail();
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
            bot.PushMessage(SendTo, ButtonTemplate);
        }
    }
}