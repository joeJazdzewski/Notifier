using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Interfaces
{
    public interface IMiddleware<T>
    {
        T Read();
        void Write(T model);
    }
}
