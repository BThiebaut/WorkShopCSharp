using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Entities;

namespace WorkShopERP.WorkShop.JSON
{
    public class SandBox
    {
        

        public void TestIt()
        {
            Address address = new Address().LoadSingleItem();

            String convertAddress = JsonConvert.SerializeObject(address);

            List<Customer> cust = new Customer().LoadMultipleItems();

            String convertCust = JsonConvert.SerializeObject(cust);

            Address addrRevert = JsonConvert.DeserializeObject<Address>(convertAddress);

            List<Customer> custRevert = JsonConvert.DeserializeObject<List<Customer>>(convertCust);

        }

    }
}
