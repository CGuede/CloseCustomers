using System.Collections.Generic;
using System.IO;

namespace CloseCustomers.Core
{
    public static class CustomerRepository
    {
        public static List<Customer> LoadCustomersFromJson(string filePath)
        {
            var output = new List<Customer>();
            string json;
            using (StreamReader r = new StreamReader(filePath))
            {
                while ((json = r.ReadLine()) != null)
                {
                    output.Add(JsonHelper.Deserialize<Customer>(json));
                }
            }
            return output;
        }
    }
}
