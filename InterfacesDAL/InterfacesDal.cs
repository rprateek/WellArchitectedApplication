using System;
using System.Collections.Generic;

namespace InterfacesDAL
{
    //Design Pattern - Repository Pattern
    // we are making this interface a generic interface to accept any type of class 
    // Since we are using generic type interface theis pattern will be called generic Repository Pattern
    public interface IRepository<InjectType>
    {
        void SetUnitWOrk(IUow uow); // this is for Unit of work injection
        void Add(InjectType obj); // Inmemory add
        void Update(InjectType obj); // Inmemory update
        List<InjectType> Search();
        void Save(); // Physical commit
    }

    public interface IUow // Unit of work design pattern.
    {
        void Commit();
        void Rollback();

    }
}
