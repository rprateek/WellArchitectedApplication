using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Interfaces
{
    public class CustomerBase : ICustomer
    {
        //Create object of Interface validation
        private IValidation<ICustomer> _validation = null;

        public CustomerBase()
        {
            // Creating the empty constructor just for EF Use 
            //EF cannot use the interface so we have to use this entity class as a workaround
            // We even made it normal class by removing abstract keyword
            FullName = "";
            PhoneNumber = "";
            BillAmount = 0;
            BillDate = DateTime.Now;
            Address = "";

        }

        //Inject the Validation strategy in the Customer object
        //when the customer object is created it requies what type of validation strategy is required
        public CustomerBase(IValidation<ICustomer> objVal)
        {
            _validation = objVal;
        }

        [Key]
        public int Id { get; set; }

        public string CustomerType { get; set; }
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
            return (CustomerBase)this.MemberwiseClone();
        }

    }
}
