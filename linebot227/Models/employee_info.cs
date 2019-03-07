using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace linebot227.Models
{
    public class Employee_info
    {
        public string name { get; set; }
        public string lineID { get; set; }
        public int mail { get; set; }
    }
    public class ButtomTemplate_info
    {
        public string imageURL { get; set; }
        public List<string> Button { get; set; }
    }

}