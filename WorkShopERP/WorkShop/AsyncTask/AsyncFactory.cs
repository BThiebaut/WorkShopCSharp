using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopERP.WorkShop.AsyncTask
{
    public class AsyncFactory
    {
        public async void TestIt()
        {
            Task<Int32> async;
            Task.Factory.StartNew(() =>
            {
                Int32 result = this.CountTo10000WithReturn().Result;
            });
            

        }  

        private Task CountTo10000()
        {
            Action count = new Action(() => 
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine(" AsyncTask i is " +i);
                }
            });
            return Task.Run(count);
        }

        private Task<Int32> CountTo10000WithReturn()
        {
            Func<Int32> count = new Func<Int32>(() =>
            {
                int i = 0;
                for (; i < 1000; i++)
                {
                    Console.WriteLine(" AsyncTask i is " + i);
                }
                return i;
            });
            return Task.Run(count);
        }


    }
}
