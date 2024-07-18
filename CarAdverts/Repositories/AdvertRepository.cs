using CarAdverts.Data;
using CarAdverts.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdverts.Repositories
{
    public class AdvertRepository : IAdvertRepository
    {
        private readonly DapperContext _context;
        public AdvertRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Advert>> GetAdvertsAsync(int categoryId, decimal? price, string gear, string fuel, int page, string sortBy)
        {
            var query = new StringBuilder("SELECT * FROM Adverts WHERE 1=1");
            var parameters = new DynamicParameters();

            if (categoryId > 0)
            {
                query.Append("AND CategoryId = @CategoryId");
                parameters.Add("CategoryId",categoryId);
            }
            if (price.HasValue)
            {
                query.Append("AND Price <= @Price");
                parameters.Add("Price",price.Value);
            }
            if (!string.IsNullOrEmpty(fuel))
            {
                query.Append("AND Fuel = @Fuel");
                parameters.Add("Fuel", fuel);
            }
            if (!string.IsNullOrEmpty(gear))
            {
                query.Append("AND Gear = @Gear");
                parameters.Add("Gear", gear);
            }
            query.Append($"ORDER BY {sortBy} OFFSET @Offset ROWS FETCH NEXT 20 ROWS ONLY");
            parameters.Add("Offset", (page - 1) * 10);

            using (var connection = _context.CreateConnection())
            {
                var adverts = await connection.QueryAsync<Advert>(query.ToString(), parameters);
                return adverts.ToList();
            }


        }
    }
}
