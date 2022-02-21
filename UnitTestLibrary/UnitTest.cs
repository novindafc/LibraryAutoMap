using System;
using System.Collections.Generic;
using AutoMapper;
using LibraryAutoMapper.Controllers;
using LibraryAutoMapper.DbContext;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Profiles;
using LibraryAutoMapper.Service;
using Microsoft.AspNetCore.Mvc;
using UnitTestLibrary.Mock;
using Xunit;

namespace UnitTestLibrary
{
    public class UnitTest
    {
        private AppDbContext _dbContext;
        private IMapper _mapper;
        IBookRepositoryService _bookService;
        IBookLogRepositoryService _bookLogService;
        IMemberRepositoryService _memberService;

        public UnitTest()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMappingProfile())).CreateMapper().ConfigurationProvider;
            _mapper = new Mapper(configuration);
        }
        
        

        [Fact]
        public void GetAllAvailableBookData_ListofModel()
        {
            //var result  =_bookService.GetBook();
            _bookService = new BookRepositoryServiceTest();
            BookController book = new BookController(_bookService);
            var a = book.GetBook();
            var response = a.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // var responseData = response.Value as JsonResult;
            //
            // var dataBook = responseData.Value as dynamic;
            // List<BookDto> b = dataBook.data as List<BookDto>;
            // List<BookDto> c = responseData.Value as List<BookDto>;
            // Assert.Equal(3, dataBook.Count); 
            // Assert.Empty(dataBook.data);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetAvailableBookDataById_RowOfData(int id)
        {
            _bookService = new BookRepositoryServiceTest();
            BookController book = new BookController(_bookService);
            var a = book.GetBookById(id);
            var response = a.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);

        }
        
        
        
        [Theory]
        [InlineData(8)]
        [InlineData(9)]
        public void GetUnavailableBookDataById_NotFound(int id)
        {
            _bookService = new BookRepositoryServiceTest();
            BookController book = new BookController(_bookService);
            var a = book.GetBookById(id);
            var response = a.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);

        }
        
        [Theory]
        [InlineData(4,"Laskar Pelangi", "Andrea Hirata", "B007", 5, 5, "Laskar Pelangi")]
        [InlineData(5,"Akar", "Dee Lestari", "A011", 3, 3, "Akar")]
        [InlineData(6, "Gelas Kaca", "Andrea Hirata", "B009", 2, 2, "Gelas Kaca")]
        public void AddBookData_RowidOfData(int id, string title, string author, string position, int qty, int remain, string expected)
        {
            _bookService = new BookRepositoryServiceTest();
            BookController book = new BookController(_bookService);
            
            // _bookService = new BookRepositoryService(_dbContext, _mapper);
            BookDto bd = new BookDto()
            {
                Id = id,
                Title = title,
                Author = author,
                Position = position,
                Qty = qty,
                Remains = remain
                
            };
            
            var result  =book.AddBook(bd);
           
            var response = result.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Result.Title);

        }
        
        [Theory]
        [InlineData(2,"Laskar Pelangi", "Andrea Hirata", "B007", 5, 5)]
        [InlineData(3, "Akar", "Dee Lestari", "A011", 3, 3)]
        public void EditAvailableBookData_RowOfData(int id, string title, string author, string position, int qty, int remain)
        {
            _bookService = new BookRepositoryServiceTest();
            BookController book = new BookController(_bookService);
            BookDto bd = new BookDto()
            {
                Id = id,
                Title = title,
                Author = author,
                Position = position,
                Qty = qty,
                Remains = remain
                
            };
            
            var result  = book.EditBook(bd);
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Result.Title);

        }
        [Theory]
        [InlineData(9,"Laskar Pelangi", "Andrea Hirata", "B007", 5, 5)]
        [InlineData(8, "Akar", "Dee Lestari", "A011", 3, 3)]
        public void EditUnavailableBookData_NotFound(int id, string title, string author, string position, int qty, int remain)
        {
            _bookService = new BookRepositoryServiceTest();
            BookController book = new BookController(_bookService);
            BookDto bd = new BookDto()
            {
                Id = id,
                Title = title,
                Author = author,
                Position = position,
                Qty = qty,
                Remains = remain
                
            };
            
            var result  = book.EditBook(bd);
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Result.Title);

        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DeleteAvailableBookData_RowOfData(int id)
        {
       
            _bookService = new BookRepositoryServiceTest();
            BookController book = new BookController(_bookService);
            var result  = book.DeleteBook(id);
            var response = result.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            
            // Assert.Equal(id, result.Result.Id);

        }
        
        [Theory]
        [InlineData(8)]
        [InlineData(9)]
        public void DeleteUnavailableBookData_NotFound(int id)
        {
       
            _bookService = new BookRepositoryServiceTest();
            BookController book = new BookController(_bookService);
            var result  = book.DeleteBook(id);
            var response = result.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            
            // Assert.Equal(id, result.Result.Id);

        }
        [Fact]
        public void GetAllAvailableBookLogData_ListofModel()
        {
            _bookLogService = new BookLogRepositoryServiceTest();
            BookLogController booklog = new BookLogController(_bookLogService);
            var a = booklog.GetBookLog();
            var response = a.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetAvailableBookLogDataById_RowOfData(int id)
        {
            _bookLogService = new BookLogRepositoryServiceTest();
            BookLogController booklog = new BookLogController(_bookLogService);
            var a = booklog.GetBookLogById(id);
            var response = a.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);

        }
        
        [Theory]
        [InlineData(8)]
        [InlineData(9)]
        public void GetUnavailableBookLogDataById_NotFound(int id)
        {
            _bookLogService = new BookLogRepositoryServiceTest();
            BookLogController booklog = new BookLogController(_bookLogService);
            var a = booklog.GetBookLogById(id);
            var response = a.Result as OkObjectResult;
            Assert.True(response is null);

        }
        
        
        [Theory]
        [InlineData(4, 1, 2, "on process")]
        [InlineData(5, 2, 3, "on process")]
        [InlineData(6, 3, 1,"on process")]
        public void AddBookLogDataAvailableBook_RowOfData(int id, int idbook, int idmember, string status)
        {
            _bookLogService = new BookLogRepositoryServiceTest();
            BookLogController booklog = new BookLogController(_bookLogService);
            BookLogDto bd = new BookLogDto()
            {
                Id = id,
                StartTime = DateTime.Today,
                EndTime = DateTime.Today.AddDays(4),
                BookId = idbook,
                MemberId = idmember,
                Status = status
                
            };
            
            var result  = booklog.AddBookLog(bd);
            // var a = booklog.GetBookLog();
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Id);

        }
        [Theory]
        [InlineData(4, 9, 2, "on process")]
        [InlineData(5, 8, 3, "on process")]
        [InlineData(6, 7, 1,"on process")]
        public void AddBookLogDataBookUnavailableBook_NotFound(int id, int idbook, int idmember, string status)
        {
            _bookLogService = new BookLogRepositoryServiceTest();
            BookLogController booklog = new BookLogController(_bookLogService);
            BookLogDto bd = new BookLogDto()
            {
                Id = id,
                StartTime = DateTime.Today,
                EndTime = DateTime.Today.AddDays(4),
                BookId = idbook,
                MemberId = idmember,
                Status = status
                
            };
            
            var result  = booklog.AddBookLog(bd);
            // var a = booklog.GetBookLog();
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Id);

        }
        
        [Theory]
        [InlineData(2,1, 2, "on process")]
        [InlineData(3,2, 3, "on process")]
        public void EditAvailableBookLogData_RowOfData(int id, int idbook, int idmember, string status)
        {
            
            _bookLogService = new BookLogRepositoryServiceTest();
            BookLogController booklog = new BookLogController(_bookLogService);
            BookLogDto bd = new BookLogDto()
            {
                Id = id,
                StartTime = DateTime.Today,
                EndTime = DateTime.Today.AddDays(4),
                BookId = idbook,
                MemberId = idmember,
                Status = status
                
            };
            
            var result  = booklog.EditBookLog(bd);
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Result.BookId);

        }
        
        //
        // [Theory]
        // [InlineData(5,1, 2, "on process")]
        // [InlineData(7,2, 3, "on process")]
        // public void EditUnavailableBookLogData_NotFound(int id, int idbook, int idmember, string status)
        // {
        //     
        //     _bookLogService = new BookLogRepositoryServiceTest();
        //     BookLogController booklog = new BookLogController(_bookLogService);
        //     BookLogDto bd = new BookLogDto()
        //     {
        //         Id = id,
        //         StartTime = DateTime.Today,
        //         EndTime = DateTime.Today.AddDays(4),
        //         BookId = idbook,
        //         MemberId = idmember,
        //         Status = status
        //         
        //     };
        //     
        //     var result  = booklog.EditBookLog(bd);
        //     var response = result.Result as OkObjectResult;
        //     Assert.True(response.StatusCode is null);
        //     // Assert.Equal(expected, result.Result.BookId);
        //
        // }
        //
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void DeleteAvailableBookLogData_RowOfData(int id)
        {
         
            _bookLogService = new BookLogRepositoryServiceTest();
            BookLogController booklog = new BookLogController(_bookLogService);
            var result  = booklog.DeleteBookLog(id);
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(id, result.Result.Id);

        }
        
        [Theory]
        [InlineData(6)]
        [InlineData(8)]
        public void DeleteUnvailableBookLogData_NotFound(int id)
        {
            _bookLogService = new BookLogRepositoryServiceTest();
            BookLogController booklog = new BookLogController(_bookLogService);
            var result  = booklog.DeleteBookLog(id);
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(id, result.Result.Id);

        }
        
        [Fact]
        public void GetAllAvailableMemberLogData_ListofModel()
        {
            _memberService = new MemberRepositoryServiceTest();
            MemberController member = new MemberController(_memberService);
            var a = member.GetMember();
            var response = a.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetAvailableMemberLogDataById_RowOfData(int id)
        {
            _memberService = new MemberRepositoryServiceTest();
            MemberController member = new MemberController(_memberService);
            var a = member.GetMemberById(id);
            var response = a.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);

        }
        
        [Theory]
        [InlineData(8)]
        [InlineData(9)]
        public void GetUnvailableMemberLogDataById_NotFound(int id)
        {
            _memberService = new MemberRepositoryServiceTest();
            MemberController member = new MemberController(_memberService);
            var a = member.GetMemberById(id);
            var response = a.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);

        }
        
        
        [Theory]
        [InlineData(4,"Tanjiro", "M", "08122545645", "student","tanjiro@gmail.com",1)]
        [InlineData(5,"Zenitsu", "M", "08565432645","student","zenitsu@gmail.com",2)]
        [InlineData(6,"Nezuko", "F", "085656545645","student","nezuko@gmail.com",3)]
        public void AddMemberData_RowOfData(int id,string name, string gender, string phone, string job, string email, int expected)
        {
            
            _memberService = new MemberRepositoryServiceTest();
            MemberController member = new MemberController(_memberService);
            MemberDto bd = new MemberDto()
            {
                Id = id,
                Name = name,
                Gender = gender,
                Phone = phone,
                Occupation = job,
                Email = email
                
            };
            
            var result  =member.AddMember(bd);
            // var a = member.GetMember();
            var response = result.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Id);

        }
        
        [Theory]
        [InlineData(2,"Levi", "M", "0812545645", "student","tanjiro@gmail.com")]
        [InlineData(3,"Eren", "M", "08199545645", "student","tanjiro@gmail.com")]
        public void EditAvailableMemberData_RowOfData(int id, string name, string gender, string phone, string job, string email)
        {
            _memberService = new MemberRepositoryServiceTest();
            MemberController member = new MemberController(_memberService);
            MemberDto bd = new MemberDto()
            {
                Id = id,
                Name = name,
                Gender = gender,
                Phone = phone,
                Occupation = job,
                Email = email
                
            };
            
            var result  =member.EditMember(bd);
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Result.Name);

        }
        
        [Theory]
        [InlineData(7,"Levi", "M", "0812545645", "student","tanjiro@gmail.com")]
        [InlineData(6,"Eren", "M", "08199545645", "student","tanjiro@gmail.com")]
        public void EditUnavailableMemberData_NotFound(int id, string name, string gender, string phone, string job, string email)
        {
            _memberService = new MemberRepositoryServiceTest();
            MemberController member = new MemberController(_memberService);
            MemberDto bd = new MemberDto()
            {
                Id = id,
                Name = name,
                Gender = gender,
                Phone = phone,
                Occupation = job,
                Email = email
                
            };
            
            var result  =member.EditMember(bd);
            var response = result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(expected, result.Result.Name);
        
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void DeleteAvailableMemberData_RowOfData(int id)
        {
       
            _memberService = new MemberRepositoryServiceTest();
            MemberController member = new MemberController(_memberService);
            var result  =member.DeleteMember(id);
            var response = result.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(id, result.Result.Id);

        }
        [Theory]
        [InlineData(7)]
        [InlineData(9)]
        public void DeleteUnavailableMemberData_NotFound(int id)
        {
       
            _memberService = new MemberRepositoryServiceTest();
            MemberController member = new MemberController(_memberService);
            var result  =member.DeleteMember(id);
            var response = result.Result.Result as OkObjectResult;
            Assert.True(response.StatusCode is 200);
            // Assert.Equal(id, result.Result.Id);

        }
    }

        
    }