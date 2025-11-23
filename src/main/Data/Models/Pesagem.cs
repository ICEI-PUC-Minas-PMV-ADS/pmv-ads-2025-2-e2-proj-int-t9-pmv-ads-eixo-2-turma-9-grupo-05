using System;
using System.ComponentModel.DataAnnotations;

namespace EcoTrash.Models
{
    public class Pesagem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o tipo de material")]
        [StringLength(200)]
        public string TipoMaterial { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o peso")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O peso deve ser maior que zero")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Informe a localização")]
        [StringLength(200)]
        public string Localizacao { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}