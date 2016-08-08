using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Class1
    {   
        public int Multiply (int a , int b)
        {
            int c = a / b;
            return c;
        }
        static void Main()
        {
            Class1 instance = new Class1();
            Console.WriteLine("Hello World!");
            //decimal[] factors = new decimal[] { decimal.MaxValue, decimal.MaxValue };
            try
            {
                checked
                {
                    decimal product = factors[0] * factors[1];
                //    instance.Multiply(1 , 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }

        }
    }
}
