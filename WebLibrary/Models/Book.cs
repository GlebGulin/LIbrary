using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string NameBook { get; set; }
        public int AuthorId { get; set; }
        //public List<int> AuthorId { get; set; }
        //public List<string> AuthorName { get; set; }
        public string AuthorName { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author author { get; set; }
        public int TotalQuantity { get; set; }
        public int RealQuantity { get; set; }
    }
}
