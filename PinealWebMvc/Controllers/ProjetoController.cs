using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PinealWebMvc.Data;
using PinealWebMvc.Models;
using PinealWebMvc.Models.ViewModels;
using PinealWebMvc.Services;

namespace PinealWebMvc.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly ProjetoService _projetoService;
        private readonly VertenteService _vertenteService;
        private readonly TipoService _tipoProjetoService;

        public ProjetoController(ProjetoService projetoService, VertenteService vertenteService, TipoService tipoProjetoService)
        {
            _projetoService = projetoService;
            _vertenteService = vertenteService; 
            _tipoProjetoService = tipoProjetoService;
        }

        public IActionResult Index()
        {
            var list = _projetoService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var vertentes = _vertenteService.FindAll();
            var tipos = _tipoProjetoService.FindAll();
            var viewModel = new ProjetoFormViewModel { Vertentes = vertentes, Tipos = tipos};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Projeto projeto)
        {
            _projetoService.Insert(projeto);
            return RedirectToAction(nameof(Index));
        }
    }
}
