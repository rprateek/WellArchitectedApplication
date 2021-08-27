using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    public interface IValidationStrategy<INJECTTYPE>
    {
        void Validate(INJECTTYPE obj);
    }
}
