using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class PrivateCustomerEntity : CustomerEntity
    {
        private string secureField = "Hello";

        public void MyMethod() {
            Console.WriteLine("Hello " + secureField);
        }
        public void MyMethod2(string a, string b)
        {
            Console.WriteLine("Hello " + a + " " + b);
        }
        public void MyMethod3(int i)
        {
            Console.WriteLine("Hello " + i);
        }
    }
}
