using System.Collections.Generic;
using LibraryAutoMapper.Model;

namespace LibraryAutoMapper.Dtos
{
    public class BookDto:ModelBaseDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Position { get; set; }
        public int Qty { get; set; }
        public int Remains { get; set; }
        
        public virtual ICollection<BookLogDto> BookLog { get; set; }
    }
}