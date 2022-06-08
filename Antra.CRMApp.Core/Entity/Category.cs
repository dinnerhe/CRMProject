using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [Column(TypeName ="varchar(50)")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Description is required")]
        [Column(TypeName ="text")]
        public string Description { get; set; }
    }
}
