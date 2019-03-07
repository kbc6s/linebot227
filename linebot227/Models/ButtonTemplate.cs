using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace linebot227.Models
{
    public class ButtonTemplate_info
    {
        public string imageURL { get; set; }
        public List<string> Button { get; set; }
        public string LineID { get; set; }
        public string LineEvent { get; set; }
    }
}