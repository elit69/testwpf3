using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testwpf3.Repository {
    interface IProductRepository {
        void AddProductAsync ( Product product );
        List<Product> listProduct ( );
        List<Product> listProductPagination (int page, int limit );
        int CountProduct ( );
    }
}
