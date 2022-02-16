using System.Collections.Generic;
using LibraryAutoMapper.Model;

namespace LibraryAutoMapper.Dtos
{
    public class MemberDto:ModelBaseDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<BookLogDto> BookLog { get; set; }
    }
}