using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Middleware.Interfaces;

namespace Middleware.Classes
{
    public class Middleware<T> : IMiddleware<T>
    {
        public virtual T Read()
        {
            return default(T);
        }

        public virtual void Write(T Model)
        {
            return;
        }
    }
}
