using System.ComponentModel.DataAnnotations;

namespace ProjetoAula.Models;

public class Calculadora
{
	[Required(ErrorMessage = "Campo obrigatório")]
	[Range(double.MinValue, double.MaxValue, ErrorMessage = "Entrada inválida")]
	public double? Numero1 { get; set; }

	[Required(ErrorMessage = "Campo obrigatório")]
	[Range(double.MinValue, double.MaxValue, ErrorMessage = "Entrada inválida")]
	public double? Numero2 { get; set; }

	public string? Operacao { get; set; }

	public double? Resultado { get; set; }

	public string? MensagemResultado { get; set; }
}
