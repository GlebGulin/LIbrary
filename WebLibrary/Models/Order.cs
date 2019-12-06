using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        [ForeignKey("BookId")]
        public virtual Book TakenBook { get; set; }
        public int RegistrationId { get; set; }
        public string RegUserName { get; set; }
        [ForeignKey("RegistrationId")]
        public virtual Registration TakenUserBook { get; set; }
        public DateTime DateOrder { get; set; }
        public Order()
        {
            DateOrder = DateTime.Now;
        }
    }
}
