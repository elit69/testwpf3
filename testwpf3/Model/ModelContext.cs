using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testwpf3.Model {
    class ModelContext : DbContext{
        public ModelContext ( ) : base("name=ModelContext"){}
        public virtual DbSet<Product> Products { get; set; }
    }
}
