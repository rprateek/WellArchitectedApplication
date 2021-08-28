using System;
using Interfaces;

//Validation Logic Project to hold all the validation related logic
namespace ValidationLogic
{
    //Validation logic for customer entity
    public class CustomerValidation : IValidation<ICustomer>
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
            if (obj.Address.Length == 0)
            {
                throw new Exception("Address is required");
            }
        }
    }
    //Validation logic for Visitor Entity
    public class VisitorValidation : IValidation<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.FullName.Length == 0)
            {
                throw new Exception("Visitor Full Name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Visitor Phone Number is required");
            }
        }
    }

}
