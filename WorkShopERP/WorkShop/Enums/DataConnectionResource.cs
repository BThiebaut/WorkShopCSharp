using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopERP.WorkShop.Enums
{
    public enum DataConnectionResource : Int32
    {
        [StringValue("Server=database.thiebaut.ovh;Port=3306; Database = user_workshop;Uid = user_workshop;Pwd = passware_workshop" )]
       
        GENERICMYSQL = 1,
       
        [StringValue("Server=127.0.0.1;Port=3306; Database = user_workshop;Uid = user_workshop;Pwd = passware_workshop")]

        LOCALMYQSL = 2,
       
        [StringValue("http://api.thiebaut.ovh")]
       
        LOCALAPI = 3,
 }
}
