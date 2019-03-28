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
                var result = sql.CheckMember(userId);
                var result1 = sql.CheckMember(userId, "'ok'");
                const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
                var bot = new Bot(channelAccessToken);

                if (result1.Count != 0)
                {
                    //ButtonTemplateParameter status = new ButtonTemplateParameter();
                    //status.LineID = userId;
                    //status.ViewURL1 = "http://api.leegood.com.tw:58088/LGoffice_/home.htm";
                    //status.ViewURL2 = "http://api.leegood.com.tw:58088/LGoffice_/4f_sa.htm";
                    //LineTemplate.BuildingStatusTemplete(status);
                    return true;
                }
                else if (result.Count != 0)
                {
                    bot.PushMessage(userId, "尚未進行驗證");
                    return false;
                }
                else
                {
                    bot.PushMessage(userId, "請至個人設定登入取得權限");
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