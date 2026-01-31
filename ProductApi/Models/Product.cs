using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models;

public class Product
{
    [Key]
    public int Id{get; set;}

    [Required]
    public string Nombre { get; set;} = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Precio {get; set;}

    [Required]
    public string Categoria {get; set;} = string.Empty;
    
}