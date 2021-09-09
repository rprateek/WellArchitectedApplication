using System;
using System.Windows.Forms;
using Interfaces;
using Factory;
using FactoryDAL;
using InterfacesDAL;
using System.Collections.Generic;
using CustomerLibrary;
namespace PetShop
{
    public partial class frmCustomer : Form
    {
        private CustomerBase iCust = null;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FillCustomer();
             
                if (ddChooseDAL.Text == "ADO.Net")
                {
                    // Creating Idal object of type Icustomer from 
                    // Factory that returns IDal object of type ICustomer by requesting ADODal from Create method
                    IDal<CustomerBase> dal = FactoryDAL<IDal<CustomerBase>>.Create("ADODal");
                    dal.Add(iCust); // This is in memory addition 
                    dal.Save(); // this is physical commit. 
                    LoadGridADO();
                }
                else
                {
                    IDal<CustomerBase> dal = FactoryDAL<IDal<CustomerBase>>.Create("EFDal");
                    dal.Add(iCust); // This is in memory addition 
                    dal.Save(); // this is physical commit. 
                    LoadGridEF();
                }
                
                
                
                MessageBox.Show("Success!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.InnerException.ToString());
            }             
        }

        private void FillCustomer()
        {
                iCust.FullName = txtFullName.Text;
                iCust.Address = txtAddress.Text;
                iCust.PhoneNumber = txtPhoneNo.Text;
                iCust.BillDate = dtBillDate.Value;
                iCust.CustomerType = cboCustType.Text;
                if (txtBillAmount.Text.Length>0)
                {
                    iCust.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
                }
        }

        private void cboCustType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Here we can pass the Visitor or customer from App.config and avoid using if. 
            if (cboCustType.SelectedIndex == 0)
            {
                
               iCust = Factory<CustomerBase>.Create("Visitor");
            }
            else
            {
                iCust = Factory<CustomerBase>.Create("Customer");
            }         

        }

        private void LoadGridADO()
        {
            IDal<CustomerBase> dal = FactoryDAL<IDal<CustomerBase>>.Create("ADODal");
            List<CustomerBase> lstCusts = dal.Search();
            dgCustomerList.DataSource = lstCusts;
        }
        private void LoadGridEF()
        {
            IDal<CustomerBase> dal = FactoryDAL<IDal<CustomerBase>>.Create("EFDal");
            List<CustomerBase> lstCusts = dal.Search();
            dgCustomerList.DataSource = lstCusts;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            ddChooseDAL.SelectedIndex = 0;

            LoadGridADO();
        }

        private void ddChooseDAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddChooseDAL.Text == "ADO.Net")
            {
                LoadGridADO();
            }
            else
            {
                LoadGridEF();
            }
        }
    }

}
