using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;

namespace LibraryAutoMapper.Service
{
    public interface IBookRepositoryService
    {
        public Task<List<BookDto>> GetBook();
        public Task<BookDto> GetBookById(int id);
        public Task<bool> EditBook(BookDto bookDto);
        public Task<BookDto> AddBook(BookDto bookDto);
        public Task<bool> DeleteBook(int id);
        public bool BookExists(int id);
    }
}