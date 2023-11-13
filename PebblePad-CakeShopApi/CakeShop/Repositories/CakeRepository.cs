using CakeShop.Data;
using CakeShop.Models;

namespace CakeShop.Repositories
{
    public class CakeRepository : Repository<Cake>, ICakeRepository
    {
        public CakeRepository(ILiteDBProvider<Cake> liteDBProvider) : base(liteDBProvider)
        {
        }

    }
}
