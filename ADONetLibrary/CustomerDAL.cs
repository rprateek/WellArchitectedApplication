using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces; // We need business objects here to get them inserted in database
using Microsoft.Data.SqlClient;
using Factory;
namespace ADONetLibrary
{
    public class CustomerDAL : TemplateADO<ICustomer>
    {
        public CustomerDAL(string _connStr):base( _connStr) // connection string to be passed to the template and base class
        {

        }

        //We can now override the ExecuteCommand to use Customer specific execute query
        
        
        protected override void ExecuteCommand(ICustomer obj)
        {
            // A simple insert statement to insert into tblCustomer
            objCommand.CommandText = "Insert into tblCustomer(" +
                                      "FullName," +
                                      "BillAmount," +
                                      "BillDate," +
                                      "PhoneNumber," +
                                      "Address)" +
                                      " values('" +
                                      obj.FullName + "','" +
                                      obj.BillAmount + "','" +
                                      obj.BillDate + "','" +
                                      obj.PhoneNumber + "','" +
                                      obj.Address + "')";
            objCommand.ExecuteNonQuery();
        }

        protected override List<ICustomer> ExecuteCommand()
        {
            List<ICustomer> lstCust = new List<ICustomer>();
            objCommand.CommandText = "Select * from tblCustomer";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            while (dr.Read())
            {
                // Now we need the Factory's help here to create the customer so that we can fill the information here. 
                ICustomer objCust = Factory<ICustomer>.Create("Customer");
                objCust.FullName = dr["FullName"].ToString();
                objCust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                objCust.BillDate = Convert.ToDateTime(dr["BillDate"].ToString());
                objCust.PhoneNumber = dr["PhoneNumber"].ToString();
                lstCust.Add(objCust);
            }

            return lstCust;

        }
    }
}
