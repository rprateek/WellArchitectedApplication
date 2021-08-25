﻿using System;
using System.Windows.Forms;
using CustomerLibrary;
using ICustomerLib;
using CustomerFactory;
namespace PetShop
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            ICustomer iCust = null;

            Factory oFactory = new Factory();
            oFactory = new Factory();
            iCust = oFactory.Create(cboCustType.SelectedIndex);

            iCust.FullName = txtFullName.Text;
            iCust.Address = txtAddress.Text;
            iCust.PhoneNumber = txtPhoneNo.Text;
            iCust.BillDate = dtBillDate.Value;
            iCust.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
        }
    }
}
