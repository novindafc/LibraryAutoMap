using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAutoMapper.DbContext;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;
using LibraryAutoMapper.Service;

namespace LibraryAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepositoryService _bookRepository;

        public BookController(IBookRepositoryService bookRepository)
        {
            _bookRepository = bookRepository ;
        }

        // GET: api/Book
        [HttpGet]
        [Route("[action]")]
        [Route("api/Book/GetBook")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            var result = await _bookRepository.GetBook();
            return Ok(new JsonResult(new {
                status = "success",
                data = result
            }));
        }

        // GET: api/Book/5
        [HttpGet]
        [Route("[action]")]
        [Route("api/Book/GetBookById")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            
            var result =  await _bookRepository.GetBookById(id);

            if (result == null)
            {
                return Ok(new JsonResult(new {
                    status = "Not Found"
                }));
            }

            return Ok(new JsonResult(new {
                status = "success",
                data = result
            }));
        }
        [HttpPut("{id}")]
        [Route("[action]")]
        [Route("api/Employee/EditBook")]
        public async Task<IActionResult> EditBook(BookDto bookDto)
        { 
            var result =  await _bookRepository.EditBook(bookDto);
            if (result==false)
            {
                return Ok(new JsonResult(new
                    {
                        status = "Not Found",
                    }));
            }

            return Ok(new JsonResult(new
            {
                status = "success",
                data = bookDto
            }));
        }

        

        [HttpPost]
        [Route("[action]")]
        [Route("api/Book/AddBook")]
        public async Task<ActionResult<Book>> AddBook(BookDto bookDto)
        {
            var result =  await _bookRepository.AddBook(bookDto);
            // var result = CreatedAtAction("AddBook", new { id = book.Id }, book);

            return Ok(new JsonResult(new {
                status = "success",
                data = result
            }));
        }

        // DELETE: api/Book/5
        [HttpDelete]
        [Route("[action]")]
        [Route("api/Book/DeleteBook")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            bool result = await _bookRepository.DeleteBook(id);
            if (result == false)
            {
                return Ok(new JsonResult(new
                {
                    status = "Not Found"
                }));
            }

            return Ok(new JsonResult(new
            {
                status = "delete success",
            }));
        }
    }
        
    
}
