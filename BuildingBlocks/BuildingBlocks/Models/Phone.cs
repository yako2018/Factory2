using BuildingBlocks.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingBlocks.Service.Crm
{
    public class Phone : ICrmPhone
    {
        public string clf_contact { set; get; }
        public string name { set; get; }
        public string number { set; get; }
        public string phoneid { set; get; }
    }
}