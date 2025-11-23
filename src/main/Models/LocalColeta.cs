using System;
using System.ComponentModel.DataAnnotations;

namespace EcoTrash.Models
{
    public class LocalColeta
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(2)]
        public string Estado { get; set; } = string.Empty; // UF

        [Required, StringLength(120)]
        public string Cidade { get; set; } = string.Empty;

        [Required, StringLength(160)]
        public string Rua { get; set; } = string.Empty;

        [Required, StringLength(20)]
        public string Numero { get; set; } = string.Empty;

        [Required, StringLength(120)]
        public string Bairro { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public string EnderecoCompleto()
            => $"{Rua}, {Numero} - {Bairro}, {Cidade} - {Estado}, Brasil";
    }
}