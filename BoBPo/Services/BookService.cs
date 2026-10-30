using BoBPo.Data;
using BoBPo.Interfaces.Repositories;
using BoBPo.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoBPo.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;
        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public async Task<bool> AddBookAsync(string nameOfBook, string authorName)
        {
            Book book = new Book
            {
                NameOfBook = nameOfBook,
                AuthorName = authorName
            };
            try
            {
            await _bookRepository.AddBookAsync(book);
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex}");
                return false;
            }

        }
        public async Task<List<Book>> GetAll()
        {
            try
            {
                var books = await _bookRepository.GetAll();
                return books;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
