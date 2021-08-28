using System;
using System.Windows.Forms;
using ICustomerLib;
using Factory;
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
            try
            {
                ICustomer iCust = null;
                iCust = Factory<ICustomer>.Create(cboCustType.SelectedIndex.ToString()).Clone();


                iCust.FullName = txtFullName.Text;
                iCust.Address = txtAddress.Text;
                iCust.PhoneNumber = txtPhoneNo.Text;
                iCust.BillDate = dtBillDate.Value;
                if (txtBillAmount.Text.Length>0)
                {
                    iCust.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
                }
                

                iCust.Validate();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
            
           

        }
    }

}
