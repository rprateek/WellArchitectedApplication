using System;
using System.Collections.Generic;
using System.Linq;
using InterfacesDAL;
using Microsoft.EntityFrameworkCore;

namespace EFDALLibrary
{
    public class EFDalAbstract<INJECTTYPE> : IRepository<INJECTTYPE>
        where INJECTTYPE:class /// it is telling the that the type we are injecting is a class
    {

        DbContext dbcont = null; // this Dbcontext will come from UOW
        public EFDalAbstract()
        {
            dbcont = new EfUoW(); // If client doesn't call UOI it will initiated self contained transaction without commit and rollback
        }

        public void Add(INJECTTYPE obj)
        {
            /// Using the Entitytframework Set<>.Add that can be used to save the entity of type INJECTTYPE.          
            /// This only places the objects in memory ready for commit
            dbcont.Set<INJECTTYPE>().Add(obj);
        }

        public void Save()
        {
            dbcont.SaveChanges(); // This is for the physical committ to the database. 
            
        }

        public List<INJECTTYPE> Search()
        {
            //Return the collection of Injected Type objects via Entity Framework
            return dbcont.Set<INJECTTYPE>()
                .AsQueryable<INJECTTYPE>()
                .ToList<INJECTTYPE>();
        }

        public void SetUnitWOrk(IUow uow)
        {
            dbcont = ((EfUoW)uow); // Global Transaction comes into action 
        }

        public void Update(INJECTTYPE obj)
        {
            throw new NotImplementedException();
        }
    }
}
