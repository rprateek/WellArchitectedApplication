using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces; // We need business objects here to get them inserted in database
using Microsoft.Data.SqlClient;
using Factory;
using InterfacesDAL;
namespace ADONetLibrary
{
    public class CustomerDAL : TemplateADO<CustomerBase>,IRepository<CustomerBase>
    {
      

        //We can now override the ExecuteCommand to use Customer specific execute query
        
        
        protected override void ExecuteCommand(CustomerBase obj)
        {
            // A simple insert statement to insert into tblCustomer
            objCommand.CommandText = "Insert into tblCustomer(" +
                                      "FullName," +
                                      "CustomerType," +
                                      "BillAmount," +
                                      "BillDate," +
                                      "PhoneNumber," +
                                      "Address)" +
                                      " values('" +
                                      obj.FullName + "','" +
                                      obj.CustomerType + "','" +
                                      obj.BillAmount + "','" +
                                      obj.BillDate + "','" +
                                      obj.PhoneNumber + "','" +
                                      obj.Address + "')";
            objCommand.ExecuteNonQuery();
        }

        protected override List<CustomerBase> ExecuteCommand()
        {
            List<CustomerBase> lstCust = new List<CustomerBase>();
            objCommand.CommandText = "Select * from tblCustomer";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            while (dr.Read())
            {
                // Now we need the Factory's help here to create the customer so that we can fill the information here. 
                CustomerBase objCust = Factory<CustomerBase>.Create("Customer");
                objCust.Id = Convert.ToInt32(dr["Id"]);
                objCust.FullName = dr["FullName"].ToString();
                objCust.CustomerType = dr["CustomerType"].ToString();
                objCust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                objCust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                objCust.PhoneNumber = dr["PhoneNumber"].ToString();
                objCust.Address = dr["Address"].ToString();
                lstCust.Add(objCust);
            }

            return lstCust;

        }
    }

}
