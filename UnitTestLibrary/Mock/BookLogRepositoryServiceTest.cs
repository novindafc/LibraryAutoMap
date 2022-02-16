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

        public Task<BookLogDto> EditBookLog(BookLogDto booklogDto)
        {
            List<BookLogDto> data = GetData();
            BookLogDto booklog = data.SingleOrDefault(x=>x.Id==booklogDto.Id);
            booklog.Id = booklogDto.Id;
            booklog.StartTime = booklogDto.StartTime;
            booklog.EndTime = booklogDto.EndTime;
            booklog.BookId = booklog.BookId;
            booklog.MemberId = booklog.MemberId;
            booklog.Status = booklog.Status;
            return Task.FromResult(booklogDto);
        }

        public Task<bool> AddBookLog(BookLogDto booklogDto)
        {
            List<BookLogDto> data = GetData();
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
                
    }
}