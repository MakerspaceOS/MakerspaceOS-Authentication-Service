using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakerSpaceOS.Services
{
    public class EquipmentAccessResponse
    {
       public string AccessAllowed { get; set; }
       public String UserName { get; set; }

       public String Message { get; set; }

       public int TimeLimit { get; set; }

       public int? AmpsWhenOn { get; set; }
    }
}