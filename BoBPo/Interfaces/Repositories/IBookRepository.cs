using BoBPo.Data;
using Microsoft.AspNetCore.Mvc;

namespace BoBPo.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<bool> AddBookAsync(Book book);
        Task<List<Book>> GetAll();
    }
}
