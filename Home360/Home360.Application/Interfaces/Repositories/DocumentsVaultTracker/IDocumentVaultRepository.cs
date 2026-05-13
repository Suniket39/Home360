using Home360.Domain.Entities.DocumentVault;

namespace Home360.Application.Interfaces.Repositories.DocumentsVaultTracker
{
    public interface IDocumentVaultRepository
    {
        Task<bool> RegisterDocumentAsync(DocumentsVault  bill);
        Task<bool> UpdateDocumentAsync(DocumentsVault bill);
        Task<List<DocumentsVault>> GetAllDocumentAsync();
        Task<DocumentsVault?> GetDocumentOnIdAsync(int documentId);
        Task<List<DocumentsVault>> GetDocumentsOnUserIdAsync(int userId);
    }
}
