using System;
using DataAccessLibrary;
using InterfacesDAL;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace ADONetLibrary
{
    public abstract class TemplateADO<InjectType>:AbstractDal<InjectType>
    {
        //Declaring connection and command objects
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;

        IUow uowObj = null;
        public override void SetUnitWOrk(IUow uow)
        {
            // In this one open the connection with transaction attacthed with it.    
            uowObj = uow;            
            objConn = ((AdoNetUow)uow).Connection;
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
            objCommand.Transaction = ((AdoNetUow)uow).Transaction;
           

        }
        
        
        private void OpenConn()
        {

            if (objConn==null) // IF the transaction connection is not open then open a new connection without Transactoin
            {
                objConn = new SqlConnection(GetConnectionString());
                objConn.Open();
                objCommand = new SqlCommand();
                objCommand.Connection = objConn;
            }
            
        }
        private void CloseConn()
        {
            if (uowObj==null)
            {
                objConn.Close();
            }
            
        }
        
        //This will be overridden by the child class as per their sql execution queries.
        // they can attach a search, insert or update queries. 
        protected abstract void ExecuteCommand(InjectType obj);
        protected abstract List<InjectType> ExecuteCommand();

        public void Execute(InjectType obj) // This does the insert 
        {
            ///Follow the fixed ADO.net template 
            OpenConn();
            ExecuteCommand(obj);
            CloseConn();

        }

        public List<InjectType> Execute() // returning the list 
        {
            ///Follow the fixed ADO.net template 
            List<InjectType> lst = null;
            OpenConn();
            lst =  ExecuteCommand();
            CloseConn();
            return lst;
        }

        // override the save function from the ABstractDal
        public override void Save()
        {
            foreach (InjectType obj in lstObj)
            {
                Execute(obj);
            }
        }
        public override List<InjectType> Search()
        {
            return Execute();
        }
        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code,
            // you can retrieve it from a configuration file.            
            return ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        }
    }

   

}
