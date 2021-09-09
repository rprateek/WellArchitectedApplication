using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFDALLibrary
{

    public class EFCustomerDAL:EFDalAbstract<CustomerBase>
    {
        public EFCustomerDAL(string _conStr):base(_conStr)
        {

        }

        // Here we will do Object relation mapping
        // to write mapping code we will be using OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBldr)
        {
            // Mapping code 
            // We are using EF code first approach for this demo. 
            //Currently we cannot use interface while mapping so we have to use our Customer Abstract class
            modelBldr.Entity<CustomerBase>().ToTable("tblCustomer");
        }        
    }
}
