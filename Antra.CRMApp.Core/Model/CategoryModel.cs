using System;
using System.ComponentModel.DataAnnotations;

namespace Antra.CRMApp.Core.Model
{
	public class CategoryModel
	{
		public int Id { get; set; }

        [Required(ErrorMessage ="Name is needed")]
		[Display(Name = "Enter Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Description is needed")]
		[Display(Name = "Enter Description")]
		public string Description { get; set; }
	}
}

