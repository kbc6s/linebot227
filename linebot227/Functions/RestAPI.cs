﻿using System;
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
        public string GetListValue(List<string>Name,List<string>placeName) //string Name
        {
            
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
                //list.Add(value);
                //list+=(value.Value);
                //list += (value.Value);
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
                //this.ReplyMessage(LineEvent.replyToken, openStatus + "沒關");
                string aaa = openStatus + "沒關";
                int ll = 1;
                return aaa;
            }
            else
            {
                //this.ReplyMessage(LineEvent.replyToken, "門窗都關好了");
                string aaa = "門窗都關好了";
                return aaa;
            }
            int dd = 11;
        }
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
        public string GetAirConditonTemp(string PointName)
        {
            var client = new RestClient("http://192.168.3.69/WaWebService/Json/GetTagValue/Leegood");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic YWRtaW46bGVlZ29vZA==");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", "{\"Tags\": [{\"Name\": \"" + PointName + "\"}]}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var buff = response.Content;  //buff is string
            dynamic result = JValue.Parse(buff); //result is object
            var value = result.Values[0].Value; //so I can get value in result
            return value;
        }
    }
}