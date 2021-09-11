using Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EFDALLibrary
{
    // this class actually can be removed as its job is handled by unit of work now
    public class EFCustomerDAL:EFDalAbstract<CustomerBase>
    {
        
        // Here we will do Object relation mapping
        // to write mapping code we will be using OnModelCreating
       
        // This is moved to Unit of work so it is not necessary
        //protected override void OnModelCreating(ModelBuilder modelBldr)
        //{
        //    // Mapping code 
        //    // We are using EF code first approach for this demo. 
        //    //Currently we cannot use interface while mapping so we have to use our Customer Abstract class
        //    modelBldr.Entity<CustomerBase>().ToTable("tblCustomer");
        //}        

       
    }



}
