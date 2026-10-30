using BoBPo.Data;
using BoBPo.Interfaces.Repositories;

namespace BoBPo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _db;
        private readonly ILogger<BookRepository> _logger;
        public BookRepository(LibraryDbContext db, ILogger<BookRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<bool> AddBookAsync(Book book)
        {
            try
            {
                await _db.Books.AddAsync(book);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

            
        }
    }
}
