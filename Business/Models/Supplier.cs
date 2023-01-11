using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Supplier : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public TypeSupplier TypeSupplier { get; set; }
        public bool Active { get; set; }

    }
}
