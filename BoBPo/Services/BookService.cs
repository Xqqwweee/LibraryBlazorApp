using BoBPo.Interfaces.Services;
using BoBPo.Interfaces.Repositories;
using BoBPo.Data;

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

    }
}
