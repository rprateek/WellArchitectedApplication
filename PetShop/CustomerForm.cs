using System;
using System.Windows.Forms;
using Interfaces;
using Factory;
using FactoryDAL;
using InterfacesDAL;
using System.Collections.Generic;
namespace PetShop
{
    public partial class frmCustomer : Form
    {
        private ICustomer iCust = null;
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FillCustomer();
                // Creating Idal object of type Icustomer from 
                // Factory that returns IDal object of type ICustomer by requesting ADODal from Create method
                IDal<ICustomer> dal = FactoryDAL<IDal<ICustomer>>.Create("ADODal");
                dal.Add(iCust); // This is in memory addition 
                dal.Save(); // this is physical commit. 
                LoadGrid();
                MessageBox.Show("Success!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }             
        }

        private void FillCustomer()
        {
                iCust.FullName = txtFullName.Text;
                iCust.Address = txtAddress.Text;
                iCust.PhoneNumber = txtPhoneNo.Text;
                iCust.BillDate = dtBillDate.Value;
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
                iCust = Factory<ICustomer>.Create("Visitor").Clone();
            }
            else
            {
                iCust = Factory<ICustomer>.Create("Customer").Clone();
            }         

        }

        private void LoadGrid()
        {
            IDal<ICustomer> dal = FactoryDAL<IDal<ICustomer>>.Create("ADODal");
            List<ICustomer> lstCusts = dal.Search();
            dgCustomerList.DataSource = lstCusts;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }

}
