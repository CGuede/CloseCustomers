using CloseCustomers.Core;
using System;
using System.Linq;

namespace CloseCustomers
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "Resources/customers.json";
            const int distanceMts = 100000;
            const double intercomLatitud = 53.3381985;
            const double intercomLongitud = -6.2592576;

            var customers = CustomerRepository.LoadCustomersFromJson(filePath);

            var closeCustomers = customers
                .Where(c => GeometricHelper.GetGeoDistance(intercomLatitud, intercomLongitud, c.latitude, c.longitude) 
                                    < distanceMts)
                .OrderBy(c => c.user_id).ToList();

            foreach (var customer in closeCustomers)
                Console.WriteLine("Customer name: {0} - Id: {1}", customer.name, customer.user_id);

            Console.ReadLine();                 
        }
    }
}
