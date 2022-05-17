using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Detail
    {
        [Key]
        public int Detail_Id { get; set; }
        [Required]
        public string NumberOfChapters { get; set; }
        public string NumberOfPages { get; set; }
        public double Weight { get; set; }
        public Book Book { get; set; }


    }
}
