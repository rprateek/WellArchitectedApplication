using System;
using DataAccess;
using Interfaces;

namespace CustomerLibrary
{
    public class CustomerBase : ICustomer
    {
        //Create object of Interface validation
        private IValidation<ICustomer> _validation = null;

        //Inject the Validation strategy in the Customer object
        //when the customer object is created it requies what type of validation strategy is required
        public CustomerBase(IValidation<ICustomer> objVal)
        {
            _validation = objVal;
        }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public virtual void Validate()
        {
            // Virtual function created so that it can be override by child class
            //let this be defined by child classes. 
            // Clalling the validatoin method and passing the current customer object to be validated
            _validation.Validate(this);
        }
        public ICustomer Clone()
        {
            // Introducing Memberwise clone in base class to be able to clone any customer objects created 
            return (ICustomer)this.MemberwiseClone();
        }

    }
    public class Customer : CustomerBase
    {
        //In the individual child class creating the constructor to call the Validation 
        //this is injecting Validation strategy here
        public Customer(IValidation<ICustomer> objVal):base(objVal)
        {

        }        

    }

    public class Visitor : Customer
    {
        //this is injecting Validation strategy here
        public Visitor(IValidation<ICustomer> objVal):base(objVal)
        {

        }       
    }
}
