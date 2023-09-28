using Core.Domain.Entities;

namespace Core.Domain.Contracts
{
    public interface IWriterRepository
    {
        Task<Writer> GetById(int id);
        Task<List<Writer>> Get();
    }
}
