using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;
using System.Collections.ObjectModel;
using WorkShop.Entities;
using WorkShopERP.WorkShop.Enums;
using WorkShop.Entities.Categories;

namespace WorkShopERP.WorkShop.Utils
{
    public class Utils
    {
        public void writeLine<T>( T param ) where T : class
        {
            
        }

        public String GenFrenchPhoneNumber()
        {
            String result = "0";

            for (int i = 0; i < 9; i++)
            {
                result += "" + Faker.Number.RandomNumber(0, 9);
            }

            return result;
        }

        public ObservableCollection<T> ConvertListToObservableCollection<T>(List<T> param) where T : class
        {
            ObservableCollection<T> ob = new ObservableCollection<T>();
            foreach (var item in param)
            {
                ob.Add(item);
            }
            return ob;
        }

        public Product getRandomCategoriesItem()
        {
            var enumCount = Enum.GetNames(typeof(Categories)).Length;
            Product result;

            switch (Faker.Number.RandomNumber(1, enumCount + 1))
            {
                case (Int32)Categories.CHAIR:
                    result = new Chair();
                    break;
                case (Int32)Categories.LAMP:
                    result = new Lamp();
                    break;
                case (Int32)Categories.SHELF:
                    result = new Shelf();
                    break;
                case (Int32)Categories.TABLE:
                    result = new Table();
                    break;
                case (Int32)Categories.CANVAS:
                    result = new Canvas();
                    break;
                case (Int32)Categories.SCULPTED:
                    result = new Sculpted();
                    break;
                case (Int32)Categories.ROCK:
                    result = new Rock();
                    break;
                case (Int32)Categories.WOOD:
                    result = new Wood();
                    break;
                default:
                    result = new Other();
                    break;

            }
            
            return result;
        }

    }
}
