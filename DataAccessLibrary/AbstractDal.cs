using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDAL;

namespace DataAccessLibrary
{
    public abstract class AbstractDal<InjectType> : IRepository<InjectType>
    {            

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

        public virtual void SetUnitWOrk(IUow uow)
        {
            
        }
    }
}
