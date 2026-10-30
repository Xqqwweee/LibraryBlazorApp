using BoBPo.Data;

namespace BoBPo.Interfaces.Services
{
    public interface IBookService
    {
        Task<bool> AddBookAsync(string nameOfBook, string authorName);
    }
}
