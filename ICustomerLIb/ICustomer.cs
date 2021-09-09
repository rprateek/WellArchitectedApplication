using System;
using System.ComponentModel.DataAnnotations;

namespace Interfaces
{
    public interface ICustomer
    {
     
        [Key]
        public int Id { get; set; }
        string FullName { get; set; }
        string CustomerType { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
         string Address { get; set; }
        void Validate();
        ICustomer Clone();
        
    }
}
