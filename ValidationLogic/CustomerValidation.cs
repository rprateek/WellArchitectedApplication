using System;
using ICustomerLib;
using Validation;

namespace ValidationLogic
{
    public class CustomerValidation: IValidationStrategy<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.FullName.Length == 0)
            {
                throw new Exception("Customer Full Name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Customer Phone Number is required");
            }
            if (obj.BillAmount == 0)
            {
                throw new Exception("Bill Amount is required");
            }
            if (obj.BillDate >= DateTime.Now)
            {
                throw new Exception("Bill Date is not correct");
            }
        }
    }

    public class VisitorValidation:IValidationStrategy<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.FullName.Length == 0)
            {
                throw new Exception("Customer Full Name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Customer Phone Number is required");
            }
        }

    }

}
