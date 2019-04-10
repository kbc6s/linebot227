using linebot227.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using linebot227.Functions;
using RestSharp;
using System.Threading;

namespace linebot227.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U8168367ec76c449dbdd98410d9333b8b";
        Verification check = new Verification();
        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
            RestAPI api = new RestAPI();
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "postback")
                {
                    string msg = LineEvent.postback.data;
                    //msg += $"\n Params.date : {LineEvent.postback.Params.date + ""}";
                    //msg += $"\n Params.datetime : {LineEvent.postback.Params.datetime + ""}";
                    //msg += $"\n Params.time : {LineEvent.postback.Params.time + ""}";
                    this.ReplyMessage(LineEvent.replyToken, msg);
                    return Ok();
                }
                
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text")
                    { //收到文字
                        //this.ReplyMessage(LineEvent.replyToken, "你說了:" + LineEvent.message.text);

                        if (LineEvent.message.text == "個人設定")
                        {
                            ButtonTemplateParameter info = new ButtonTemplateParameter();
                            info.LineID = LineEvent.source.userId;
                            linebot227.Functions.LineTemplate.LoginTemplete(info);
                        }
                       
                        if (LineEvent.message.text == "監看狀態" && check.VeriMember(LineEvent.source.userId))
                        {
                            ButtonTemplateParameter status = new ButtonTemplateParameter();
                            status.LineID = LineEvent.source.userId;
                            status.ViewURL1 = "http://api.leegood.com.tw:58088/LGoffice_/home.htm";
                            status.ViewURL2 = "http://api.leegood.com.tw:58088/LGoffice_/4f_sa.htm";
                            LineTemplate.BuildingStatusTemplete(status);

                        }
                        if (LineEvent.message.text == "遠端控制" && check.VeriMember(LineEvent.source.userId))
                        {
                            //ButtonTemplateParameter status = new ButtonTemplateParameter
                            //{
                            //    LineID = LineEvent.source.userId
                            //    //status.Title = "冷氣狀態: "+ api.GetValue("020004");     //將冷氣狀態放入Title
                            //};
                            //LineTemplate.RemoteController(status);
                            ButtonTemplateParameter status = new ButtonTemplateParameter
                            {
                                LineID = LineEvent.source.userId
                            };
                            LineTemplate.CarouselTemplateTest(status);

                        }
                        if (LineEvent.message.text == "開啟6樓系統部空調" && check.VeriMember(LineEvent.source.userId))
                        {
                            if (api.GetValue("020004")==1)
                            {
                                this.ReplyMessage(LineEvent.replyToken, "系統部冷氣是開著的喔.....");
                            }
                            else
                            {
                                api.SetValue("020032", 1);
                                Thread.Sleep(800); //Delay 1秒
                                api.SetValue("020032", 0); //020032
                                if (api.GetValue("020004") == 1)
                                {
                                    this.ReplyMessage(LineEvent.replyToken, "成功開啟空調");
                                }
                            }
                        }
                        if (LineEvent.message.text == "開啟6樓工程部空調" && check.VeriMember(LineEvent.source.userId))
                        {
                            if (api.GetValue("020001") == 1)
                            {
                                this.ReplyMessage(LineEvent.replyToken, "工程部冷氣是開著的喔.....");
                            }
                            else
                            {
                                api.SetValue("020031", 1);
                                Thread.Sleep(800); //Delay 1秒
                                api.SetValue("020031", 0); //020032
                                if (api.GetValue("020001") == 1)
                                {
                                    this.ReplyMessage(LineEvent.replyToken, "成功開啟空調");
                                }
                            }
                        }
                        if (LineEvent.message.text == "檢查門窗" && check.VeriMember(LineEvent.source.userId))
                        {
                            //RestAPI api = new RestAPI();
                            
                            var pointName = new List<string>
                            {
                                "6樓大門,",
                                "志中旁窗戶,",
                                "柏欽旁窗戶,",
                                "禹任旁窗戶,",
                                "蕭董辦公室沙發旁,",
                                "蕭座位旁窗戶,",
                                "系統部窗戶,",
                                "小房間",
                                "測試點"
                            };
                            var points = new List<int>
                            {
                                api.GetValue("020030"),          //大門        value是1代表門是開的
                                api.GetValue("BA_020023"),       //志中旁窗戶
                                api.GetValue("BA_020024"),       //柏欽旁窗戶
                                api.GetValue("BA_020025"),       //禹任旁窗戶
                                api.GetValue("BA_020026"),       //蕭董辦公室沙發旁
                                api.GetValue("BA_020027"),       //蕭座位旁窗戶
                                api.GetValue("BA_020028"),       //系統部窗戶
                                api.GetValue("BA_020029"),       //小房間
                                api.GetValue("DO1")             //測試點
                            };
                            bool isIn = points.Contains(1);
                            string openStatus = "";
                            int count = 0;
                            if (isIn)
                            {
                                foreach (var point in points)
                                {
                                    count++;
                                    if (point == 1)
                                    {
                                        openStatus += pointName[count - 1];
                                    }
                                }
                                this.ReplyMessage(LineEvent.replyToken, openStatus+"沒關");
                            }
                            else
                            {
                                this.ReplyMessage(LineEvent.replyToken, "門窗都關好了");
                            }
                        }
                    }
                    
                    /*
                    //Post : 傳送表單
                    HttpClient client = new HttpClient();
                    var uri = $"http://192.168.3.69/WaWebService/Json/SetTagValue/Leegood";

                    Class1 myclass = new Class1();
                    myclass.MyProperty = 123;
                    //content = 表單
                    var content = new StringContent(
                        JsonConvert.SerializeObject(myclass),
                        Encoding.UTF8,
                        "application/json");
                    
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    //response.StatusCode 
                    */
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
