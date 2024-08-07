using ProjectDotNet.Database;

namespace ProjectDotNet.Services
{
    public class ProductServiceImpl : ProductService




    {
        private MyDBContext db;
        public ProductServiceImpl(MyDBContext _db)
        {
            db = _db;
        }

        public dynamic findAll()
        {
            return db.Products.Select(p => new {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Image = p.Image,
            }).ToList();

        }

    }
}
