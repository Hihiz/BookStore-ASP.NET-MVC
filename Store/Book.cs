using Store.Data;
using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        private readonly BookDto dto;

        public int Id => dto.Id;

        public string Isbn
        {
            get => dto.Isbn;
            set => dto.Isbn = value;
        }

        public string Author
        {
            get => dto.Author;
            set => dto.Author = value?.Trim();
        }

        public string Title
        {
            get => dto.Title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(nameof(Title));

                dto.Title = value.Trim();
            }
        }

        public string Description
        {
            get => dto.Description;
            set => dto.Description = value;
        }

        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }

        internal Book(BookDto dto)
        {
            this.dto = dto;
        }

        public static bool IsIsbn(string s)
        {
            if (s == null)
                return false;

            s = s.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
        }
    }
}