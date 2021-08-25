using System;
using ICustomerLib;
using CustomerLibrary;
namespace CustomerFactory
{
    //Simple Factory Pattern 
    public class Factory
    {
        public ICustomer Create(int CustomerType)
        {
            if (CustomerType==0)
            {
                return new Visitor();
            }
            else
            {
                return new Customer();
            }
        }

    }
}
