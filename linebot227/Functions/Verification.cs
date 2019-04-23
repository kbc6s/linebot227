using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using linebot227.Functions;
using isRock.LineBot;
using linebot227.Models;

namespace linebot227.Functions
{
    public class Verification
    {
        public bool VeriMember(string userId)
        {
            
            try
            {
                var sql = new SQLcontroller("127.0.0.1", "mydb", "sa", "leegood#09477027");
                var result = sql.CheckMember(userId);           //辦過會員管理員還沒驗證
                var result1 = sql.CheckMember(userId, "'ok'");  //已經是會員
                const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
                var bot = new Bot(channelAccessToken);
                string weekday=DateTime.Now.ToString("ddd");
                string hour = DateTime.Now.ToString("HH");
                if (result1.Count != 0 /*&& DateTime.Now.ToString("ddd dd MMM, yyyy") ==*/)
                {
                    return true;
                }
                else if (result.Count != 0)
                {
                    bot.PushMessage(userId, "尚未進行驗證");
                    return false;
                }
                else 
                {
                    bot.PushMessage(userId, "請至個人設定/n點擊首次登入取得權限");
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}