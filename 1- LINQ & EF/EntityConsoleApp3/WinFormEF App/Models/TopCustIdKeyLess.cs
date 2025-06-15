using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormEF_App.Models
{
    [Keyless]
    public class TopCustIdKeyLess
    {
        public string CustomerID { get; set; }
    }
}
