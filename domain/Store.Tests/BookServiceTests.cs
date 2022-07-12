﻿using Moq;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositoryStub.Object);
            var validIsbn = "ISBN 12345-67890";

            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "", "", 0m) });

            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "", "", 0m) });

            var bookService = new BookService(bookRepositoryStub.Object);
            var invalidIsbn = "12345-67890";

            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithTitle_CallsGetAllByTitleOrAuthor()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;

            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetAllByIsbn = new[]
            {
                    new Book(idOfIsbnSearch, "", "", "", "", 0m)
                };

            bookRepository.ResultOfGetAllByTitleOrAuthor = new[]
            {
                    new Book(idOfAuthorSearch, "", "", "", "", 0m)
                };

            var bookService = new BookService(bookRepository);

            var books = bookService.GetAllByQuery("Programming");

            Assert.Collection(books, book => Assert.Equal(idOfAuthorSearch, book.Id));
        }

        //[Fact]
        //public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        //{
        //    const int idOfIsbnSearch = 1;
        //    const int idOfAuthorSearch = 2;

        //    var bookRepository = new StubBookRepository();

        //    bookRepository.ResultOfGetAllByIsbn = new[]
        //    {
        //        new Book(idOfIsbnSearch, "", "", "")
        //    };

        //    bookRepository.ResultOfGetAllByTitleOrAuthor = new[]
        //    {
        //        new Book(idOfAuthorSearch, "", "", "")
        //    };

        //    var bookService = new BookService(bookRepository);

        //    var books = bookService.GetAllByQuery("ISBN 12345-67890");

        //    Assert.Collection(books, book => Assert.Equal(idOfIsbnSearch, book.Id));
        //}

        //[Fact]
        //public void GetAllByQuery_WithTitle_CallsGetAllByTitleOrAuthor()
        //{
        //    const int idOfIsbnSearch = 1;
        //    const int idOfAuthorSearch = 2;

        //    var bookRepository = new StubBookRepository();

        //    bookRepository.ResultOfGetAllByIsbn = new[]
        //    {
        //        new Book(idOfIsbnSearch, "", "", "")
        //    };

        //    bookRepository.ResultOfGetAllByTitleOrAuthor = new[]
        //    {
        //        new Book(idOfAuthorSearch, "", "", "")
        //    };

        //    var bookService = new BookService(bookRepository);

        //    var books = bookService.GetAllByQuery("Programming");

        //    Assert.Collection(books, book => Assert.Equal(idOfAuthorSearch, book.Id));
        //}
    }
}