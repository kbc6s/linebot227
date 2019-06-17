using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace linebot227.Functions
{
    public class RestAPI
    {
        //檢查門窗function
        public string GetListValue(List<string>Name,List<string>placeName) //string Name
        {
            //var pointName = new List<string>
            //                {
            //                    "6樓大門,",
            //                    "志中旁窗戶,",
            //                    "柏欽旁窗戶,",
            //                    "禹任旁窗戶,",
            //                    "蕭董辦公室沙發旁,",
            //                    "蕭座位旁窗戶,",
            //                    "系統部窗戶,",
            //                    "小房間",
            //                    "測試點"
            //                };
            //var points = new List<string>
            //                {
            //                    "020030",          //大門        value是1代表門是開的
            //                    "BA_020023",       //志中旁窗戶
            //                    "BA_020024",       //柏欽旁窗戶
            //                    "BA_020025",       //禹任旁窗戶
            //                    "BA_020026",       //蕭董辦公室沙發旁
            //                    "BA_020027",       //蕭座位旁窗戶
            //                    "BA_020028",       //系統部窗戶
            //                    "BA_020029",       //小房間
            //                    "DO1"             //測試點
            //                };
            var client = new RestClient("http://192.168.3.69/WaWebService/Json/GetTagValue/Leegood");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic YWRtaW46bGVlZ29vZA==");
            request.AddHeader("Content-Type", "application/json");
            int length = Name.Count;
            string body = "{\"Tags\": [";
            int count = 0;
            //排版request body
            foreach (string x in Name)
            {
                count++;
                if (count != length)
                {
                    body += "{ \"Name\": \"" + x + "\"},";
                }
                else
                {
                    body += "{ \"Name\": \"" + x + "\"}";
                }
            }
            body += "]}";
            request.AddParameter("undefined", body, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            // ================== parsing JSON ====================
            var buff = response.Content;  //buff is string
            dynamic result = JValue.Parse(buff); //result is object\
            var list = new List<int> {  };
            string ff="";
            //string[] list= { };
            //string eee = result.Values.Value;
            foreach (var value in result.Values)
            {
                ff += value.Value;
            }
            //var value = result.Values[8].Value; //so I can get value in result

            //bool isIn = result.Values[0].Value.Contains(1);
            bool isIn = ff.Contains("1");
            string openStatus = "";
            count = 0;
            if (isIn)
            {
                foreach (char point in ff)
                {
                    count++;
                    if (point == '1')
                    {
                        openStatus += placeName[count - 1];
                        //openStatus += Name[0];
                    }
                }
                string aaa = openStatus + "沒關";
                //int ll = 1;
                return aaa;
            }
            else
            {
                string aaa = "門窗都關好了";
                return aaa;
            }

        }
        //取得DDC 點位資訊
        public int GetValue(string Name) //string Name
        {
            var client = new RestClient("http://192.168.3.69/WaWebService/Json/GetTagValue/Leegood");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic YWRtaW46bGVlZ29vZA==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"Tags\": [{\"Name\": \"" + Name + "\"}]}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            // ================== parsing JSON ====================
            var buff = response.Content;  //buff is string
            dynamic result = JValue.Parse(buff); //result is object
            var value = result.Values[0].Value; //so I can get value in result
            return value;
        }
        //設定DDC 點位
        public string SetValue(string Name, int Value)  //string Name,int Value
        {
            var client = new RestClient("http://192.168.3.69/WaWebService/Json/SetTagValue/Leegood");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic YWRtaW46bGVlZ29vZA==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"Tags\": [{\"Name\": \"" + Name + "\",\"Value\": " + Value + "}]}", ParameterType.RequestBody);
            //request.AddParameter("undefined", "{\"Tags\": [{\"Name\": \"DO1\",\"Value\": 1}]}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string buff = response.StatusCode.ToString();  //buff is string
            return buff;
        }
    }
}