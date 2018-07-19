using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Service.Interface
{
    public interface ICrmPhone
    {
        string name { set; get; }
        string number { set; get; }
        string phoneid { set; get; }
    }
}
