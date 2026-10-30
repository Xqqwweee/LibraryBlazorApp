using BoBPo.Data;

namespace BoBPo.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<bool> AddBookAsync(Book book);
    }
}
