using System;
using System.Collections.Generic;

namespace InterfacesDAL
{
    //Design Pattern to be used here 
    //Repository Pattern
    // we are making this interface a generic interface to accept any type of class 
    // Since we are using generic type interface theis pattern will be called generic Repository Pattern
    public interface IDal<InjectType>
    {
        
        void Add(InjectType obj); // Inmemory add
        void Update(InjectType obj); // Inmemory update
        List<InjectType> Search();
        void Save(); // Physical commit
    }
}
