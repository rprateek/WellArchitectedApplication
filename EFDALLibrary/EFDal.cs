using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfacesDAL;
using Microsoft.EntityFrameworkCore;


namespace EFDALLibrary
{
    
    public abstract class EFDalAbstract<INJECTTYPE> : DbContext, IDal<INJECTTYPE>
        where INJECTTYPE:class /// it is telling the that the type we are injecting is a class
    {

        public EFDalAbstract(string _conStr)
            :base(GetSQLOptions(_conStr)) // we have to pass DbcontextOptions in .net 5.0 , earlier we could have passed the string itself
        {
        }

        private static DbContextOptions GetSQLOptions(string connectionString)
        {
            //creating dbcontextOptions by passing the connection String            
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public void Add(INJECTTYPE obj)
        {
            /// Using the Entitytframework Set<>.Add that can be used to save the entity of type INJECTTYPE.          
            /// This only places the objects in memory ready for commit
            Set<INJECTTYPE>().Add(obj);
        }

        public void Save()
        {
            SaveChanges(); // This is for the physical committ to the database. 
        }

        public List<INJECTTYPE> Search()
        {
            //Return the collection of Injected Type objects via Entity Framework
            return Set<INJECTTYPE>()
                .AsQueryable<INJECTTYPE>()
                .ToList<INJECTTYPE>();
        }

        public void Update(INJECTTYPE obj)
        {
            throw new NotImplementedException();
        }
    }
}
