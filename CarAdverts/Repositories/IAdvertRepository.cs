using CarAdverts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarAdverts.Repositories
{
    public interface IAdvertRepository
    {
        Task<IEnumerable<Advert>> GetAdvertsAsync(int categoryId, decimal? price, string gear, string fuel, int page, string sortBy);
    }
}
