using System;
using LibraryAutoMapper.Model;

namespace LibraryAutoMapper.Dtos
{
    public class BookLogDto:ModelBaseDto
    {
        public DateTime StartTime{ get; set; }
        public DateTime EndTime{ get; set; }
        public int BookId { get; set; }
        public virtual BookDto Book { get; set; }
        public int MemberId { get; set; }
        public virtual  MemberDto Member { get; set; }
        
        public string Status { get; set; }
    }
}