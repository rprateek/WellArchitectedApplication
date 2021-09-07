using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDAL;

namespace DataAccessLibrary
{
    public abstract class AbstractDal<InjectType> : IDal<InjectType>
    {
        //since connection string will be used by child classes so we are making it protected
        protected string ConnectionString = "";
        // we will pass the connection string to the Constructor of this AbstractDal class
        public AbstractDal(string _connString)
        {
            ConnectionString = _connString;

        }

        // make sure the list is available in the child classes
       protected List <InjectType> lstObj = new List<InjectType>();
        public virtual void Add(InjectType obj)
        {
            lstObj.Add(obj);
        }

        public virtual void Save()
        {            
            throw new NotImplementedException();
        }

        public virtual List<InjectType> Search()
        {
            throw new NotImplementedException();
        }

        public virtual void Update(InjectType obj)
        {
            lstObj.Add(obj);
        }
    }
}
