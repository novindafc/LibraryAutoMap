using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAutoMapper.DbContext;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ubiety.Dns.Core;

namespace LibraryAutoMapper.Service
{
    public class BookRepositoryService:IBookRepositoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookRepositoryService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       
        public async Task<List<BookDto>> GetBook()
        {
            var book = await _context.Book.ToListAsync();
            return _mapper.Map<List<BookDto>>(book);
           
        }

        
        public async Task<BookDto> GetBookById(int id)
        {
            var book = await _context.Book.FindAsync(id);
            return _mapper.Map<BookDto>(book);
            
        }

        public async Task<bool> EditBook(BookDto bookDto)
        {
            int id = bookDto.Id;

            var book = _context.Entry(_mapper.Map<Book>(bookDto)).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            if (book == null)
            {
                return false;
            }
            return true;
        }

        public async Task<BookDto> AddBook(BookDto bookDto)
        {
            _context.Book.Add(_mapper.Map<Book>(bookDto));
            await _context.SaveChangesAsync();
            // var result = CreatedAtAction("AddBook", new { id = book.Id }, book);

            return bookDto;
        }

       
        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(_mapper.Map<Book>(book));
            await _context.SaveChangesAsync();
            if (book == null)
            {
                return false;
            }
            return true;
        }

        public bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}