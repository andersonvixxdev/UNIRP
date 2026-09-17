using System.ComponentModel.DataAnnotations;

namespace ProjetoAula.Models;

public class Cambio
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser no mínimo 1 centavo")]
    public double? ValorInicial {get; set;}
    public double TaxaCambio {get; set;}
    public double ValorFinal {get; set;}
}