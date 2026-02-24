namespace Home360.Infrastructure.Persistence
{
    public interface IHomeContextFactory
    {
        HomeDbContext CreateDbContext();
    }
}
