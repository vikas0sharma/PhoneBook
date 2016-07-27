using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ContactEntity
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public Nullable<long> MobileNo { get; set; }
    }
}
