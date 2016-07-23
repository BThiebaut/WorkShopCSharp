using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopERP.WorkShop.Enums
{
    public enum DataConnectionResource : Int32
    {
        [StringValue("Server=127.0.0.1;Port=3306;Database=csharp_workshop_server;Uid=root;Pwd=;")]
        SERVERMYSQL = 1,
       
        [StringValue("Server=127.0.0.1;Port=3306;Database=csharp_workshop;Uid=root;Pwd=;")]
        LOCALMYQSL = 2,
       
        [StringValue("http://localhost:59165/api/")]
        LOCALAPI = 3,
 }
}
