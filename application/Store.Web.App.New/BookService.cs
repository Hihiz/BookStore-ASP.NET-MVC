using Store.Memory;
using System.Collections.Generic;
using System.Linq;

namespace Store.Web.App.New
{
    public class BookService
    {
        private readonly BookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = (BookRepository)bookRepository;
        }

        public BookModel GetById(int id)
        {
            var book = bookRepository.GetById(id);

            return Map(book);
        }

        public IReadOnlyCollection<BookModel> GetAllByQuery(string query)
        {
            var books = Book.IsIsbn(query)
                      ? bookRepository.GetAllByIsbn(query)
                      : bookRepository.GetAllByTitleOrAuthor(query);

            return books.Select(Map)
                        .ToArray();
        }

        private BookModel Map(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
            };
        }
    }
}
