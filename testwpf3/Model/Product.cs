using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testwpf3 {

    [Table("Products")]
    class Product {
        [Key]
        public int id { set; get; }
        public String firstName { set; get; }
        public String lastName { set; get; }
    }

}
