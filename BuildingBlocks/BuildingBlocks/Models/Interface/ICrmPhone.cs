using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Models.Interface
{
    public interface ICrmPhone
    {
        string clf_contact { set; get; }
        string name { set; get; }
        string number { set; get; }
        string phoneid { set; get; }
    }
}
