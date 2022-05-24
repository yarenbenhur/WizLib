using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizLib_Model.Models;

namespace WizLib_Model.ViewModel
{
   public class BookVM
    {
        public Book Book { get; set; }
        public IEnumerable<SelectListItem> PublisherList{ get; set; }

    }
}
