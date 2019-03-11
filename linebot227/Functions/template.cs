using isRock.LineBot;
using linebot227.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace linebot227.Functions
{
    public class template
    {
        const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "U8168367ec76c449dbdd98410d9333b8b";
        const string SendTo = "U8168367ec76c449dbdd98410d9333b8b";
        public static void LoginTemplete(ButtonTemplateParameter ButtonTemplateParameter)
        {
            var bot = new Bot(channelAccessToken);
            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            //actions.Add(new isRock.LineBot.MessageAction()
            //{ label = "首次登入", text = "首次登入" });
            //actions.Add(new isRock.LineBot.MessageAction()
            //{ label = "點選這邊等同用戶直接輸入某訊息", text = ButtonTemplateFunction.LineEvent });
            actions.Add(new isRock.LineBot.UriAction()
            { label = "首次登入", uri = new Uri("http://kaiwen1995.com:3001/closeKai") });
            actions.Add(new isRock.LineBot.UriAction()
            { label = "設定推播訊息", uri = new Uri("https://kaiwen.azurewebsites.net/?name=" + ButtonTemplateParameter.LineID) });



            //單一Button Template Message
            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            {
                altText = "個人設定",
                text = "Text",
                //title = "Title",
                //設定圖片
                thumbnailImageUrl = new Uri("https://cdn0.iconfinder.com/data/icons/linkedin-ui-colored/48/JD-12-512.png"),
                actions = actions //設定回覆動作
            };

            //發送
            bot.PushMessage(SendTo, ButtonTemplate);
        }
        public static void BuildingStatusTemplete(ButtonTemplateParameter ButtonTemplateParameter)
        {
            var bot = new Bot(channelAccessToken);
            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            //actions.Add(new isRock.LineBot.MessageAction()
            //{ label = "首次登入", text = "首次登入" });
            //actions.Add(new isRock.LineBot.MessageAction()
            //{ label = "點選這邊等同用戶直接輸入某訊息", text = ButtonTemplateFunction.LineEvent });
            actions.Add(new isRock.LineBot.UriAction()
            { label = "6F 監看", uri = new Uri(ButtonTemplateParameter.ViewURL1) });
            actions.Add(new isRock.LineBot.UriAction()
            { label = "4F 監看", uri = new Uri(ButtonTemplateParameter.ViewURL2) });



            //單一Button Template Message
            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            {
                altText = "監看狀態",
                text = "Text",
                //title = "Title",

                //設定圖片
                thumbnailImageUrl = new Uri("https://cdn0.iconfinder.com/data/icons/linkedin-ui-colored/48/JD-12-512.png"),
                actions = actions //設定回覆動作
            };

            //發送
            bot.PushMessage(SendTo, ButtonTemplate);
        }
    }
}