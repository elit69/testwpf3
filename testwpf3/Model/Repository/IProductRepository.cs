using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testwpf3.Repository {
    interface IProductRepository {
        void AddProduct ( Product product );
        List<Product> listProductPagination (int page, int limit );
        int CountProduct ( );

        void UpdateProduct ( Product product);
        void DeleteProdudct ( int id );
    }
}
