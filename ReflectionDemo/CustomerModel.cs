using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class CustomerModel
    {
        public int id;
        public string name;
        public string surname;

        public override string ToString()
        {
            return $"id = {id} name = {name} surname = {surname}";
        }
    }
}
