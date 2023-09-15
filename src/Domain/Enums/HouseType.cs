using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Domain.Enums;
public enum HouseType
{
    [Description("Family")]
    Family = 0,
    [Description("Students")]
    Students = 1,
    [Description("All")]
    All = 2,
}
