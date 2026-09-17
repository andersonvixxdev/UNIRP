using Microsoft.AspNetCore.Mvc;
using ProjetoAula.Models;

namespace ProjetoAula.Controllers;

public class CambioController : Controller
{
    public IActionResult Index() => View(new Cambio());
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calcular(Cambio model)
    {
        if(ModelState.IsValid) model.ValorFinal = (model.ValorInicial ?? 0) / model.TaxaCambio;
        return View("Index", model);
    }
}