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

        public void AddProduct ( Product product ) {
            using (var db = new ModelContext()) {
                db.Products.Add(product);
                db.SaveChanges();
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

        public int CountProduct ( ) {
            using (var db = new ModelContext()) {
                return db.Products.Count();
            }
        }



        public void UpdateProduct ( Product product ) {
            using (var context = new ModelContext()) {
                context.Products.Attach(product);
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProdudct ( int id1 ) {
            using (var context = new ModelContext()) {
                var product = new Product { id = id1 };
                context.Products.Attach(product);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
