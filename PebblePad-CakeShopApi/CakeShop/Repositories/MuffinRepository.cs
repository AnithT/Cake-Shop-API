using CakeShop.Data;
using CakeShop.Models;

namespace CakeShop.Repositories
{
    public class MuffinRepository : Repository<Muffin>, IMuffinRepository
    {
        public MuffinRepository(ILiteDBProvider<Muffin> liteDBProvider) : base(liteDBProvider)
        {
        }

    }
}
