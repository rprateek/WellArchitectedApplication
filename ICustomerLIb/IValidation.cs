using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Validation Interface that has a Validation class and is Generic Interface where we can inject Type

namespace Interfaces
{
    public interface IValidation<InjectType>
    {
        void Validate(InjectType obj);
    }
}
