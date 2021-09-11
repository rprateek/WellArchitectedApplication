using Microsoft.Practices.Unity;
using System.Configuration;
using InterfacesDAL;
using ADONetLibrary;
using Interfaces;
using EFDALLibrary;
namespace FactoryDAL
{
    public static class FactoryDAL<INJECTTYPE>
    {
        static IUnityContainer oUnitCont = null;

        public static INJECTTYPE Create(string Type) // will return whatever type is injected
        {
            if (oUnitCont == null)
            {
                if (ConfigurationManager.GetSection("unity") != null)
                {
                    oUnitCont = new UnityContainer();

                    //Injecting the _connStr in the constructor as main base class Abstract Dal needs connection string to be injected in constructor.
                    //string _connStr = GetConnectionString();
                    //oUnitCont.RegisterType<IRepository<CustomerBase>, CustomerDAL>("ADODal", new InjectionConstructor(_connStr));
                    //oUnitCont.RegisterType<IRepository<CustomerBase>, EFCustomerDAL>("EFDal", new InjectionConstructor(_connStr));                 
                 

                    oUnitCont.RegisterType<IRepository<CustomerBase>, CustomerDAL>("ADODal");                    
                    oUnitCont.RegisterType<IRepository<CustomerBase>, EFDalAbstract<CustomerBase>>("EFDal");
                    oUnitCont.RegisterType<IUow,AdoNetUow>("AdoUOW");
                    oUnitCont.RegisterType<IUow, EfUoW>("EfUow");
                }
            }
            return oUnitCont.Resolve<INJECTTYPE>(Type.ToString()); //resolves to any type injected

        }

        //for now we are just passing the connection string here manually 
        // we will have to change this to more elegant way later. 
        //static private string GetConnectionString()
        //{
        //    // To avoid storing the connection string in your code,
        //    // you can retrieve it from a configuration file.            
        //    return ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        //}
        // Moved to Unit of work class 

    }
}
