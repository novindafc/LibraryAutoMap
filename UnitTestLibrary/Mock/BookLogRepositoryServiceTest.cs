using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;
using LibraryAutoMapper.Service;

namespace UnitTestLibrary.Mock
{
    public class BookLogRepositoryServiceTest:IBookLogRepositoryService
    {
        public Task<List<BookLogDto>> GetBookLog()
        {
            List<BookLogDto> data = GetData();
            return Task.FromResult(data);
        }

        public Task<BookLogDto> GetBookLogById(int id)
        {
            List<BookLogDto> data = GetData();
            BookLogDto booklog = data.SingleOrDefault(x=>x.Id==id);
            return Task.FromResult(booklog);
        }

        public Task<bool> EditBookLog(BookLogDto booklogDto)
        {
            List<BookLogDto> data = GetData();
            BookLogDto booklog = data.SingleOrDefault(x=>x.Id==booklogDto.Id);
            if (booklog == null)
            {
                Task.FromResult(false);
            }
            booklog.Id = booklogDto.Id;
            booklog.StartTime = booklogDto.StartTime;
            booklog.EndTime = booklogDto.EndTime;
            booklog.BookId = booklogDto.BookId;
            booklog.MemberId = booklogDto.MemberId;
            booklog.Status = booklogDto.Status;
            return Task.FromResult(true);
        }

        public Task<bool> AddBookLog(BookLogDto booklogDto)
        {
            
            List<BookLogDto> data = GetData();
            List<BookDto> book = GetDataBook();
            BookDto booklog = book.SingleOrDefault(x=>x.Id==booklogDto.BookId);
            if (booklog==null)
            {
                Task.FromResult(false);
            }
            data.Add(booklogDto);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteBookLog(int id)
        {
            List<BookLogDto> data = GetData();
            BookLogDto booklog = data.SingleOrDefault(x=>x.Id ==id);
            data.Remove(booklog);
            if (booklog == null)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public bool BookLogExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<BookLog> EmailBookLog(BookLog bookLog)
        {
            throw new System.NotImplementedException();
        }
        
        public List<BookLogDto> GetData()
        {
            var data = new List<BookLogDto>()
            {
                new BookLogDto()
                {
                    Id = 1,
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today.AddDays(4),
                    BookId = 1,
                    MemberId = 2,
                    Status = "on process"
                },
                new BookLogDto()
                {
                    Id = 2,
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today.AddDays(4),
                    BookId = 3,
                    MemberId = 1,
                    Status = "on process"
                },
                new BookLogDto()
                {
                    Id = 3,
                    StartTime = DateTime.Today,
                    EndTime = DateTime.Today.AddDays(4),
                    BookId = 2,
                    MemberId = 3,
                    Status = "on process"
                }

            };
            return data;
        }
        public List<BookDto> GetDataBook()
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