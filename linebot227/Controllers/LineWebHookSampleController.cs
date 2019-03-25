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

namespace linebot227.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U8168367ec76c449dbdd98410d9333b8b";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
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
                        if (LineEvent.message.text == "監看狀態")
                        {
                            var result = sql.CheckDetail(LineEvent.source.userId);
                            var result1 = sql.CheckDetail(LineEvent.source.userId,"'ok'");
                            //var result1 = sql.GetMemberInfo(LineEvent.source.userId, "'ok'");
                            if (result1.Count != 0)
                            {
                                ButtonTemplateParameter status = new ButtonTemplateParameter();
                                status.ViewURL1 = "http://api.leegood.com.tw:58088/LGoffice_/home.htm";
                                status.ViewURL2 = "http://api.leegood.com.tw:58088/LGoffice_/4f_sa.htm";
                                LineTemplate.BuildingStatusTemplete(status);
                            }
                            else if (result.Count != 0)
                            {
                                this.PushMessage(LineEvent.source.userId, "尚未進行驗證");
                            }
                            else
                            {
                                this.PushMessage(LineEvent.source.userId, "請至個人設定登入取得權限");
                            }
                            
                            //HttpClient client = new HttpClient();
                            //var uri = $"http://kaiwen1995.com:3001/openKai";
                            //HttpResponseMessage response = client.GetAsync(uri).Result;
                        }
                    }
                    /*
                    //Post : 傳送表單
                    HttpClient client = new HttpClient();
                    var uri = $"網址";

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
