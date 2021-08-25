﻿using System;

namespace ICustomerLib
{
    public interface ICustomer
    {
        string FullName { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
         string Address { get; set; }
        void Validate();
        
    }
}
