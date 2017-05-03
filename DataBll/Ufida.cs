using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouHoo.DataBll
{
    public class Ufida
    {
        public class UFCustomer
        {
            public Customer GetCustomerModel(string ccusCode)
            {
                using (ufdataDataContext dc = new ufdataDataContext())
                {
                    return dc.Customer.FirstOrDefault(x=>x.cCusCode==ccusCode);
                }
            }
            public List<Customer> GetCustomerModel()
            {
                using (ufdataDataContext dc = new ufdataDataContext())
                {
                    return dc.Customer.Select(x=>x).ToList();
                }
            }


        }
    }
}
