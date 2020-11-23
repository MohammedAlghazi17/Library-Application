using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LibraryWebApp.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Rating { get; set; }
        public int CopiesSold { get; set; }
        public List<AuthorDTO> Authors { get; set; }
    }
}

