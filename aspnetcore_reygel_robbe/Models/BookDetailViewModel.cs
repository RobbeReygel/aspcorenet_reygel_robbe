using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetcore_reygel_robbe.Models
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public String ISBN { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
