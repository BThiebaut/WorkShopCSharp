﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopERP.WorkShop.Enums
{
    public class StringValueAttribute : Attribute
    {
        public string StringValue { get; protected set; }
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }
    }
}
