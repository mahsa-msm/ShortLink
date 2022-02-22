using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortLink.Domain
{
    public class BaseEntity<Ikey>
    {
        public Ikey Id { get; set; }
    }
}
