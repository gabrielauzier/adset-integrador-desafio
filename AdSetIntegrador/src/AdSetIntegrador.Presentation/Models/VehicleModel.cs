using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AdSetIntegrador.Domain.Entities;

namespace AdSetIntegrador.Presentation.Models;

public class VehicleModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "A Marca é obrigatória.")]
    [MaxLength(255, ErrorMessage = "A Marca pode ter no máximo 255 caracteres.")]
    [DisplayName("Marca")]
    public string Brand { get; set; }

    [Required(ErrorMessage = "O Modelo é obrigatório.")]
    [MaxLength(255, ErrorMessage = "O Modelo pode ter no máximo 255 caracteres.")]
    [DisplayName("Modelo")]
    public string Model { get; set; }

    [Required(ErrorMessage = "O Ano é obrigatório.")]
    [Range(2000, 2024, ErrorMessage = "O Ano deve estar entre 2000 e 2024.")]
    [DisplayName("Ano")]
    public int Year { get; set; }

    [Required(ErrorMessage = "A Placa é obrigatória.")]
    [MaxLength(20)]
    [DisplayName("Placa")]
    public string Plate { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "A quilometragem deve ser maior que zero.")]
    [DisplayName("Km")]
    public int? Mileage { get; set; }

    [Required(ErrorMessage = "A Cor é obrigatória.")]
    [MaxLength(50)]
    [DisplayName("Cor")]
    public string Color { get; set; }

    [Required(ErrorMessage = "O Preço é obrigatório.")]
    [Range(0, double.MaxValue, ErrorMessage = "O Preço deve ser maior ou igual a R$ 0,00")]
    [DisplayName("Preço")]
    public decimal Price { get; set; }

    [DisplayName("Opcionais")]
    [MaxLength(500)]
    public string? Optional { get; set; }

    public ICollection<Image> Images { get; set; } = [];
    public string? ImgBase64 { get; set; }
    public string? ImgContentType { get; set; }
}
