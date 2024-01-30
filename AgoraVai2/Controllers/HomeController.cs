using AgoraVai2.ViewModel;
using Entidade;
using Entidade.Models;
using Microsoft.AspNetCore.Mvc;
using Negocio.Cadastro;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime;

namespace AgoraVai2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIndicadoDbSettings _settings;

        public HomeController(ILogger<HomeController> logger, IIndicadoDbSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IndicadoViewModel model)
        {
            Indicado indicado = new Indicado
            {
                nome = model.nome,
                numeroTelefone = Convert.ToInt64(model.numeroTelefone),
                observacoes = model.observacoes,
                nomeIndicador = model.nomeIndicador,
                telefoneIndicador = Convert.ToInt64(model.telefoneIndicador),
            };

            NegIndicado negIndicado = new NegIndicado(_settings);
            negIndicado.Create(indicado);
            return RedirectToAction("Index", "Home");
        }
    }
}