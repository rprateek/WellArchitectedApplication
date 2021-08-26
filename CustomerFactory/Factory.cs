using System;
using CustomerLibrary;
using System.Collections.Generic;
using ICustomerLib;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace CustomerFactory
{
    //Simple Factory Pattern 
    // To improve perfomance we use singelton pattern so that it 
    // Can only be instantiated once

    public static class Factory
    {
        //static List<ICustomer> customers = null;
       static IUnityContainer oUnitCont = null;
        static Factory()
        {
            //oUnitCont = new UnityContainer();

          //  customers.Add(new Visitor());
            //customers.Add(new Customer());            

            // We can directly load the unity container here 
            //oUnitCont.RegisterType<ICustomer, Visitor> ("0"); //You can get the value from config 
            //oUnitCont.RegisterType<ICustomer, Customer>("1");


            if (ConfigurationManager.GetSection("unity") != null)
            {
                //Or We can load the entityes to be injected from the configuration file
                oUnitCont.LoadConfiguration();
            }

        }               
        public static ICustomer Create(int CustomerType)
        {            
            return oUnitCont.Resolve<ICustomer>(CustomerType.ToString()).Clone();

        }       


    }
}
