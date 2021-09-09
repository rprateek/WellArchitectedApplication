using System;
using Interfaces;

namespace CustomerLibrary
{
   
    public class Customer : CustomerBase
    {
        //In the individual child class creating the constructor to call the Validation 
        //this is injecting Validation strategy here
        public Customer(IValidation<ICustomer> objVal):base(objVal)
        {
          
        }        

    }

    public class Visitor : CustomerBase
    {
        //this is injecting Validation strategy here
        public Visitor(IValidation<ICustomer> objVal):base(objVal)
        {            
        }       
    }
}
