using Microsoft.AspNetCore.Mvc;
using ProjetoAula.Models;

namespace ProjetoAula.Controllers;

public class CalculadoraController : Controller
{
	public IActionResult Index() => View(new Calculadora());

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Calcular(Calculadora model)
	{
		if (!ModelState.IsValid)
		{
			return View("Index", model);
		}

		if (string.IsNullOrWhiteSpace(model.Operacao))
		{
			ModelState.AddModelError(string.Empty, "Selecione uma operação.");
			return View("Index", model);
		}

		if (model.Operacao == "dividir" && model.Numero2 == 0)
		{
			ModelState.AddModelError(nameof(model.Numero2), "Não é possível dividir por zero.");
			return View("Index", model);
		}

		double numero1 = model.Numero1 ?? 0;
		double numero2 = model.Numero2 ?? 0;

		switch (model.Operacao)
		{
			case "somar":
				model.Resultado = numero1 + numero2;
				break;
			case "subtrair":
				model.Resultado = numero1 - numero2;
				break;
			case "multiplicar":
				model.Resultado = numero1 * numero2;
				break;
			case "dividir":
				model.Resultado = numero1 / numero2;
				break;
			default:
				ModelState.AddModelError(string.Empty, "Operação inválida.");
				return View("Index", model);
		}

		model.MensagemResultado = $"Resultado: {model.Resultado ?? 0:F2}";
		return View("Index", model);
	}
}
