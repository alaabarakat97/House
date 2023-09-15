using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Domain.Enums;
public enum HouseStatus
{
    [Description("Active")]
    Active = 0,
    [Description("InActive")]
    InActive = 1,
}
