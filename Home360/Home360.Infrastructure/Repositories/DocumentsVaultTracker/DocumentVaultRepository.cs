using Home360.Application.Interfaces.Repositories.DocumentsVaultTracker;
using Home360.Domain.Entities.DocumentVault;
using Home360.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Home360.Infrastructure.Repositories.DocumentsVaultTracker
{
    public class DocumentVaultRepository : IDocumentVaultRepository
    {
        private readonly IHomeContextFactory _homeContextFactory;

        public DocumentVaultRepository(IHomeContextFactory homeContextFactory)
        {
            _homeContextFactory = homeContextFactory;
        }

        public async Task<bool> RegisterDocumentAsync(DocumentsVault document)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.DocumentVault.Add(document);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDocumentAsync(DocumentsVault document)
        {
            try
            {
                using HomeDbContext context = _homeContextFactory.CreateDbContext();
                context.DocumentVault.Update(document);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<DocumentsVault>> GetAllDocumentAsync()
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.DocumentVault.ToListAsync();
        }

        public async Task<DocumentsVault?> GetDocumentOnIdAsync(int documentId)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.DocumentVault.FirstOrDefaultAsync(x => x.DocumentId == documentId);
        }

        public async Task<List<DocumentsVault>> GetDocumentsOnUserIdAsync(int userId)
        {
            using HomeDbContext context = _homeContextFactory.CreateDbContext();
            return await context.DocumentVault.Where(x => x.DocumentId == userId).ToListAsync();
        }
    }
}
