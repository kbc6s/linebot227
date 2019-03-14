using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace linebot227.Models
{
    public class ButtonTemplateParameter
    {
        public string imageURL { get; set; }
        public List<string> Button { get; set; }
        public string LineID { get; set; }
        public string LineEvent { get; set; }
        //public List<string> ViewURL { get; set; }   //無法使用List建立複數個網址按鈕
        public string ViewURL1 { get; set; }
        public string ViewURL2 { get; set; }
    }
}