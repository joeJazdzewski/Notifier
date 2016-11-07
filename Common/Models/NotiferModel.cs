using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common.Models
{
    public class NotiferModel : INotifierModel
    {
        private DateTime _dtExpiration { get; set; }

        public string Expiration {
            get
            {
                return _dtExpiration.ToLongDateString();
            }
            set
            {
                _dtExpiration = DateTime.Parse(value);
            }
        }

        public string Message { get; set; }

        public NotiferModel()
        {
            _dtExpiration = DateTime.MinValue;
            Message = "Hi, I'm the NotifierModel";
        }

        public DateTime GetExpirationDate()
        {
            return _dtExpiration;
        }
    }
}
