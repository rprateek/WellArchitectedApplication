using System;
using DataAccessLibrary;
using InterfacesDAL;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace ADONetLibrary
{
    public abstract class TemplateADO<InjectType>:AbstractDal<InjectType>
    {
        //Declaring connection and command objects
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;

        //Pass Inject the connection string as required by the base class
        public TemplateADO(string _connStr):base(_connStr)
        {

        }
        private void OpenConn()
        {
            objConn = new SqlConnection(ConnectionString);
            objConn.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
        }
        private void CloseConn()
        {
            objConn.Close();
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

    }

   

}
