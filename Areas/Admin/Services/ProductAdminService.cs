using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Database;

namespace ProjectDotNet.Areas.Admin.Service
{
    [Area("Admin")]
    public class ProductAdminService
    {
        private MyDBContext db;
        public ProductAdminService(MyDBContext _db)
        {
            db = _db;
        }

    }
    
 
   
}
