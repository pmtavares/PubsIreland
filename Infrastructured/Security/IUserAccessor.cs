using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructured.Security
{
    public interface IUserAccessor
    {
        string GetCurrentUsername();
    }
}
