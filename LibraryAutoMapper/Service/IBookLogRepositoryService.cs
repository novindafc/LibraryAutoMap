using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;

namespace LibraryAutoMapper.Service
{
    public interface IBookLogRepositoryService
    {
        public Task<List<BookLogDto>> GetBookLog();
        public Task<BookLogDto> GetBookLogById(int id);
        public Task<BookLogDto> EditBookLog(BookLogDto booklogDto);
        public Task<bool> AddBookLog(BookLogDto booklogDto);
        public Task<bool> DeleteBookLog(int id);
        public bool BookLogExists(int id);
        public Task<BookLog> EmailBookLog(BookLog bookLog);
    }
}