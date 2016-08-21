using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testwpf3.Model;

namespace testwpf3.Repository {
    class ProductRepository : IProductRepository {

        public void AddProductAsync ( Product product ) {
            using (var db = new ModelContext()) {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public int CountProduct ( ) {
            using (var db = new ModelContext()) {
                return db.Products.Count();
            }
        }

        public List<Product> listProduct ( ) {
            using (var db = new ModelContext()) {
                return db.Products.ToList();
            }
        }

        public List<Product> listProductPagination ( int page, int limit ) {
            using (var context = new ModelContext()) {
                return context.Products
                    .OrderBy(b => b.id)
                     .Skip(limit * (page - 1))
                     .Take(limit)
                     .ToList();
            }
        }
    }
}
