using isRock.LineBot;
using linebot227.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace linebot227.Functions
{
    public class LineTemplate
    {
        const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
        const string SendTo = "U8168367ec76c449dbdd98410d9333b8b";

        //首次登入模板
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
            { label = "首次登入", uri = new Uri("https://9e90d783.ngrok.io/login.aspx?name=" + ButtonTemplateParameter.LineID) });
            //actions.Add(new isRock.LineBot.UriAction()
            //{ label = "設定推播訊息", uri = new Uri(https://9e90d783.ngrok.io/WebForm1.aspx" + ButtonTemplateParameter.LineID) });
            actions.Add(new isRock.LineBot.MessageAction()
            { label = "設定推播訊息", text="還沒做好喔@@" });



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
            bot.PushMessage(ButtonTemplateParameter.LineID, ButtonTemplate);
        }

        //樓宇監控模板
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
            actions.Add(new isRock.LineBot.PostbackAction()
            { label = "空調控制postback", data = "123456789" });


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
            bot.PushMessage(ButtonTemplateParameter.LineID, ButtonTemplate);
        }
        //遠端控制
        public static void RemoteController(ButtonTemplateParameter ButtonTemplateParameter)
        {
            var bot = new Bot(channelAccessToken);
            //建立actions，作為ButtonTemplate的用戶回覆行為
            var actions = new List<isRock.LineBot.TemplateActionBase>();
            actions.Add(new isRock.LineBot.PostbackAction()
            { label = "空調控制postback", data = "123456789" });     //ButtonTemplateParameter.postback.ToString()
            actions.Add(new isRock.LineBot.MessageAction()
            { label = "6F 空調", text = ButtonTemplateParameter.LineEvent });


            //單一Button Template Message
            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()
            {
                altText = "監看狀態",
                text = ButtonTemplateParameter.Title,
                //title = "Title",

                //設定圖片
                thumbnailImageUrl = new Uri("https://cdn2.iconfinder.com/data/icons/essential-web-5/50/setting-adjust-control-panel-equalizer-256.png"),
                actions = actions //設定回覆動作
            };

            //發送
            bot.PushMessage(ButtonTemplateParameter.LineID, ButtonTemplate);
        }
        // 遠端控制Carousel
        public static void CarouselTemplateTest(ButtonTemplateParameter ButtonTemplateParameter)
        {
            RestAPI api = new RestAPI();
            var bot = new Bot(channelAccessToken);
            //建立actions，作為ButtonTemplate的用戶回覆行為
            //=======6F==========
            var actions6 = new List<isRock.LineBot.TemplateActionBase>();
            actions6.Add(new isRock.LineBot.MessageAction()
            { label = "開啟6F大門", text = "開六樓的門" });
            actions6.Add(new isRock.LineBot.MessageAction()
            { label = "開啟6F業務部空調(" + api.GetValue("020014") + "度)", text = "開啟6樓系統部空調" });
            actions6.Add(new isRock.LineBot.MessageAction()
            { label = "開啟6F工程部空調(" + api.GetValue("020013") + "度)", text = "開啟6樓工程部空調" });
            //=======4F==========
            var actions4 = new List<isRock.LineBot.TemplateActionBase>();
            actions4.Add(new isRock.LineBot.MessageAction()
            { label = "開啟4F大門", text = "開四樓的門" });
            actions4.Add(new isRock.LineBot.MessageAction()
            { label = "開啟4F空調", text = "開啟4樓空調" });
            actions4.Add(new isRock.LineBot.MessageAction()
            { label = "開啟6F工程部空調(" + api.GetValue("020013") + "度)", text = "開啟6樓工程部空調" });
            //=======266==========
            var actions266 = new List<isRock.LineBot.TemplateActionBase>();
            actions266.Add(new isRock.LineBot.MessageAction()
            { label = "266大門", text = "開266的門" });
            actions266.Add(new isRock.LineBot.MessageAction()
            { label = "266", text = "266沒空調喔@@" });
            actions266.Add(new isRock.LineBot.MessageAction()
            { label = "開啟6F工程部空調(" + api.GetValue("020013") + "度)", text = "開啟6樓工程部空調" });

            //依照冷氣狀態改變圖案
            string imgURL = "";
            if (api.GetValue("DO1") == 1)
            {
                imgURL = "https://cdn4.iconfinder.com/data/icons/hotel-service-5/300/air_conditioner-512.png"; //冷氣運作圖
            }
            else
            {
                imgURL = "https://cdn2.iconfinder.com/data/icons/kitchen-appliances-computers-and-electronics/32/Appliances-19-128.png"; //冷氣圖
            }
            //製作模板框架
            // =======6樓=======
            var ButtonTemplate6F = new isRock.LineBot.Column
            {

                text = "6樓",
                //title = "6樓",
                //設定圖片
                thumbnailImageUrl = new Uri(imgURL),
                actions = actions6 //設定回覆動作
            };
            //======= 4樓 =======
             var ButtonTemplate4F = new isRock.LineBot.Column
            {
                 text = "4樓",
                 //title = "4樓",
                 
                 //設定圖片
                 thumbnailImageUrl = new Uri("https://cdn3.iconfinder.com/data/icons/letters-and-numbers-1/32/number_4_green-256.png"),
                 actions = actions4 //設定回覆動作
            };
            //=========266======
            var ButtonTemplate266 = new isRock.LineBot.Column
            {
                text = "266",
                //title = "266",

                //設定圖片
                thumbnailImageUrl = new Uri("https://cdn2.iconfinder.com/data/icons/essential-web-5/50/setting-adjust-control-panel-equalizer-256.png"),
                actions = actions266 //設定回覆動作
            };
            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();
            CarouselTemplate.columns.Add(ButtonTemplate6F);
            CarouselTemplate.columns.Add(ButtonTemplate4F);
            CarouselTemplate.columns.Add(ButtonTemplate266);
            //發送
            bot.PushMessage(ButtonTemplateParameter.LineID, CarouselTemplate);
        }
    }
}