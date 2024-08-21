using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Database;
using ProjectDotNet.Models;


namespace ProjectDotNet.Services
{
    public class OrderService
    {

        private readonly MyDBContext db;
        public OrderService(MyDBContext _db) {
            db = _db;




            }
        public async Task<List<OrderDetails>> GetAllOrderAsync()
        {
            return await db.OrderDetails.ToListAsync();
        }

    }
}
