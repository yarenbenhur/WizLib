﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizLib_Model.Models
{
    public class Fluent_Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int DisplayOrder { get; set; }

    }
}
