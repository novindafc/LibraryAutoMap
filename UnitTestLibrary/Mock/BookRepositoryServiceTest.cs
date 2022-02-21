using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;
using LibraryAutoMapper.Service;
using Ubiety.Dns.Core;

namespace UnitTestLibrary.Mock
{
    public class BookRepositoryServiceTest : IBookRepositoryService
    {
        public Task<List<BookDto>> GetBook()
        {
            List<BookDto> data = GetData();
            return Task.FromResult(data);
        }

        public Task<BookDto> GetBookById(int id)
        {
            List<BookDto> data = GetData();
            BookDto book = data.SingleOrDefault(x=>x.Id==id);
            return Task.FromResult(book);
        }

        public Task<bool> EditBook(BookDto bookDto)
        {
            List<BookDto> data = GetData();
            try
            {
                BookDto book = data.SingleOrDefault(x => x.Id == bookDto.Id);
                book.Id = bookDto.Id;
                book.Title = bookDto.Title;
                book.Author = bookDto.Author;
                book.Position = bookDto.Position;
                book.Qty = bookDto.Qty;
                book.Remains = bookDto.Remains;
            }
            catch
            {
                
                    Task.FromResult(false);
                
            }
           
           
            return Task.FromResult(true);
        }

        public Task<BookDto> AddBook(BookDto bookDto)
        {
            List<BookDto> data = GetData();
            data.Add(bookDto);
            return Task.FromResult(bookDto);
        }

        public Task<bool> DeleteBook(int id)
        {
            List<BookDto> data = GetData();
            BookDto book = data.SingleOrDefault(x=>x.Id ==id);
            data.Remove(book);
            if (book == null)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public bool BookExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<BookDto> GetData()
        {
            var data = new List<BookDto>()
            {
                new BookDto()
                {
                    Id = 1,
                    Title = "Harry Potter and The Goblet of Fire",
                    Author = "J.K Rowling",
                    Position = "A009",
                    Qty = 6,
                    Remains = 6
                },
                new BookDto()
                {
                    Id = 2,
                    Title = "Harry Potter and The Prisoner of Azkaban ",
                    Author = "J.K Rowling",
                    Position = "A007",
                    Qty = 6,
                    Remains = 6
                },
                new BookDto()
                {
                    Id = 3,
                    Title = "Harry Potter and The Chamber of Secret ",
                    Author = "J.K Rowling",
                    Position = "A008",
                    Qty = 6,
                    Remains = 6
                }

            };
            return data;
        }


    }
}