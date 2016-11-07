using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface INotifierModel
    {
        string Expiration { get; set; }
        string Message { get; set; }
    }
}
