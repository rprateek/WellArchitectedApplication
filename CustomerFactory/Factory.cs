using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Interfaces;
using CustomerLibrary;
using ValidationLogic;

namespace Factory
{
    //Design pattern :- Simple Factory Pattern 
    // To improve perfomance we use singelton pattern 
    // Follow IOC principle using Dependency Injection via Unity 
    // Make this class Generic so that the logic is decoupled from the data type.

    public static class Factory<INJECTTYPE>
    {
        static IUnityContainer oUnitCont = null;
       
        public static INJECTTYPE Create(string CustType) // will return whatever type is injected
        {
            if (oUnitCont==null)
            {
                if (ConfigurationManager.GetSection("unity") != null)
                {
                    oUnitCont = new UnityContainer();
                    //Here we are registering different customer types and injecting the validation methods accordingly
                    //Or We can load the entities to be injected from the configuration file
                    // oUnitCont.LoadConfiguration();

                    oUnitCont.RegisterType<CustomerBase, Visitor>("Visitor", new InjectionConstructor(new VisitorValidation()));
                    oUnitCont.RegisterType<CustomerBase, Customer>("Customer", new InjectionConstructor(new CustomerValidation()));                                    

                    
                }
            }
            return oUnitCont.Resolve<INJECTTYPE>(CustType.ToString()); //resolves to any type injected

        }
        
    }
}
