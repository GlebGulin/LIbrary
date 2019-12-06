using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string NameAuthor { get; set; }
    }
}
