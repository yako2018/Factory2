using BuildingBlocks.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuildingBlocks.Service.Crm
{
    public class Phone : ICrmPhone
    {
        public string name { set; get; }
        public string number { set; get; }
        public string phoneid { set; get; }
    }
}