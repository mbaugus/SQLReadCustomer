using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SqlLib;
using static System.Console;

namespace SqlReadCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCustomer cust = new SqlCustomer();
            List<Customer> customers = cust.List();

            foreach (Customer c in customers)
            {
                Console.WriteLine($"{c.Id} {c.Name} {c.City}, {c.State}");
            }
        }
    }
}
