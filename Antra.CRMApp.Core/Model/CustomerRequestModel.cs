using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antra.CRMApp.Core.Model
{
	public class CustomerRequestModel
	{
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(80)]
        public string Address { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string City { get; set; }
        [Display(Name ="Region")]
        public int RegionId { get; set; }
        public int PostalCode { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string Country { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string Phone { get; set; }
    }
}

