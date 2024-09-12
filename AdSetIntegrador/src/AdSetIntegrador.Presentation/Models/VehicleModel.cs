using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AdSetIntegrador.Presentation.Models;

public class VehicleModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Marca é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O campo Marca pode ter no máximo 100 caracteres.")]
    [DisplayName("Marca")]
    public string Brand { get; set; }

    [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O campo Modelo pode ter no máximo 100 caracteres.")]
    [DisplayName("Modelo")]
    public string Model { get; set; }

    [Required(ErrorMessage = "O campo Ano é obrigatório.")]
    [Range(2000, 2024, ErrorMessage = "O Ano deve estar entre 2000 e 2024.")]
    [DisplayName("Ano")]
    public int Year { get; set; }

    [Required(ErrorMessage = "O campo Placa é obrigatório.")]
    [MaxLength(20)]
    [DisplayName("Placa")]
    public string Plate { get; set; }

    [Range(0, int.MaxValue)]
    [DisplayName("Km")]
    public int? Mileage { get; set; }

    [Required(ErrorMessage = "O campo Cor é obrigatório.")]
    [MaxLength(50)]
    [DisplayName("Cor")]
    public string Color { get; set; }

    [Required(ErrorMessage = "O campo Preço é obrigatório.")]
    [Range(10000, double.MaxValue, ErrorMessage = "O Preço deve ser maior ou igual a R$ 10000")]
    [DisplayName("Preço")]
    public decimal Price { get; set; }
}
