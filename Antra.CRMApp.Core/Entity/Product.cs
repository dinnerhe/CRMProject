using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SupplierId is required")]
        [Column(TypeName = "int")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "CategoryId is required")]
        [Column(TypeName = "int")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "UnitPrice is required")]
        [Column(TypeName = "money")]
        public int UnitPrice { get; set; }

        [Required(ErrorMessage = "UnitsInStock is required")]
        [Column(TypeName = "smallint")]
        public int UnitsInStock { get; set; }

        [Required(ErrorMessage = "UnitsOnOrder is required")]
        [Column(TypeName = "smallint")]
        public int UnitsOnOrder { get; set; }

        [Required(ErrorMessage = "ReorderLevel is required")]
        [Column(TypeName = "smallint")]
        public int ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}
