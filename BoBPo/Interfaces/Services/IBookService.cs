using BoBPo.Data;
using Microsoft.AspNetCore.Mvc;

namespace BoBPo.Interfaces.Services
{
    public interface IBookService
    {
        Task<bool> AddBookAsync(string nameOfBook, string authorName);
        Task<List<Book>> GetAll();
    }
}
