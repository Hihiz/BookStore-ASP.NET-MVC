using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 0201896834", "D. Knuth", "Art Of Programming",
                     "This  first  volume  begins  with  basic  programming concepts  and  techniques,  then  focuses  oninformation  structures — the  representation of  information  inside  a computer,  the  structural relationships  between  data  elements  and  how to  deal  with  them  efficiently.  Elementary applications  are  given  to  simulation,  numerical methods,  symbolic  computing,  software  and system  design.",
                     7.19m),

            new Book(2, "ISBN 0201485672", "M. Fowler", "Refactoring",
                     "Martin Fowler is Chief Scientist at ThoughtWorks. He describes himself as “an author, speaker, consultant and general loud-mouth on software development.” Fowler concentrates on designing enterprise software: exploring what makes a good design and what practices are needed to create one.",
                     12.34m),

            new Book(3, "ISBN 0131101633", "B. Kernighan, D. Ritchie", "C Programming Language",
                     "This reference guide describes the C++ programming language as of May 1991. C++ is a general-purpose programming language based on the C++ programming language.",
                     14.98m)
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                .ToArray();
        }

        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart))
                .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                        .ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}