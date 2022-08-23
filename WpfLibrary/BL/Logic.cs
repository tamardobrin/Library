using BookLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary.BL
{
    public class Logic
    {
        public List<Customer> Customers = new List<Customer>();
        public List<Worker> Workers = new List<Worker>();

        public Logic()
        {
            Workers.Add(new Worker { Name = "Tamar", ID = 322651738 });
            Workers.Add(new Worker { Name = "Niv", ID = 120956245 });
            Workers.Add(new Worker { Name = "Eden", ID = 937285430 });
            Workers.Add(new Worker { Name = "Yael", ID = 736482956 });
            Workers.Add(new Worker { Name = "Hanna", ID = 836293633 });
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }

}
