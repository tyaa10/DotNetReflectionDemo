using System;
using System.Collections.Generic;
using System.Linq;
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

            var result = getSurprize();
            Type resultType = result.GetType();
            //Console.WriteLine(resultType);

            foreach (var field in resultType.GetFields())
            {
                Console.WriteLine(field.GetValue(result));
            }

            foreach (var prop in resultType.GetProperties())
            {
                Console.WriteLine(prop.Name + " = " + prop.GetValue(result));
            }
        }

        private static dynamic getSurprize() {

            dynamic result = null;
            Random random = new Random();
            int variant = random.Next(0,3);
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
