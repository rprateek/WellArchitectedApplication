using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Factory
{
    //Design pattern :- Simple Factory Pattern 
    // To improve perfomance we use singelton pattern 
    // Follow IOC principle using Dependency Injection via Unity 
    // Make this class Generic so that the logic is decoupled from the data type.

    public static class Factory<INJECTTYPE>
    {
        static IUnityContainer oUnitCont = null;
        static Factory()
        {

            if (ConfigurationManager.GetSection("unity") != null)
            {
                oUnitCont = new UnityContainer();
                //Or We can load the entities to be injected from the configuration file
                oUnitCont.LoadConfiguration();
            }

        }
        public static INJECTTYPE Create(string Type) // will return whatever type is injected
        {
            return oUnitCont.Resolve<INJECTTYPE>(Type.ToString()); //resolves to any type injected

        }

    }
}
