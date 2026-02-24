using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Home360.Infrastructure.Persistence
{
    public class HomeContextFactory : IHomeContextFactory
    {
        private readonly IConfiguration _configuration;

        public HomeContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HomeDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<HomeDbContext>();
            options.UseSqlServer(_configuration.GetConnectionString("DataSQLContext"));

            return new HomeDbContext(options.Options);
        }
    }
}
