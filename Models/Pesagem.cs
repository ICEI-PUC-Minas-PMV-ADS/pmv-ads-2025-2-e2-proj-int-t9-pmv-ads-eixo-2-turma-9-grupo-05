using System;

[Table("Pesagem")]

public class Pesagem
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o tipo de resíduo.")]
    public string Tipo { get; set; }

    [Required(ErrorMessage = "Obrigatório informar o peso do resíduo.")]
    public double Peso { get; set; }

    [Required]
    public DateTime DataHora { get; set; }

    [ForeignKey("Usuario")]
    public int UsuarioId { get; set; }

    [InverseProperty("Pesagens")]
    public Usuario Usuario { get; set; }

    [NotMapped]
    public Pesagem()
    {
        DataHora = DateTime.Now;
    }

}
