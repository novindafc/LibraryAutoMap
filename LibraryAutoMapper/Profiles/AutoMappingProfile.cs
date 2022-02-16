using AutoMapper;
using LibraryAutoMapper.Dtos;
using LibraryAutoMapper.Model;

namespace LibraryAutoMapper.Profiles
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookLog, BookLogDto>();
            CreateMap<Member, MemberDto>();
        }
    }

   
}