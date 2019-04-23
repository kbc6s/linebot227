using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using isRock.LineBot;

namespace linebot227.Functions
{
    public class ScheduleControll
    {
        //設置排程並通知用戶可使用時間
        public bool Schedule(List<string> week, int startTime, int EndTime ,string userID)
        {
            string weekday = DateTime.Now.ToString("ddd");
            string hour = DateTime.Now.ToString("HH");
            int intHour = int.Parse(hour);
            bool isWeek = week.Contains(weekday);
            if (EndTime > intHour && startTime - 1 < intHour && isWeek)
            {
                return true;
            }
            else
            {
                const string channelAccessToken = "fTBvt+oi30MpuWqTvT/KJDBuKDJ8iKxPhJLX5fHwT+bha1vEfZPfprFFQ7LrdgdyrDnx/yDe1C+hTbLtYxojWGRyAbRVz2iuok8WbUiZBeOn3gxlUjs5gpsGQmmySmmF9m/Uat9ZwLWxomFA3FZ6jgdB04t89/1O/w1cDnyilFU=";
                var bot = new Bot(channelAccessToken);
                string message = "遠端控制時間為" + "週一到週六 " + startTime + ":00 ~ " + EndTime + ":00";
                bot.PushMessage(userID, message);
                return false;
            }
        }
    }
}