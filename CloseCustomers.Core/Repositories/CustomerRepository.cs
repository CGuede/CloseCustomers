using System.Collections.Generic;
using System.IO;

namespace CloseCustomers.Core
{
    public static class CustomerRepository
    {
        public static List<Customer> LoadCustomersFromJson(string filePath)
        {
            var customersList = new List<Customer>();
            string customerJson;
            using (StreamReader r = new StreamReader(filePath))
            {
                while ((customerJson = r.ReadLine()) != null)
                {
                    customersList.Add(JsonHelper.Deserialize<Customer>(customerJson));
                }
            }
            return customersList;
        }
    }
}
