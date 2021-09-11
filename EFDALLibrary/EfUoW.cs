using InterfacesDAL;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Logging;
namespace EFDALLibrary
{
    public class EfUoW : DbContext, IUow
    {

        DbContext context = null;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapping code 
            // We are using EF code first approach for this demo. 
            //Currently we cannot use interface while mapping so we have to use our Customer Abstract class
            modelBuilder.Entity<CustomerBase>().ToTable("tblCustomer");
            
        }
      

        public EfUoW():base(GetSQLOptions())// provide connction string to the EF Dbcontext
        {
            
        }
        public void Commit()
        {
            SaveChanges();            
            
        }

        public void Rollback() // Adaptor pattern
        {
            Dispose();
        }

        private static DbContextOptions GetSQLOptions()
        {
            //creating dbcontextOptions by passing the connection String
            //                       
            return SqlServerDbContextOptionsExtensions.UseSqlServer
                (new DbContextOptionsBuilder(), ConfigurationManager.ConnectionStrings["Conn"].ConnectionString).Options;
        }
    }
}
