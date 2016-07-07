using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopERP.WorkShop.Utils.IFaker
{
    public interface IFakerLoader<T>
    {
        T LoadSingleItem();
        List<T> LoadMultipleItems();
    }
}
