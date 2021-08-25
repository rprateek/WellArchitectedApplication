using System;
using DataAccess;
using ICustomerLib;
namespace CustomerLibrary
{

    public class CustomerBase:ICustomer 
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public virtual void Validate()
        {
            // Virtual function created so that it can be override by child class
            //let this be defined by child classes. 
        }

    }
    public class Customer: CustomerBase
    {
               
        public override void Validate() //overriding the virtual class created by CustomerBase
        {
            if(FullName.Length==0)
            {
                throw new Exception("Customer Full Name is required");
            }
            if (PhoneNumber.Length == 0)
            {
                throw new Exception("Customer Phone Number is required");
            }
            if (BillAmount == 0)
            {
                throw new Exception("Bill Amount is required");
            }
            if (BillDate >= DateTime.Now)
            {
                throw new Exception("Bill Date is not correct");
            }
        }

    }

    public class Visitor: Customer
    {
        public override void Validate()
        {
            if (FullName.Length == 0)
            {
                throw new Exception("Customer Full Name is required");
            }
            if (PhoneNumber.Length == 0)
            {
                throw new Exception("Customer Phone Number is required");
            }
        }
    }
}
