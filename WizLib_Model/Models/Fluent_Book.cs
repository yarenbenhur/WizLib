using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Fluent_Book
    {
        public int Book_Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
        public string PriceRange { get; set; }
        public int Detail_Id { get; set; }
        public Fluent_Detail Fluent_Detail { get; set; }
        public int Publisher_Id { get; set; }
        public Fluent_Publisher Fluent_Publisher { get; set; }
        public ICollection<Fluent_BookAuthor> Fluent_BookAuthors { get; set; }


    }
}
