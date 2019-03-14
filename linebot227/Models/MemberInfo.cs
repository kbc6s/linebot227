using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace linebot227.Models
{
    public class MemberInfo
    {
        public Int64 Seq { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LineID { get; set; }
        public string Valid { get; set; }
        public DateTime AuthTime { get; set; }
    }
}