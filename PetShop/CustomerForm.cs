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
        private string dbType = null;
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
                    IRepository<CustomerBase> dal = FactoryDAL<IRepository<CustomerBase>>.Create("ADODal");
                    dal.Add(iCust); // This is in memory addition 
                    dal.Save(); // this is physical commit. 
                    LoadGridADO();
                }
                else
                {
                    IRepository<CustomerBase> dal = FactoryDAL<IRepository<CustomerBase>>.Create("EFDal");
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
            IRepository<CustomerBase> dal = FactoryDAL<IRepository<CustomerBase>>.Create("ADODal");
            List<CustomerBase> lstCusts = dal.Search();
            dgCustomerList.DataSource = lstCusts;
        }
        private void LoadGridEF()
        {
            IRepository<CustomerBase> dal = FactoryDAL<IRepository<CustomerBase>>.Create("EFDal");
            List<CustomerBase> lstCusts = dal.Search();
            dgCustomerList.DataSource = lstCusts;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            ddChooseDAL.SelectedIndex = 0;
            if (ddChooseDAL.Text == "ADO.Net")
            {
                dbType = "ADODal";                
            }
            else
            {
                dbType = "EFDal";                
            }
            dtBillDate.Value = DateTime.Today;
            LoadGridADO();
        }

        private void ddChooseDAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddChooseDAL.Text == "ADO.Net")
            {
                dbType = "ADODal";
                LoadGridADO();
            }
            else
            {
                dbType = "EFDal";
                LoadGridEF();
            }
        }

        private void cmdUOW_Click(object sender, EventArgs e)
        {
            //IUow uow = FactoryDAL<IUow>.Create("AdoUOW"); // Factory creates the ADo.net unit of work object
            IUow uow = FactoryDAL<IUow>.Create("EfUow"); // Factory creates the Entity framework Unit of work object
            try
            {     
                /// Here we are using mulitple Multiple Repositories to insert different customers. 
                /// 
                CustomerBase cust1 = new CustomerBase();
                cust1.BillDate = DateTime.Today;
                cust1.CustomerType = "Visitor";            
                cust1.FullName = "Cust1";   
                

                IRepository<CustomerBase> dal = FactoryDAL<IRepository<CustomerBase>>.Create(dbType);
              
                dal.SetUnitWOrk(uow);
                dal.Add(cust1); // In memory Add 
                //dal.Save(); // we don't need this for uow


                cust1 = new CustomerBase();
                cust1.BillDate = DateTime.Today;
                cust1.CustomerType = "OldCustomer";
                cust1.FullName = "Cust2";
                cust1.Address = "adsfasdfasdffdgsdfgsdfg   adsfsdfasd asdf asdfasd asdf asd";
                
                IRepository<CustomerBase> dal1 = FactoryDAL<IRepository<CustomerBase>>.Create(dbType);
               
                dal1.SetUnitWOrk(uow);
                dal1.Add(cust1); // In Memory Add
                //dal1.Save();
                /// Problem - with Repository pattern
                /// First transaction will be inserted
                /// second insert will have error due to Address length
                /// 
                uow.Commit(); // if successful then commit
                LoadGridADO();
                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                uow.Rollback();// if error rollback
                MessageBox.Show(ex.Message);

            }
        }
    }

}
