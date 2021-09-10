using InterfacesDAL;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ADONetLibrary
{
    public class AdoNetUow : IUow
    {
        public SqlConnection Connection { get; set; }
        public SqlTransaction Transaction { get; set; }

        public AdoNetUow()
        {
            // Connection now is initialised in this Unit of work class 
            Connection = new SqlConnection(GetConnectionString());

            Connection.Open();
            Transaction = Connection.BeginTransaction();
             
        }
        public void Commit()
        {
            Transaction.Commit();
            Connection.Close();
        }

        public void Rollback() // Design Pattern :-Adapter pattern
        {
            Transaction.Dispose();
            Connection.Close();
        }

        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.            
            return ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        }
    }
}
