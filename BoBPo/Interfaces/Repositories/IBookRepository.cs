using BoBPo.Data;

namespace BoBPo.Interfaces.Repositories
{
    public interface IBookRepository
    {
        public Task<bool> AddBookAsync(Book book);
    }
}
