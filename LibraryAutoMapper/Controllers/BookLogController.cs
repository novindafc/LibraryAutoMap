using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    // [Route("api/[controller]")]
    // [ApiController]
    // public class BookLogController : ControllerBase
    // {
    //     private readonly IBookLogRepositoryService _booklogRepository;
    //
    //     public BookLogController(IBookLogRepositoryService booklogRepository)
    //     {
    //         _booklogRepository = booklogRepository ;
    //     }
    //
    //
    //     // GET: api/BookLog
    //     [HttpGet]
    //     [Route("[action]")]
    //     [Route("api/BookLog/GetBookLog")]
    //     public async Task<ActionResult<IEnumerable<BookLogDto>>> GetBookLog()
    //     {
    //         var booklog = await _booklogRepository.GetBookLog();
    //         return new JsonResult(new {
    //             status = "success",
    //             data = booklog
    //         });
    //     }
    //
    //     // GET: api/BookLog/5
    //     [HttpGet]
    //     [Route("[action]")]
    //     [Route("api/BookLog/GetBookLogById")]
    //     public async Task<ActionResult<BookLog>> GetBookLogById(int id)
    //     {
    //         var booklog = await _booklogRepository.GetBookLogById(id);
    //
    //         if (booklog == null)
    //         {
    //             return new JsonResult(new {
    //                 status = "Not Found"
    //             });
    //         }
    //
    //         return new JsonResult(new {
    //             status = "success",
    //             data = booklog
    //         });;
    //     }
    //     [HttpPut("{id}")]
    //     [Route("[action]")]
    //     [Route("api/BookLog/EditBookLog")]
    //     public async Task<IActionResult> EditBookLog(BookLogDto booklogDto)
    //     {
    //         var booklog = await _booklogRepository.EditBookLog(booklogDto);
    //         if (!_booklogRepository.BookLogExists(booklog.Id))
    //         {
    //             Response.StatusCode = StatusCodes.Status404NotFound;
    //             return new JsonResult(new
    //             {
    //                 status = "Not Found",
    //             });
    //                 
    //         }
    //         
    //         return new JsonResult(new
    //         {
    //             status = "success",
    //             data = booklog
    //         });
    //     }
    //     
    //     
    //     
    //     // POST: api/BookLog
    //     [HttpPost]
    //     [Route("[action]")]
    //     [Route("api/BookLog/AddBookLog")]
    //     public async Task<ActionResult<BookLog>> AddBookLog(BookLogDto booklogDto)
    //     {
    //         bool booklog = await _booklogRepository.AddBookLog(booklogDto);
    //        
    //
    //         if (booklog == false)
    //         {
    //             return new JsonResult(new {
    //                 status = "Book Not Found"
    //             });
    //         }
    //         return new JsonResult(new {
    //                 status = "success",
    //                 data = booklogDto,
    //         });
    //             
    //         }
    //         
    //     
    //
    //     // DELETE: api/BookLog/5
    //     [HttpDelete]
    //     [Route("[action]")]
    //     [Route("api/BookLog/DeleteBookLog")]
    //     public async Task<ActionResult<BookLog>> DeleteBookLog(int id)
    //     {
    //         var booklog = await _booklogRepository.DeleteBookLog(id);
    //         if (booklog == null)
    //         {
    //             return new JsonResult(new {
    //                 status = "Not Found"
    //             });
    //         }
    //
    //         return new JsonResult(new {
    //             status = "delete success",
    //             data = booklog
    //         });
    //     }
    //     
    //     [HttpPost]
    //     [Route("[action]")]
    //     [Route("api/BookLog/DeleteBookLog")]
    //     public async Task<ActionResult<BookLog>> EmailBookLog(BookLog booklog)
    //     {
    //         if (booklog == null)
    //         {
    //             return new JsonResult(new {
    //                 status = "Not Found"
    //             });
    //         }
    //
    //         var result = await _booklogRepository.EmailBookLog(booklog);
    //         return new JsonResult(new {
    //             status = "email sent",
    //         });
    //     }
    [Route("api/[controller]")]
    [ApiController]
    public class BookLogController : ControllerBase
    {
        private readonly IBookLogRepositoryService _booklogRepository;

        public BookLogController(IBookLogRepositoryService booklogRepository)
        {
            _booklogRepository = booklogRepository ;
        }


        // GET: api/BookLog
        [HttpGet]
        [Route("[action]")]
        [Route("api/BookLog/GetBookLog")]
        public async Task<ActionResult> GetBookLog()
        {
            var booklog = await _booklogRepository.GetBookLog();
            return Ok( new JsonResult(new {
                status = "success",
                data = booklog
            }));
        }

        // GET: api/BookLog/5
        [HttpGet]
        [Route("[action]")]
        [Route("api/BookLog/GetBookLogById")]
        public async Task<ActionResult> GetBookLogById(int id)
        {
            var booklog = await _booklogRepository.GetBookLogById(id);

            if (booklog == null)
            {
                return new JsonResult(new {
                    status = "Not Found"
                });
            }

            return Ok(new JsonResult(new {
                status = "success",
                data = booklog
            }));;
        }
        [HttpPut("{id}")]
        [Route("[action]")]
        [Route("api/BookLog/EditBookLog")]
        public async Task<IActionResult> EditBookLog(BookLogDto booklogDto)
        {
            var booklog = await _booklogRepository.EditBookLog(booklogDto);
            if (booklog == false)
            {
                // Response.StatusCode = StatusCodes.Status404NotFound;
                return Ok(new JsonResult(new
                {
                    status = "Not Found"
                }));
                    
            }
            
            return Ok(new JsonResult(new
            {
                status = "success",
                data = booklogDto
            }));
        }
        
        
        
        // POST: api/BookLog
        [HttpPost]
        [Route("[action]")]
        [Route("api/BookLog/AddBookLog")]
        public async Task<ActionResult> AddBookLog(BookLogDto booklogDto)
        {
            bool booklog = await _booklogRepository.AddBookLog(booklogDto);
            
            if (booklog == false)
            {
                return new JsonResult(new {
                    status = "Book Not Found"
                });
            }
            return Ok(new JsonResult(new {
                    status = "success",
                    data = booklogDto,
            }));
                
            }
            
        

        // DELETE: api/BookLog/5
        [HttpDelete]
        [Route("[action]")]
        [Route("api/BookLog/DeleteBookLog")]
        public async Task<ActionResult> DeleteBookLog(int id)
        {
            bool booklog = await _booklogRepository.DeleteBookLog(id);
            if (booklog == false)
            {
                return Ok(new JsonResult(new {
                    status = "Not Found"
                }));
            }

            return Ok(new JsonResult(new {
                status = "delete success",
            }));
        }
        
        [HttpPost]
        [Route("[action]")]
        [Route("api/BookLog/DeleteBookLog")]
        public async Task<ActionResult> EmailBookLog(BookLog booklog)
        {
            if (booklog == null)
            {
                return new JsonResult(new {
                    status = "Not Found"
                });
            }

            var result = await _booklogRepository.EmailBookLog(booklog);
            return new JsonResult(new {
                status = "email sent",
            });
        }

       
        
        
        
        
    }
}
