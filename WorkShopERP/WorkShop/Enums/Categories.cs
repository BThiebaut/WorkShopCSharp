using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopERP.WorkShop.Enums
{
    public enum Categories : Int32
    {
        [StringValue("Default error")]
        NULL = 0,
        [StringValue("Chair")]
        CHAIR = 1,
        [StringValue("Lamp")]
        LAMP = 2,
        [StringValue("Shelf")]
        SHELF = 3,
        [StringValue("Table")]
        TABLE = 4,
        [StringValue("Canvas")]
        CANVAS = 5,
        [StringValue("Sculpted")]
        SCULPTED = 6,
        [StringValue("Rock")]
        ROCK = 7,
        [StringValue("Wood")]
        WOOD = 8,
        [StringValue("Other")]
        OTHER = 9,

    }
}
