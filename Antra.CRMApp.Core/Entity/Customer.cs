using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Name is required")]
        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName = "varchar(50)")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Column(TypeName = "varchar(50)")]
        public string City { get; set; }

        [Required(ErrorMessage = "Region is required")]
        public int RegionId { get; set; }
        
        [Required(ErrorMessage = "PostalCode is required")]
        [Column(TypeName = "varchar(10)")]
        public string PostalCode { get; set; }
        
        [Required(ErrorMessage = "Country is required")]
        [Column(TypeName = "varchar(50)")]
        public string Country { get; set; }
        
        [Required(ErrorMessage ="Phone is required")]
        [Column(TypeName = "varchar(24)")]
        public string Phone { get; set; }
    }
}
