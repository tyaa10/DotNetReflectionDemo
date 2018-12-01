using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 1 */
            /*CustomerEntity customer =
                new CustomerEntity() {
                    id = 1,
                    name = "n1",
                    surname = "s1",
                    balance = 100,
                    inn = 91191191191,
                    birthday = new DateTime(1990, 01, 20)
                };

            CustomerModel customerModel = new CustomerModel();*/
            /*customerModel.id = customer.id;
            customerModel.name = customer.name;
            customerModel.surname = customer.surname;*/

            /*Type customerType = typeof(CustomerModel);
            foreach (var field in customerType.GetFields())
            {
                field.SetValue(customerModel, field.GetValue(customer));
            }*/

            /* 2 */
            /*Type customerModelType = typeof(CustomerModel);
            Type customerEntityType = typeof(CustomerEntity);
            foreach (var field in customerModelType.GetFields())
            {
                field.SetValue(
                    customerModel
                    , customerEntityType.GetField(field.Name).GetValue(customer)
                );
            }

            Console.WriteLine(customerModel);*/

            /*for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(getSurprize());
            }*/

            //var result = getSurprize();
            //Type resultType = result.GetType();
            //Console.WriteLine(resultType);

            /*foreach (var field in resultType.GetFields())
            {
                Console.WriteLine(field.GetValue(result));
            }

            foreach (var prop in resultType.GetProperties())
            {
                Console.WriteLine(prop.Name + " = " + prop.GetValue(result));
            }*/

            /*foreach (var field in resultType.GetFields())
            {
                Console.WriteLine(field.Name + " " + field.GetValue(result));
            }

            foreach (var prop in resultType.GetProperties())
            {
                var propValue = prop.GetValue(result);
                var propType = propValue.GetType();
                if (propType.IsPrimitive || propValue is string)
                    //Console.WriteLine($"{prop.Name} = {propValue}");
                    Console.WriteLine(String.Format("{0} = {1}", prop.Name, propValue));
                else
                {
                    Console.WriteLine($"{prop.Name} = ");
                    foreach (var field in propType.GetFields())
                    {
                        var value = propType.GetField(field.Name).GetValue(propValue);
                        Console.WriteLine($"\t{field.Name} = {value}");
                    }
                }
            }*/

            PrivateCustomerEntity pce = new PrivateCustomerEntity();
            Type resultType = pce.GetType();

            foreach (var field in resultType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (field.IsPrivate)
                {
                    if (field.Name == "secureField")
                    {
                        field.SetValue(pce, "World!");
                    }
                }
                
            }

            foreach (var field in resultType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(field.Name + " " + field.GetValue(pce));
            }

            resultType.GetMethod("MyMethod").Invoke(pce, null);
            resultType.GetMethod("MyMethod2").Invoke(pce, new object[] { "x", "y" });
            resultType.GetMethod("MyMethod3").Invoke(pce, new object[] { 12 });
        }

        private static dynamic getSurprize() {

            dynamic result = null;
            Random random = new Random();
            int variant = random.Next(1,4);
            switch (variant)
            {
                case 1:
                    {
                        result = new CustomerEntity()
                        {
                            id = 1,
                            name = "n1",
                            surname = "s1",
                            balance = 100,
                            inn = 91191191191,
                            birthday = new DateTime(1990, 01, 20)
                        };
                        break;
                    }
                case 2:
                    {
                        result = new { uid = 1, data = "hello!" };
                        break;
                    }
                case 3:
                    {
                        result = new {
                            uid = 1
                            , data = "hello!"
                            , customer = new CustomerEntity()
                            {
                                id = 1,
                                name = "n1",
                                surname = "s1",
                                balance = 100,
                                inn = 91191191191,
                                birthday = new DateTime(1990, 01, 20)
                            }
                        };
                        break;
                    }
                default:
                    break;
            }
            return result;
        }
    }
}
