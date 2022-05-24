using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Book
    {
        [Key]
        public int Book_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(15)]
        public string ISBN { get; set; }

        public double Price { get; set; }
        [NotMapped]
        public string PriceRange { get; set; }
        [ForeignKey("Detail")]
        public int? Detail_Id { get; set; }

        public Detail Detail{ get; set; }
        [ForeignKey("Publisher")]
        public int Publisher_Id { get; set; }

        public Publisher Publisher { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
