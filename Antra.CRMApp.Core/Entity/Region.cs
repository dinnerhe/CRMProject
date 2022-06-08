namespace Antra.CRMApp.Core.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Region
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [Column(TypeName = "nchar(50)")]
    private string Name { get; set; }
}